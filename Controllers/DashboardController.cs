using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portofolio.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Portofolio.AppModels.Repositories;
using Microsoft.AspNetCore.Identity;
using Portofolio.ViewModels;
using Portofolio.AppModels.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static Portofolio.AppModels.Utils.Constants;
using System.Collections.Generic;
namespace Portofolio.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ProjectsRepository _projectsRepository;
        private readonly UserManager<User> _userManager;

        private readonly UIPRepository _uipRepository;

        private readonly ContactRepository _contactsRepository;

        private readonly ProjectTypeRepository _projectTypeRepository;

        private readonly LinkTypesRepository _linkTypesRepository;

        private readonly UserRoleInProjectRepository _uripRepository;
        private readonly ProjectLinksRepository _projectLinksRepository;

        private readonly ProjectImagesRepository _projectImagesRepository;

        private readonly IImageServices _imageServices;

        private readonly ServicesRepository _servicesRepository;

        private readonly IPaginator<Project> _projectsPaginator;

        private readonly IPaginator<Service> _servicePaginator;

        private readonly ProjectLogsRepository _projectsLogsRepo;

        private readonly IPaginator<User> _usersPaginator;

        public DashboardController(BasePaginator<User> usersPaginator, ProjectLogsRepository projectsLogsRepo, BasePaginator<Service> servicePaginator, BasePaginator<Project> projectsPaginator, ServicesRepository servicesRepository, IImageServices imageServices, ProjectImagesRepository projectImagesRepository, ProjectLinksRepository projectLinksRepository, UserRoleInProjectRepository uripRepository, LinkTypesRepository linkTypesRepository, ProjectTypeRepository projectTypeRepository, ContactRepository contactsRepository, ProjectsRepository projectsRepository, UserManager<User> userManager, UIPRepository uipRepository)
        {
            _projectsRepository = projectsRepository;
            _userManager = userManager;
            _uipRepository = uipRepository;
            _contactsRepository = contactsRepository;
            _projectTypeRepository = projectTypeRepository;
            _linkTypesRepository = linkTypesRepository;
            _uripRepository = uripRepository;
            _projectLinksRepository = projectLinksRepository;
            _projectImagesRepository = projectImagesRepository;
            _imageServices = imageServices;
            _servicesRepository = servicesRepository;
            _projectsPaginator = projectsPaginator;
            _servicePaginator = servicePaginator;
            _projectsLogsRepo = projectsLogsRepo;
            _usersPaginator = usersPaginator;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var pendingContactsCount = await _contactsRepository.PendingContactsCount();
            ICollection<Project> projects = default(ICollection<Project>);
            if (await _userManager.IsInRoleAsync(user, UserRoles.Admin.ToString()))
            {
                projects = await _projectsRepository.GetAll();
            }
            else
            {
                projects = await _projectsRepository.GetUserCreatedProjects(user.Id);
            }
            var paginationModel = _projectsPaginator.Paginate(projects, page);
            return View(new ProjectsDashboardViewModel
            {
                User = user,
                PendingContactsCount = pendingContactsCount,
                PaginationModel = paginationModel
            });
        }

        public async Task<IActionResult> ProjectDetails(int id)
        {
            var project = await _projectsRepository.GetByIdWithInclude(id);
            if (project == default(Project))
            {
                return NotFound();
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if(user.Id != project.CreatorId && ! await _userManager.IsInRoleAsync(user, UserRoles.Admin.ToString()))
            {
                return Unauthorized();
            }
            var pendingContactsCount = await _contactsRepository.PendingContactsCount();
            var users = await _userManager.Users.ToListAsync();
            foreach (var userInProject in project.UsersInProjects)
            {
                users.Remove(userInProject.User);
            }
            var projectTypes = await _projectTypeRepository.GetAll();
            var linkTypes = await _linkTypesRepository.GetAll();
            var urips = await _uripRepository.GetAll();
            return View(new ProjectDetailsDashboardViewModel
            {
                User = user,
                PendingContactsCount = pendingContactsCount,
                Users = users,
                ChosenProject = project,
                ProjectTypes = projectTypes,
                UserRolesInProject = urips,
            });
        }

        [Authorize("Admin")]
        public async Task<IActionResult> Contacts()
        {
            var contacts = await _contactsRepository.GetAllOrderedByUpdateTime();
            var pendingContactsCount = await _contactsRepository.PendingContactsCount();
            return View(new ContactsDashboardViewModel
            {
                User = await _userManager.GetUserAsync(HttpContext.User),
                PendingContactsCount = pendingContactsCount,
                Contacts = contacts
            });
        }

        [Authorize("Admin")]
        public async Task<IActionResult> Services(int page = 1)
        {
            var pendingContactsCount = await _contactsRepository.PendingContactsCount();
            var services = await _servicesRepository.GetAll();
            var paginationModel = _servicePaginator.Paginate(services, page);
            return View(new ServicesDashboardVM
            {
                User = await _userManager.GetUserAsync(HttpContext.User),
                PendingContactsCount = pendingContactsCount,
                PaginationModel = paginationModel
            });
        }

        [Authorize("Admin")]
        public async Task<IActionResult> ProjectsLogs()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ICollection<ProjectLog> logs = await _projectsLogsRepo.GetAll();
            var pendingContactsCount = await _contactsRepository.PendingContactsCount();
            return View(new ProjectsLogsVM
            {
                Logs = logs,
                PendingContactsCount = pendingContactsCount,
                User = user
            });
        }

        [Authorize("Admin")]
        public async Task<IActionResult> Developers(int page = 1)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var users = await _userManager.Users.OrderByDescending((user) => user.CreatedAt).ToListAsync();
            users.Remove(user);
            var paginationModel = _usersPaginator.Paginate(users, page);
            var pendingContactsCount = await _contactsRepository.PendingContactsCount();
            return View(new MembersDashboardVM
            {
                User = user,
                PendingContactsCount = pendingContactsCount,
                UsersPagination = paginationModel
            });
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}