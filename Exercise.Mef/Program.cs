using Exercise.Mef.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Registration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Mef
{
    [Export]
    class Program : IPartImportsSatisfiedNotification
    {
        private const string _pluginDir = "plugins";

        private static CompositionContainer _container;

        [Import(RequiredCreationPolicy = CreationPolicy.NonShared)]
        PluginHost host;

        static void Main(string[] args)
        {
            // create plugin directory
            EnsureExist(_pluginDir);

            _container = CreateContainer();

            var host1 = new Program();
            _container.ComposeParts(host1);

            var host2 = new Program();
            _container.ComposeParts(host2);

            host1.host.Run("host1");

            Console.WriteLine(Environment.NewLine);

            host2.host.Run("host2");

            // workers are non-shared instances
            Debug.Assert(!host1.host._workers[0].Equals(host2.host._workers[0]));

            Console.ReadLine();
        }

        private static CompositionContainer CreateContainer()
        {
            /// load plugins from <see cref="_pluginDir"/> folder
            DirectoryCatalog dirCatalog = new DirectoryCatalog(_pluginDir);

            var conventions = new RegistrationBuilder();

            /// this exports the <see cref="PluginHost"/> type 
            /// -> you dont have to use the <see cref="ExportAttribute"/> over the <see cref="PluginHost"/> class
            conventions.ForType<PluginHost>().Export();

            // load plugins from the current assembly
            AssemblyCatalog assemblyCat = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly(), conventions);

            // combine these two catalogs
            AggregateCatalog catalog = new AggregateCatalog(assemblyCat, dirCatalog);

            return new CompositionContainer(catalog);
        }

        private static void EnsureExist(string folder)
        {
            if (Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

        public void OnImportsSatisfied()
        {
            Console.WriteLine("Mef is done & you are ready to go" + Environment.NewLine);
        }
    }
}
