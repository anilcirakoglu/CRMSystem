using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie
     (JwtBearerDefaults.AuthenticationScheme, opt =>
     {
         opt.LoginPath = "/Login/Index";
         opt.AccessDeniedPath = "/Login/AccessDenied";
         opt.Cookie.SameSite = SameSiteMode.Strict;
         opt.Cookie.HttpOnly = true;
         opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
         opt.Cookie.Name = "Cookie";

     });
builder.Services.AddAuthorization(options =>
{

    options.AddPolicy("AdminPolicy", policy =>
    {
        policy.AddAuthenticationSchemes(
                  JwtBearerDefaults.AuthenticationScheme);
        //policy.RequireAuthenticatedUser();
        policy.RequireRole("Admin");

    });
    options.AddPolicy("ManagerPolicy", policy =>
    {
        policy.AddAuthenticationSchemes(
                  JwtBearerDefaults.AuthenticationScheme);
        //policy.RequireAuthenticatedUser();
        policy.RequireRole("Manager");
    });



}
);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
  
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
