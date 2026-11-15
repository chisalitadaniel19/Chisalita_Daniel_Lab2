global using Chisalita_Daniel_Lab2.Models;
using Microsoft.EntityFrameworkCore;
using Chisalita_Daniel_Lab2.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Chisalita_Daniel_Lab2Context")
    ?? throw new InvalidOperationException("Connection string 'Chisalita_Daniel_Lab2Context' not found.");

// 1. Înregistrare context bază de date aplicație
builder.Services.AddDbContext<Chisalita_Daniel_Lab2Context>(options =>
    options.UseSqlServer(connectionString));

// 2. Înregistrare context bază de date Identity
builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(connectionString));

// 3. Adăugare servicii Identity cu suport pentru roluri
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

// 4. Definire politică pentru rolul Admin
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
});

// 5. Restricționare acces pe foldere și pagini
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Books");
    options.Conventions.AllowAnonymousToPage("/Books/Index");
    options.Conventions.AllowAnonymousToPage("/Books/Details");

    options.Conventions.AuthorizeFolder("/BorrowingPages");

    options.Conventions.AuthorizeFolder("/Members", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Publishers", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Authors", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/CategoryPages", "AdminPolicy");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();