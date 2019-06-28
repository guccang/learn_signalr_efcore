using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_signalR_efcore.Services
{
    public interface IMyServices
    {
        int GetIndex();
    }

    public class MyServices : IMyServices
    {
        private int _index { get; set; }
        private IServiceProvider _provider;
        public MyServices(IServiceProvider provider)
        {
            _provider = provider;
        }

        public int GetIndex()
        {
            lock(this)
            {
                return _index++;
            }
        }
    }
}
