using Microsoft.AspNetCore.Mvc;
using Portofolio.Models;
using System.Diagnostics;
using Portofolio.AppModels.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Portofolio.ViewModels;
using Microsoft.EntityFrameworkCore;
using Portofolio.AppModels.Services;
using Portofolio.AppModels.Extensions;
using Portofolio.AppModels.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using System.Linq;
using static Portofolio.AppModels.Utils.Constants;
namespace Portofolio.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ProjectsRepository _projectsRepository;

        private readonly UserManager<User> _userManager;
        private readonly UIPRepository _uipRepository;
        private readonly ProjectTypeRepository _projectTypeRepository;

        private readonly LinkTypesRepository _linkTypesRepository;

        private readonly UserRoleInProjectRepository _uripRepository;

        private readonly ProjectLinksRepository _projectLinksRepository;

        private readonly ProjectImagesRepository _projectImagesRepository;

        private readonly IImageServices _imageServices;

        private readonly ProjectFeedbacksRepository _feedbackRepository;

        private readonly IPaginator<Project> _projectPaginator;

        private readonly ProjectLogsRepository _projectLogRepository;

        private readonly ContactRepository _contactsRepository;

        private readonly IDisplayOutput _outputDisplayer;

        private readonly ServicesRepository _servicesRepository;

        public ProjectsController(ServicesRepository servicesRepository, IDisplayOutput outputDisplayer, ContactRepository contactsRepository, ProjectLogsRepository projectLogRepository, BasePaginator<Project> projectPaginator, ProjectFeedbacksRepository feedbackRepository, ProjectImagesRepository projectImagesRepository, ProjectLinksRepository projectLinksRepository, UIPRepository uipRepository, IImageServices imageServices, UserRoleInProjectRepository uripRepository, LinkTypesRepository linkTypesRepository, ProjectsRepository projectsRepository, UserManager<User> userManager, ProjectTypeRepository projectTypeRepository)
        {
            _userManager = userManager;
            _projectsRepository = projectsRepository;
            _projectTypeRepository = projectTypeRepository;
            _linkTypesRepository = linkTypesRepository;
            _uripRepository = uripRepository;
            _imageServices = imageServices;
            _uipRepository = uipRepository;
            _projectLinksRepository = projectLinksRepository;
            _projectImagesRepository = projectImagesRepository;
            _feedbackRepository = feedbackRepository;
            _projectPaginator = projectPaginator;
            _projectLogRepository = projectLogRepository;
            _contactsRepository = contactsRepository;
            _outputDisplayer = outputDisplayer;
            _servicesRepository = servicesRepository;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var latestProjects = await _projectsRepository.GetLatestProjects(NumOfLatestItems);
            var latestServices = await _servicesRepository.GetLatestServices(NumOfLatestItems);
            var projects = await _projectsRepository.GetAll();
            var paginationVM = _projectPaginator.Paginate(projects, page);
            return View(new ProjectsViewModel
            {
                LatestProjects = latestProjects,
                LatestServices = latestServices,
                PaginationModel = paginationVM
            });
        }

        public async Task<IActionResult> Details(int id)
        {
            var latestProjects = await _projectsRepository.GetLatestProjects(NumOfLatestItems);
            var latestServices = await _servicesRepository.GetLatestServices(NumOfLatestItems);
            var project = await _projectsRepository.GetByIdWithInclude(id);
            if (project == default(Project))
            {
                return NotFound();
            }
            return View(new ProjectDetailsViewModel
            {
                Project = await _projectsRepository.GetByIdWithInclude(id),
                LatestProjects = latestProjects,
                LatestServices = latestServices
            });
        }

        public async Task<IActionResult> Feedback(ProjectDetailsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AssignViewDataWithErrors(ViewData);
                return RedirectToAction(nameof(Details), new { id = model.ProjectId });
            }
            await _feedbackRepository.Create(new ProjectFeedback
            {
                ProjectId = model.ProjectId,
                Feedback = model.Feedback
            });
            _outputDisplayer.DisplayOutput(TempData, true, "Feedback submitted successfully");
            return RedirectToAction(nameof(Details), new { id = model.ProjectId });
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var users = await _userManager.Users.ToListAsync();
            var projectTypes = await _projectTypeRepository.GetAll();
            var linkTypes = await _linkTypesRepository.GetAll();
            var urips = await _uripRepository.GetAll();
            var pendingContactsCount = await _contactsRepository.PendingContactsCount();
            return View(new CreateProjectViewModel
            {
                PendingContactsCount = pendingContactsCount,
                User = user,
                Users = users,
                ProjectTypes = projectTypes,
                LinkTypes = linkTypes,
                UserRolesInProject = urips
            });
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProjectViewModel projectViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AssignViewDataWithErrors(ViewData);
                return RedirectToAction(nameof(Create));
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var teamLeaderRole = await _uripRepository.GetTeamLeaderRole();
            var teamLeader = projectViewModel.UsersNRolesIds.Where((usersNRoleId) => Convert.ToInt32(usersNRoleId.Split('-')[0]) == teamLeaderRole.Id).FirstOrDefault();
            if (teamLeader == default(string))
            {
                _outputDisplayer.DisplayOutput(TempData, false, "Please select a team leader for the project");
                return RedirectToAction(nameof(Create));
            }
            var project = await _projectsRepository.Create(new Project
            {
                CreatorId = user.Id,
                Title = projectViewModel.Title,
                Description = projectViewModel.Description,
                TypeId = projectViewModel.ProjectTypeId,
                ToolsUsed = projectViewModel.ToolsUsed
            });
            await _uipRepository.CreateFromCollection(project.Id, projectViewModel.UsersNRolesIds, '-');
            await _projectLinksRepository.CreateFromCollection(project.Id, projectViewModel.LinkTypesIds, projectViewModel.ProjectLinks);
            try
            {
                _imageServices.ValidateImgExtension(projectViewModel.ProjectThumbnail);
                var thumbnailPath = await _imageServices.UploadImgAsync(projectViewModel.ProjectThumbnail);
                await _imageServices.ResizeImg(thumbnailPath, ProjectImageSize);
                await _projectsRepository.AddThumbnail(project.Id, thumbnailPath);
            }
            catch (CustomException ex)
            {
                _outputDisplayer.DisplayOutput(TempData, false, ex.Message);
                return RedirectToAction(nameof(Create));
            }
            if (projectViewModel.ProjectImages != default(IFormFileCollection))
            {
                try
                {
                    await _projectImagesRepository.CreateFromCollection(project.Id, projectViewModel.ProjectImages, _imageServices);
                }
                catch (CustomException ex)
                {
                    _outputDisplayer.DisplayOutput(TempData, false, ex.Message);
                    return RedirectToAction(nameof(Create));
                }
            }
            _outputDisplayer.DisplayOutput(TempData, true, "Project created successfully");
            await _projectLogRepository.Create(new ProjectLog
            {
                CreatorId = user.Id,
                CreatorName = user.UserName,
                ProjectId = project.Id,
                UserId = user.Id,
                Title = project.Title,
                Action = LogActions.Create.ToString(),
                UserName = user.UserName
            });
            return RedirectToAction(nameof(DashboardController.Index), "Dashboard");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProjectDetailsDashboardViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AssignViewDataWithErrors(ViewData);
                return RedirectToAction(nameof(DashboardController.ProjectDetails), new { id = editViewModel.ProjectId });
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var project = await _projectsRepository.GetByIdNoInclude(editViewModel.ProjectId);
            if (user.Id != project.CreatorId && !await _userManager.IsInRoleAsync(user, UserRoles.Admin.ToString()))
            {
                return Unauthorized();
            }
            var edittedProject = await _projectsRepository.Edit(editViewModel.ProjectId, new Project
            {
                Title = editViewModel.Title,
                Description = editViewModel.Description,
                ToolsUsed = editViewModel.ToolsUsed,
                TypeId = editViewModel.ProjectTypeId
            });
            edittedProject.UsersInProjects = await _uipRepository.GetProjectUips(edittedProject.Id);
            await _uipRepository.EditFromCollection(edittedProject.UsersInProjects, editViewModel.UsersNRolesIds, '-');
            if (editViewModel.AddUsersNRolesIds != default(ICollection<string>) && editViewModel.AddUsersNRolesIds.Count != 0)
            {
                await _uipRepository.CreateFromCollection(editViewModel.ProjectId, editViewModel.AddUsersNRolesIds, '-');
            }
            await _projectLinksRepository.EditFromCollection(editViewModel.LinksIds, editViewModel.ProjectLinks);
            if (editViewModel.ProjectThumbnail != default(IFormFile))
            {
                try
                {
                    _imageServices.ValidateImgExtension(editViewModel.ProjectThumbnail);
                    string imagePath = await _imageServices.UploadImgAsync(editViewModel.ProjectThumbnail);
                    await _imageServices.ResizeImg(imagePath, ProjectImageSize);
                    _imageServices.DeleteImg(edittedProject.Thumbnail);
                    await _projectsRepository.AddThumbnail(edittedProject.Id, imagePath);
                }
                catch (CustomException ex)
                {
                    _outputDisplayer.DisplayOutput(TempData, false, ex.Message);
                    return RedirectToAction(nameof(DashboardController.ProjectDetails), new { id = editViewModel.ProjectId });
                }
            }
            if (editViewModel.ProjectImages != default(IFormFileCollection) && editViewModel.ProjectImages.Count != 0)
            {
                try
                {
                    await _projectImagesRepository.CreateFromCollection(edittedProject.Id, editViewModel.ProjectImages, _imageServices);
                }
                catch (CustomException ex)
                {
                    _outputDisplayer.DisplayOutput(TempData, false, ex.Message);
                    return RedirectToAction(nameof(DashboardController.ProjectDetails), new { id = editViewModel.ProjectId });
                }
            }
            _outputDisplayer.DisplayOutput(TempData, true, "Project edit is successful");
            var creator = await _userManager.GetUserById(edittedProject.CreatorId);
            await _projectLogRepository.Create(new ProjectLog
            {
                CreatorId = creator.Id,
                CreatorName = creator.UserName,
                ProjectId = edittedProject.Id,
                UserId = user.Id,
                Title = edittedProject.Title,
                Action = LogActions.Update.ToString(),
                UserName = user.UserName
            });
            return RedirectToAction(nameof(DashboardController.ProjectDetails), "Dashboard", new { id = editViewModel.ProjectId });
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _projectsRepository.GetByIdWithInclude(id);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user.Id != project.CreatorId && !await _userManager.IsInRoleAsync(user, UserRoles.Admin.ToString()))
            {
                return Unauthorized();
            }
            if (project.ProjectFeedbacks != default(ICollection<ProjectFeedback>) && project.ProjectFeedbacks.Count != 0)
            {
                await _feedbackRepository.DeleteCollection(project.ProjectFeedbacks);
            }
            foreach (var image in project.ProjectImages)
            {
                _imageServices.DeleteImg(image.ImagePath);
            }
            await _projectImagesRepository.DeleteCollection(project.ProjectImages);
            await _projectLinksRepository.DeleteCollection(project.ProjectLinks);
            await _uipRepository.DeleteCollection(project.UsersInProjects);
            await _projectsRepository.Delete(project.Id);
            var creator = await _userManager.GetUserById(project.CreatorId);
            await _projectLogRepository.Create(new ProjectLog
            {
                CreatorId = creator.Id,
                CreatorName = creator.UserName,
                ProjectId = id,
                UserId = user.Id,
                Title = project.Title,
                Action = LogActions.Delete.ToString(),
                UserName = user.UserName
            });
            return RedirectToAction(nameof(DashboardController.Index), "Dashboard");
        }

        [Authorize]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var image = await _projectImagesRepository.GetById(id);
            var project = await _projectsRepository.GetByIdNoInclude(image.ProjectId);
            if (user.Id != project.CreatorId && !await _userManager.IsInRoleAsync(user, UserRoles.Admin.ToString()))
            {
                return Unauthorized();
            }
            _imageServices.DeleteImg(image.ImagePath);
            await _projectImagesRepository.Delete(image.Id);
            var creator = await _userManager.GetUserById(project.CreatorId);
            await _projectLogRepository.Create(new ProjectLog
            {
                CreatorName = creator.UserName,
                CreatorId = creator.Id,
                ProjectId = project.Id,
                UserId = user.Id,
                Title = project.Title,
                Action = ProjectImageDeleteAction,
                UserName = user.UserName
            });
            return RedirectToAction(nameof(DashboardController.ProjectDetails), "Dashboard", new { id = image.ProjectId });
        }

        [Authorize]
        public async Task<IActionResult> DeleteUip(int id)
        {
            var uip = await _uipRepository.Delete(id);
            var project = await _projectsRepository.GetByIdNoInclude(uip.ProjectId);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user.Id != project.CreatorId && !await _userManager.IsInRoleAsync(user, UserRoles.Admin.ToString()))
            {
                return Unauthorized();
            }
            var creator = await _userManager.GetUserById(project.CreatorId);
            await _projectLogRepository.Create(new ProjectLog
            {
                CreatorId = creator.Id,
                CreatorName = creator.UserName,
                ProjectId = uip.ProjectId,
                UserId = user.Id,
                Title = project.Title,
                Action = ProjectUipDeleteAction,
                UserName = user.UserName
            });
            return RedirectToAction(nameof(DashboardController.ProjectDetails), "Dashboard", new { id = uip.ProjectId });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}