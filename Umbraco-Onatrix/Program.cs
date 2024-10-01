using Microsoft.EntityFrameworkCore;
using Umbraco.Cms.Core.Services;
using Umbraco_Onatrix.Contexts;
using Umbraco_Onatrix.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.CreateUmbracoBuilder()
	.AddBackOffice()
	.AddWebsite()
	.AddDeliveryApi()
	.AddComposers()
	.Build();


string connectionString = builder.Configuration.GetConnectionString("umbracoDbDSN");


builder.Services.AddScoped<ContactService>();


builder.Services.AddUmbracoDbContext<DataContext>(options =>
{
	options.UseSqlServer(connectionString);
});

WebApplication app = builder.Build();

await app.BootUmbracoAsync();

app.UseHttpsRedirection();

app.UseUmbraco()
	.WithMiddleware(u =>
	{
		u.UseBackOffice();
		u.UseWebsite();
	})
	.WithEndpoints(u =>
	{
		u.UseBackOfficeEndpoints();
		u.UseWebsiteEndpoints();
	});

await app.RunAsync();
