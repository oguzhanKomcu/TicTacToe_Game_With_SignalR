
using TicTacToe_Game_Wİth_SignalR.Hubs;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed(origin => true)

));
builder.Services.AddSignalR();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors();//cors politikalar� i�in ekledik
app.UseRouting();
app.UseEndpoints(enpoints =>
{
    enpoints.MapHub<GameHub>("/gamehub");
});

app.UseAuthorization();

app.MapRazorPages();

app.Run();