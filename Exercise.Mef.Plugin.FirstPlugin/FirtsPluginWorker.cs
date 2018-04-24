using Exercise.Mef.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Mef.Plugin.FirstPlugin
{
    public class FirtsPluginWorker : IWorker
    {
        public string DoWork(string input)
        {
            return $"First plugin at work: {input}";
        }
    }
}
