using biz_shared;
using biz_shared.Impl;
using CommonDAL.Context;
using CommonDAL.Impl;
using CommonDAL.Interfaces;
using CoreModel;
using CoreService;
using CoreService.Impl;
using Microsoft.EntityFrameworkCore;
using Com.Ctrip.Framework.Apollo;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//注册服务
builder.Services.AddDbContext<AuthCenterContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthCenterContext")));
builder.Services.AddScoped<IEfCoreSystemUserRepository,EfCoreSystemUserRepository>();
builder.Services.AddScoped<ISystemUserDomainService,SystemUserDomainServiceImpl>();
builder.Services.AddScoped<ISystemUserBizService,SystemUserBizServiceImpl>();

//注册配置option
builder.Services.Configure<DefaultSystemUserOption>(builder.Configuration.GetSection("DefaultSystemUser"));

//注册Apollo
builder.Host.ConfigureAppConfiguration(hostBuilder=>hostBuilder.AddApollo(hostBuilder.Build().GetSection("apollo")));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();