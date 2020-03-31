using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestServices.Services;

namespace TestServices.Repository
{
    public class SingletonRepo3
    {
        private readonly IServiceProvider serviceProvider;

        public SingletonRepo3(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void WriteInfo1()
        {
            Console.WriteLine(">>>>>");
            Console.WriteLine(">>>>> Write Function | SingletonRepo 3 | Function 1");

            var singleton = serviceProvider.GetRequiredService<SingletonService>();
            var transient = serviceProvider.GetRequiredService<TransientService>();
            
            // This code create new scope service. Look at logs.
            using (var scopeProvider = serviceProvider.CreateScope())
            {
                var scope = scopeProvider.ServiceProvider.GetRequiredService<ScopeService>();

                singleton.WriteInfo();
                scope.WriteInfo();
                transient.WriteInfo();
            }
        }

        public void WriteInfo2()
        {
            Console.WriteLine(">>>>>");
            Console.WriteLine(">>>>> Write Function | SingletonRepo 3 | Function 2");

            var singleton = serviceProvider.GetRequiredService<SingletonService>();
            var transient = serviceProvider.GetRequiredService<TransientService>();

            // This code create new scope service. Look at logs.
            using (var scopeProvider = serviceProvider.CreateScope())
            {
                var scope = scopeProvider.ServiceProvider.GetRequiredService<ScopeService>();

                singleton.WriteInfo();
                scope.WriteInfo();
                transient.WriteInfo();
            }
        }
    }
}
