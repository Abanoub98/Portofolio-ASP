using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portofolio.Models;
using Portofolio.AppModels.Repositories;
using System.Diagnostics;
using Portofolio.ViewModels;
using Portofolio.AppModels.Services;
using static Portofolio.AppModels.Utils.Constants;
using Portofolio.AppModels.Extensions;
using Portofolio.AppModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
namespace Portofolio.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactRepository _contactRepository;
        private readonly ServicesRepository _servicesRepository;

        private readonly IMailService _mailService;

        private readonly RequestedServicesRepository _requestedServicesRepository;

        private readonly IEmailParserFromModelAsync<HTMLWithModel<Contact>> _contactEmailParser;

        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;

        private readonly ContactStatusRepository _contactStatusRepository;

        private readonly IDisplayOutput _outputDisplayer;

        private readonly ProjectsRepository _projectsRepository;

        public ContactController(ProjectsRepository projectsRepository, ServicesRepository servicesRepository, IDisplayOutput outputDisplayer, SignInManager<User> signInManager, ContactStatusRepository contactStatusRepository, UserManager<User> userManager, ContactRepository contactRepository, IEmailParserFromModelAsync<HTMLWithModel<Contact>> contactEmailParser, RequestedServicesRepository requestedServicesRepository, IMailService mailService)
        {
            _mailService = mailService;
            _contactRepository = contactRepository;
            _requestedServicesRepository = requestedServicesRepository;
            _contactEmailParser = contactEmailParser;
            _userManager = userManager;
            _contactStatusRepository = contactStatusRepository;
            _signInManager = signInManager;
            _outputDisplayer = outputDisplayer;
            _projectsRepository = projectsRepository;
            _servicesRepository = servicesRepository;
        }
        public async Task<IActionResult> Index()
        {
            var latestProjects = await _projectsRepository.GetLatestProjects(NumOfLatestItems);
            var latestServices = await _servicesRepository.GetLatestServices(NumOfLatestItems);
            var viewModel = new ContactWithServicesViewModel
            {
                Services = await _servicesRepository.GetAll(),
                LatestProjects = latestProjects,
                LatestServices = latestServices
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactWithServicesViewModel contactData)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AssignViewDataWithErrors(ViewData);
                return RedirectToAction(controllerName: "Contact", actionName: "Index");
            }
            Contact savedContact = await _contactRepository.Create(contactData.Contact);
            await _requestedServicesRepository.CreateFromIds(contactData.RequestedServicesIds, savedContact.Id);
            var contact = await _contactRepository.GetById(savedContact.Id);
            var mailRequest = await _contactEmailParser.ParseAsync(new HTMLWithModel<Contact>
            {
                Model = contact,
                Path = ContactHtmlTemplatePath,
                HrefValue = $"href={Url.ActionLink(nameof(ContactController.ContactDetails), "Contact", new { id = contactData.Contact.Id }, Request.Scheme)}"
            });
            await _mailService.SendEmailAsync(mailRequest);
            _outputDisplayer.DisplayOutput(TempData, true, "Contact received successfuly, we will contact you asap!");
            return RedirectToAction(controllerName: "Contact", actionName: "Index");
        }
        [Authorize("Admin")]
        public async Task<IActionResult> ContactDetails(int id)
        {
            var contact = await _contactRepository.GetById(id);
            if(contact == default(Contact))
            {
                return NotFound();
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var statuses = await _contactStatusRepository.GetAll();
            return View(new ContactDetailsViewModel
            {
                PendingContactsCount = await _contactRepository.PendingContactsCount(),
                Contact = contact,
                User = user,
                ContactStatuses = statuses
            });
        }

        [Authorize("Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditContactStatus(ContactDetailsViewModel editViewModel)
        {
            if (editViewModel.StatusId == default(int))
            {
                _outputDisplayer.DisplayOutput(TempData, false, "Please select a new status for the contact");
            }
            else
            {
                var contact = await _contactRepository.Edit(editViewModel.Contact.Id, editViewModel.StatusId);
                _outputDisplayer.DisplayOutput(TempData, true, "Contact editted successfuly");
                var user = await _userManager.GetUserAsync(HttpContext.User);
            }
            return RedirectToAction(nameof(ContactDetails), new { id = editViewModel.Contact.Id });
        }

        [Authorize("Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = await _contactRepository.GetById(id);
            await _contactRepository.Delete(contact);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return RedirectToAction(nameof(DashboardController.Contacts), "Dashboard");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}