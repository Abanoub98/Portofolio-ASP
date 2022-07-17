using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portofolio.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Portofolio.AppModels.Repositories;
using Portofolio.AppModels.Services;
using Portofolio.ViewModels;
using Portofolio.AppModels.Extensions;
using static Portofolio.AppModels.Utils.Constants;
namespace Portofolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;

        private readonly UIPRepository _uipRepository;

        private readonly UserLinksRepository _userLinksRepository;

        private readonly IPaginator<User> _usersPaginator;

        private readonly ProjectsRepository _projectsRepository;

        private readonly ServicesRepository _servicesRepository;

        private readonly UserCertificatesRepository _certificatesRepository;

        public HomeController(UserCertificatesRepository certificatesRepository, ServicesRepository servicesRepository, ProjectsRepository projectsRepository, BasePaginator<User> usersPaginator, UserManager<User> userManager, UIPRepository uipRepository, UserLinksRepository userLinksRepository)
        {
            _userManager = userManager;
            _uipRepository = uipRepository;
            _userLinksRepository = userLinksRepository;
            _usersPaginator = usersPaginator;
            _projectsRepository = projectsRepository;
            _servicesRepository = servicesRepository;
            _certificatesRepository = certificatesRepository;
        }
        public async Task<IActionResult> Index()
        {
            var latestProjects = await _projectsRepository.GetLatestProjects(NumOfLatestItems);
            var latestServices = await _servicesRepository.GetLatestServices(NumOfLatestItems);
            var founders = await _userManager.GetFounders();
            return View(new HomeViewModel{
                LatestProjects = latestProjects,
                LatestServices = latestServices,
                Founders = founders
            });
        }

        public async Task<IActionResult> Developers(int page = 1)
        {
            var latestProjects = await _projectsRepository.GetLatestProjects(NumOfLatestItems);
            var latestServices = await _servicesRepository.GetLatestServices(NumOfLatestItems);
            var users = await _userManager.Users.ToListAsync();
            users = users.OrderByDescending((user) => user.CreatedAt).ToList();
            var paginationVM = _usersPaginator.Paginate(users, page);
            return View(new DevelopersViewModel{
                PaginationModel = paginationVM,
                LatestProjects = latestProjects,
                LatestServices = latestServices
            });
        }

        public async Task<IActionResult> Profile(int id)
        {
            var user = await _userManager.GetUserByIdWithInclude(id);
            if(user == default(User))
            {
                return NotFound();
            }
            var latestProjects = await _projectsRepository.GetLatestProjects(NumOfLatestItems);
            var latestServices = await _servicesRepository.GetLatestServices(NumOfLatestItems);
            return View(new ProfileViewModel{
                User = user,
                LatestProjects = latestProjects,
                LatestServices = latestServices
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
