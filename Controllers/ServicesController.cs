using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Portofolio.Models;
using Portofolio.AppModels.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Portofolio.ViewModels;
using Portofolio.AppModels.Extensions;
using Portofolio.AppModels.Services;
using Portofolio.AppModels.Exceptions;
using static Portofolio.AppModels.Utils.Constants;
using Microsoft.AspNetCore.Http;
namespace Portofolio.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ServicesRepository _repository;

        private readonly IImageServices _imageServices;

        private readonly IPaginator<Service> _paginator;

        private readonly IDisplayOutput _outputDisplayer;

        private readonly ProjectsRepository _projectsRepository;

        public ServicesController(ProjectsRepository projectsRepository, IDisplayOutput outputDisplayer, BasePaginator<Service> paginator, ServicesRepository repository, IImageServices imageServices)
        {
            _repository = repository;
            _imageServices = imageServices;
            _paginator = paginator;
            _outputDisplayer = outputDisplayer;
            _projectsRepository = projectsRepository;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            var latestProjects = await _projectsRepository.GetLatestProjects(NumOfLatestItems);
            var latestServices = await _repository.GetLatestServices(NumOfLatestItems);
            ICollection<Service> services = await _repository.GetAll();
            var paginatedModel = _paginator.Paginate(services, page);
            return View(new ServicesViewModel
            {
                LatestProjects = latestProjects,
                LatestServices = latestServices,
                PaginationModel = paginatedModel
            });
        }

        [HttpPost]
        [Authorize("Admin")]
        public async Task<IActionResult> Create(ServicesDashboardVM serviceVM)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(DashboardController.Services), "Dashboard");
            }
            var service = new Service
            {
                ServiceName = serviceVM.Name,
                ServiceDescription = serviceVM.Description
            };
            if (serviceVM.ServiceImage != null)
            {
                service.ServiceImage = await _imageServices.UploadImgAsync(serviceVM.ServiceImage);
                await _imageServices.ResizeImg(service.ServiceImage, ServiceImageSize);
            }
            await _repository.Create(service);
            return RedirectToAction(nameof(DashboardController.Services), "Dashboard");
        }

        [Authorize("Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var service = await _repository.Delete(id);
            _imageServices.DeleteImg(service.ServiceImage);
            return RedirectToAction(nameof(DashboardController.Services), "Dashboard");
        }

        [Authorize("Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServicesDashboardVM model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AssignViewDataWithErrors(ViewData);
                return RedirectToAction(nameof(DashboardController.Services), "Dashboard");
            }
            if (model.ServiceImage != default(IFormFile))
            {
                try
                {
                    var service = new Service
                    {
                        ServiceName = model.Name,
                        ServiceDescription = model.Description
                    };
                    _imageServices.ValidateImgExtension(model.ServiceImage);
                    _imageServices.DeleteImg(service.ServiceImage);
                    service.ServiceImage = await _imageServices.UploadImgAsync(model.ServiceImage);
                    await _imageServices.ResizeImg(service.ServiceImage, ServiceImageSize);
                    await _repository.EditWithImage(id, service);
                }
                catch (CustomException ex)
                {
                    _outputDisplayer.DisplayOutput(TempData, false, ex.Message);
                    return RedirectToAction(nameof(DashboardController.Services), "Dashboard");
                }
            }
            else
            {
                var newService = new Service
                {
                    ServiceName = model.Name,
                    ServiceDescription = model.Description,
                };
                await _repository.EditWithoutImage(id, newService);
            }
            _outputDisplayer.DisplayOutput(TempData, true, "Service edit successful");
            return RedirectToAction(nameof(DashboardController.Services), "Dashboard");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}