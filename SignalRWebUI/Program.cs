using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using SignalR.BusinnesLayer.ValidationRules.BookingValidations;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

var builder = WebApplication.CreateBuilder(args);

var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

// Add services to the container.
builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<SignalRContext>();
builder.Services.AddControllersWithViews(opt =>
{
	opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
}).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateBookingValidator>()); ;

//builder.Services.AddValidatorsFromAssemblyContaining<CreateBookingValidator>();
builder.Services.AddTransient<IValidator<CreateBookingDto>, CreateBookingValidator>();




builder.Services.ConfigureApplicationCookie(opts =>
{
	opts.LoginPath = "/Login/Index";
});


//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//	.AddCookie(options =>
//	{
//		options.LoginPath = "/Login/Index"; // Yetkisiz kullanýcý buraya yönlenir
//	});



builder.Services.AddHttpClient();

var app = builder.Build();

app.UseStatusCodePages(async x =>
{
	if (x.HttpContext.Response.StatusCode == 404)
	{
		x.HttpContext.Response.Redirect("/Error/NotFound404Page/");
	}
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
