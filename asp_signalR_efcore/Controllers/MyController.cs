using asp_signalR_efcore.Datas;
using asp_signalR_efcore.Hubs;
using asp_signalR_efcore.Models;
using asp_signalR_efcore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_signalR_efcore.Controllers
{
    [Route("api/[controller]")]
    public class MyController : Controller
    {
        IServiceProvider _provider;
        public MyController(IServiceProvider provider)
        {
            _provider = provider;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("initdb")]
        public string InitDb()
        {
            using (var context = getContext())
            {
                context.Database.EnsureDeleted();
                if (context.Database.EnsureCreated())
                    return "create db ok";
            }
            return "error";
        }

        [HttpGet("client")]
        public async Task<string> client(int id, string info)
        {
            var service = getMyServices();
            int index = service.GetIndex();
            var hub = getMyHub();
            await hub.Clients.All.SendAsync("ReceiveMessage", $"{id}-{index}",$"{info}");
            return $"post {id}-{index}-{info}";
        }

        [HttpPut("modify")]
        public string Modify(int id, string value)
        {
            using (var context = getContext())
            {
                var stu = context.Students.Find(id);
                if (null != stu)
                {
                    stu.name = value;
                    var ret = context.SaveChanges();
                    return $"put modify success. {id}-{value} ret:{ret}";
                }
            }
            return $"put {id}-{value}";
        }


        [HttpPut("put")]
        public string Put(int id, string value)
        {
            using (var context = getContext())
            {
                var s1 = context.Students.SingleOrDefault(s => s.Id == 1);
                var s2 = context.Students.SingleOrDefault(s => s.Id == 1);
                var stu = context.Students.SingleOrDefault(s=>s.Id==id);
                if(null == stu)
                {
                    stu = new Datas.Student();
                    context.Students.Add(stu);
                    var ret = context.SaveChanges();
                    return $"put added success. s1:{s1.GetHashCode()} s2:{s2.GetHashCode()} stu:{((object)context).GetHashCode()} {id}-{value} ret:{ret}";
                }
            }
            return $"put {id}-{value}";
        }

        [HttpPost("post")]
        public string Post(int id,[FromBody] JsonData value)
        {
            return $"post {id}-{value}";
        }

        [HttpDelete("delete")]
        public string Delete(int id)
        {
            using (var context = getContext())
            {
                if(context.Students.Count()!=0)
                {
                    var stu = context.Students.First();
                    if (null != stu)
                    {
                        context.Students.Remove(stu);
                        var ret = context.SaveChanges();
                        return $"put added success.{id} ret:{ret}";
                    }
                }
            }
            return $"delete {id}";
        }

        private MyContext getContext()
        {
            return _provider.CreateScope().ServiceProvider.GetService<MyContext>();
        }
        private IHubContext<MyHub> getMyHub()
        {
            return _provider.CreateScope().ServiceProvider.GetService<IHubContext<MyHub>>();
        }
        private IMyServices getMyServices()
        {
            return _provider.CreateScope().ServiceProvider.GetService<IMyServices>();
        }
    }
}
