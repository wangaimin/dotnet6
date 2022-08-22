using System.Data;
using CommonDAL.Model;
using Microsoft.EntityFrameworkCore;

namespace CommonDAL.Context;

public class AuthCenterContext:DbContext
{
    public AuthCenterContext (DbContextOptions<AuthCenterContext> options)
        : base(options)
    {
    }
    
    public DbSet<SystemUser> SystemUser { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //设置Entity和表名的映射
        //设置Entity中字段对应表中的主键
        modelBuilder.Entity<SystemUser>().ToTable("SystemUser_Gene").HasKey(o => o.SysNo);
    }
}