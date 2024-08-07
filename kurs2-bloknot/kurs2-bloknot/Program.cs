using AutoMapper;
using DayaAcces.BaserRepository;
using DayaAcces.IRepository;
using DayaAcces.Model;
using kurs2_bloknot.Mapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Service_Layer.Interfaces;
using Service_Layer.Services;
using System.Reflection.PortableExecutable;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/account/signin";
                });
builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
var mapperConfiguration = new MapperConfiguration(config =>
{
    config.AddProfile(new Profimap());
});

builder.Services.AddSingleton(mapperConfiguration.CreateMapper());
builder.Services.AddDbContext<ModelContext>();
builder.Services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<INotesRepository, NoteRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<INoteService, NoteServise>();



var app = builder.Build();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=StartApp}/{action=Index}/{id?}");

app.Run();
