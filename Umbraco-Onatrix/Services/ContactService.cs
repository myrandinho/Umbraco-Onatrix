using Umbraco_Onatrix.Contexts;
using Umbraco_Onatrix.Entities;
using Umbraco_Onatrix.Models;

namespace Umbraco_Onatrix.Services;

public class ContactService(DataContext context)
{
	private readonly DataContext context = context;


	public async Task<ContactFormEntity> CreateContactFormEntity(ContactFormModel model)
	{
		var entity = new ContactFormEntity
		{
			Name = model.Name,
			Email = model.Email,
			Phone = model.Phone,
			DateTime = DateTime.Now
		};

		var result = await context.ContactForms.AddAsync(entity);
		await context.SaveChangesAsync();
		return entity;
	}

	public async Task<GetHelpEntity> CreateGetHelpEntity(string email)
	{
		var entity = new GetHelpEntity
		{
			Email = email,
			DateTime = DateTime.Now

		};

		var result = await context.HelpForm.AddAsync(entity);
		await context.SaveChangesAsync();
		return entity;
	}

	public async Task<MessageFormEntity> CreateMessageFormEntity(MessageFormModel model)
	{
		var entity = new MessageFormEntity
		{
			Name = model.Name,
			Email = model.Email,
			Question = model.Question,
		};

		var result = await context.MessageForms.AddAsync(entity);
		await context.SaveChangesAsync();
		return entity;
	}


}
