using Azure.Identity;
using Azure.Storage.Blobs;
using instaclone.data;
using instaclone.Data;
using instaclone.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddDbContext<ApplicationDbContext>(
       options => options.UseNpgsql(builder.Configuration.GetConnectionString("API_DB"))
    );

builder.Services.AddAuthorization();

builder.Services.AddSingleton<BlobStorageService>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 10;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;

    options.User.RequireUniqueEmail = true;
});

builder.Services.AddIdentityCore<InstaCloneUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityApiEndpoints<InstaCloneUser>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireDigit = false;
    opt.Password.RequireUppercase = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllers().AddJsonOptions(option => option
    .JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);

builder.Services.AddDbContext<SocialMediaContext>( options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("API_DB"))
    );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var blobServiceClient = new BlobServiceClient(
//        new Uri("https://instaclone.blob.core.windows.net"),
//        new DefaultAzureCredential());

//string containerName = "instacloneBlobs" + Guid.NewGuid().ToString();

//BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);

var app = builder.Build();


// maps the identity api endpoints
app.MapIdentityApi<InstaCloneUser>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins("http://localhost:5173") 
        .AllowCredentials();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
