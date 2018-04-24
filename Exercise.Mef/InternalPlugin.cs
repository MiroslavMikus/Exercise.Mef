using Exercise.Mef.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Mef
{
    public class InternalPlugin : IWorker
    {
        public string DoWork(string input)
        {
            return $"{nameof(InternalPlugin)} plugin at work: {input}";
        }
    }
}
