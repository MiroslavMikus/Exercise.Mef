using Exercise.Mef.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Mef
{
    //[Export]
    public class PluginHost
    {
        //[ImportMany(typeof(IWorker), AllowRecomposition = true)]
        public List<Lazy<IWorker>> _workers;

        [ImportingConstructor]
        public PluginHost([ImportMany(RequiredCreationPolicy = CreationPolicy.NonShared)] IEnumerable<Lazy<IWorker>> workers)
        {
            _workers = new List<Lazy<IWorker>>(workers);
        }

        public void Run(string hostName)
        {
            foreach (var worker in _workers)
            {
                Console.WriteLine($"Host-{hostName}: {worker.Value.DoWork("important work")}");
            }
        }
    }
}
