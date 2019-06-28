using asp_signalR_efcore.Datas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_signalR_efcore.Models
{

    // 创建数据库服务
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
           : base(options)
        {
            Database.SetCommandTimeout(60);
        }

        public DbSet<Student> Students { get; set; }
    } 
}
