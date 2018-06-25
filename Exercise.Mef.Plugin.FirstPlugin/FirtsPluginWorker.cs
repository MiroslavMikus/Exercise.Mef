using Exercise.Mef.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Mef.Plugin.FirstPlugin
{
    public class FirstPluginWorker : IWorker
    {
        [Import]
        private ILogger Logger;

        //[ImportingConstructor]
        //public FirstPluginWorker(ILogger logger)
        //{
        //    this.logger = logger;
        //}

        public string DoWork(string input)
        {
            Logger.Log($"{nameof(FirstPluginWorker)} is using ILogger");
            return $"First plugin at work: {input}";
        }
    }
}
