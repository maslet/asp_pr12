using Microsoft.EntityFrameworkCore;
using usov_402_pr12_2.Data;
using usov_402_pr12_2.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Companies}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    Initialize(services);
}

void Initialize(IServiceProvider serviceProvider)
{
    var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();

    context.Companies.RemoveRange(context.Companies);
    context.SaveChanges();

    if (!context.Companies.Any())
    {
        context.Companies.AddRange(
            new Company { Name = "Це перша компанія", Address = "Адреса першої", PhoneNumber = "1 телефон" },
            new Company { Name = "Ну а це друга", Address = "Адреса другої", PhoneNumber = "2 телефон" },
            new Company { Name = "Це третя", Address = "Адреса третьої", PhoneNumber = "3 телефон" },
            new Company { Name = "Четверта", Address = "Четверта адреса", PhoneNumber = "4 телефон" },
            new Company { Name = "І нарешті п'ята", Address = "Адреса 5", PhoneNumber = "5 телефон" }
        );
        context.SaveChanges();
    }
}

app.Run();
