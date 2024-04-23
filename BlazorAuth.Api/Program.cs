using BlazorAuth.Api.Extensions;
using BlazorAuth.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddJWTAuthentication(builder.Configuration);
builder.Services.AddAuthorization(opt => {
    string[] roleParams = ["Admin"];
    opt.AddPolicy("RequireAdminRole", policy => policy.RequireRole(roleParams));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddCORSConfiguration();
builder.Services.AddDIContainerConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("local");

app.UseMiddleware<GlobalErrorHandler>();

app.UseAuthentication();
app.UseAuthorization();

app.MapApiRoutes();

app.Run();

