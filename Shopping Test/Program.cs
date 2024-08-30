

using Shopping_Test.CoreIUnitOfWork;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDistributedRedisCache(option =>
{
      option.InstanceName = "redis";
      option.Configuration = "localhost:6379";
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>
    (options => options.SignIn.RequireConfirmedAccount = true)
          .AddEntityFrameworkStores<ApplicationDbContext>()
          .AddDefaultTokenProviders()
          .AddDefaultUI();

/*builder.Services.AddDatabaseDeveloperPageExceptionFilter();*/

builder.Services.AddAuthentication(option =>
 {
     option.DefaultScheme = "cookie";
     option.DefaultChallengeScheme = "cookie";
     option.DefaultSignInScheme = "cookie";
     option.DefaultForbidScheme = "cookie";
 }).AddCookie("cookie", c =>
 {
     c.AccessDeniedPath = "/Identity/Account/AccessDenied";
     c.LoginPath = "/Identity/Account/login";
     c.Cookie.Name = "run";
 }).AddCookie("cook", c =>
 {
     c.LoginPath = "/Identity/Account/Login";
});
    builder.Services.AddRazorPages();
    builder.Services.AddControllersWithViews();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<IProcessImage, ProcessImage>();
    builder.Services.AddScoped<IConditionClassification, ConditionClassfication>();
    builder.Services.AddScoped<IProxyResultOfProducts, ProxyResultOfProducts>();
    builder.Services.AddScoped<IGetSelectListItems, GetSelectListItems>();
    builder.Services.AddScoped<ICaching, Caching>();


//////////////////////////////////////////////////////////////////////////////////
///

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    /*app.UseMigrationsEndPoint();*/
}
else
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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
