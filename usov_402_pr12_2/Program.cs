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
            new Company { Name = "�� ����� �������", Address = "������ �����", PhoneNumber = "1 �������" },
            new Company { Name = "�� � �� �����", Address = "������ �����", PhoneNumber = "2 �������" },
            new Company { Name = "�� �����", Address = "������ ������", PhoneNumber = "3 �������" },
            new Company { Name = "��������", Address = "�������� ������", PhoneNumber = "4 �������" },
            new Company { Name = "� ������ �'���", Address = "������ 5", PhoneNumber = "5 �������" }
        );
        context.SaveChanges();
    }
}

app.Run();
