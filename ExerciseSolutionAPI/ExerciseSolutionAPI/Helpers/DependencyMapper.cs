using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ExerciseSolutionAPI.Helpers
{
    public class DependencyMapper
    {
        /// <summary>
        /// to register all the serives
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="configuration"></param>
        public static void SetDependencies(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var dependentProjects = configuration.GetSection("DependentProjects").GetChildren().Select(x => x.Value).ToList().Where(x => !string.IsNullOrEmpty(x)).AsEnumerable();
            var assemblies = new List<Assembly>();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            foreach (var dll in dependentProjects)
            {
                assemblies.Add(Assembly.LoadFile($"{path}\\{dll}.dll"));
            }
            serviceCollection.Scan(scan => scan
                        .FromAssemblies(assemblies).AddClasses()
                        .AsImplementedInterfaces()
                        .WithScopedLifetime()
                    );
        }
    }
}
