using biz_shared;
using biz_shared.Impl;
using CommonDAL.Context;
using CommonDAL.Impl;
using CommonDAL.Interfaces;
using CoreService;
using CoreService.Impl;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AuthCenterContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthCenterContext")));
builder.Services.AddScoped<IEfCoreSystemUserRepository,EfCoreSystemUserRepository>();
builder.Services.AddScoped<ISystemUserDomainService,SystemUserDomainServiceImpl>();
builder.Services.AddScoped<ISystemUserBizService,SystemUserBizServiceImpl>();


var app = builder.Build();

/*using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AuthCenterContext>();
    var systemUser = new SystemUser()
    {
        LoginPassword = "111",
        InDate = DateTime.Now,
        EditDate = DateTime.Now,
        InUserSysNo = 1,
        InUserName = "Gene",
        LoginName = "Gene",
        Email = "123@qq.com",
        EditUserName = "Gene",
        EditUserSysNo = 0,
        UserFullName = "test",
        CellPhone = "13566666666"
    };
    context.SystemUser.Add(systemUser);
    context.SaveChanges();
}*/

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