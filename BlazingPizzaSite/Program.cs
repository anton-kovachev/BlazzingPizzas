using BlazingPizza.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<PizzaService>();
builder.Services.AddHttpClient();
builder.Services.AddSqlite<PizzaStoreContext>("Data Source=pizza.db");

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.MapBlazorHub();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.MapFallbackToPage("/_Host");

using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
var dbContext = serviceScope.ServiceProvider.GetRequiredService<PizzaStoreContext>();

if (dbContext.Database.EnsureCreated())
{
    await SeedData.InitializeSpeicalPizzas(dbContext);
}

