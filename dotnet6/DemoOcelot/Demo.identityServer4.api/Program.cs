using Demo.identityServer4.api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddIdentityServer()
    .AddDeveloperSigningCredential()
    //.AddInMemoryApiResources(IdentityServerConfig.ApiResources)
    .AddInMemoryApiScopes(IdentityServerConfig.Scopes)
    .AddInMemoryClients(IdentityServerConfig.Clients)
    .AddTestUsers(IdentityServerConfig.Users.ToList());

//builder.Services.AddAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseIdentityServer();

app.UseAuthorization();

app.MapControllers();

app.Run();
