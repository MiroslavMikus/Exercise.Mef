using Exercise.Mef.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Mef.Plugin.SecondPlugin
{
    public class SecondPlugin : IWorker
    {
        public string DoWork(string input)
        {
            return $"Second plugin at work: {input}";
        }
    }
}
