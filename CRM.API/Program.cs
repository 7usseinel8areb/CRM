using CRM.API.Extensions;
using CRM.DataAccess.Extensions;
using CRM.Model.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") 
        ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found."); ;

// No Need for default identity in API  
//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddSQLServerConnection(connectionString);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddSwaggerDocumentation(builder.Configuration);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwaggerDocumentation(app.Configuration);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.Run();
