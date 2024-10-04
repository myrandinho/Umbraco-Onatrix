using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.ActionResults;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco_Onatrix.Models;
using Umbraco_Onatrix.Services;

namespace Umbraco_Onatrix.Controllers;

	public class ContactSurfaceController : SurfaceController
	{

		private readonly ContactService _contactService;
		
		public ContactSurfaceController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, ContactService contactService) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
		{
			_contactService = contactService;
		}



    
		public async Task<IActionResult> HandleSubmit(ContactFormModel form)
		{
			if (!ModelState.IsValid)
			{

			ViewData["name"] = form.Name;
			ViewData["email"] = form.Email;
			ViewData["phone"] = form.Phone;

			ViewData["error_name"] = string.IsNullOrEmpty(form.Name);
			ViewData["error_email"] = string.IsNullOrEmpty(form.Email);
			ViewData["error_phone"] = string.IsNullOrEmpty(form.Phone);

			return CurrentUmbracoPage();

			}

			await _contactService.CreateContactFormEntity(form);
			TempData["success"] = "Thank you for your submission. We will get back to you shortly.";
			var emailService = new EmailSenderService();
			await emailService.SendEmailAsync(form.Email);
			return RedirectToCurrentUmbracoPage();

		}


	public async Task<IActionResult> HandleHelpSubmit(string email)
	{
		if (!ModelState.IsValid)
		{

			ViewData["email"] = email;
			ViewData["error_email"] = string.IsNullOrEmpty(email);

			return CurrentUmbracoPage();

		}

		await _contactService.CreateGetHelpEntity(email);
		TempData["success"] = "form submitted sucessfully.";
		var emailService = new EmailSenderService();
		await emailService.SendEmailAsync(email);
		return RedirectToCurrentUmbracoPage();

	}

	public async Task<IActionResult> HandleMessageSubmit(MessageFormModel form)
	{
		if (!ModelState.IsValid)
		{
            ViewData["name"] = form.Name;
            ViewData["error_name"] = string.IsNullOrEmpty(form.Name);

            ViewData["email"] = form.Email;
            ViewData["error_email"] = string.IsNullOrEmpty(form.Email);

            ViewData["question"] = form.Question;
            ViewData["error_question"] = string.IsNullOrEmpty(form.Question);

            return CurrentUmbracoPage();
        }

        await _contactService.CreateMessageFormEntity(form);
        var emailService = new EmailSenderService();
        await emailService.SendEmailAsync(form.Email);
        TempData["success"] = "Thank you for your submission. We will get back to you shortly.";
        return RedirectToCurrentUmbracoPage();
    }
}




