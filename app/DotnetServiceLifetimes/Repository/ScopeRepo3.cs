using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestServices.Services;

namespace TestServices.Repository
{
    public class ScopeRepo3
    {
        private readonly IServiceProvider serviceProvider;

        public ScopeRepo3(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void WriteInfo1()
        {
            Console.WriteLine(">>>>>");
            Console.WriteLine(">>>>> Write Function | ScopeRepo 3 | Function 1");

            var singleton = serviceProvider.GetRequiredService<SingletonService>();
            var scope = serviceProvider.GetRequiredService<ScopeService>();
            var transient = serviceProvider.GetRequiredService<TransientService>();

            singleton.WriteInfo();
            scope.WriteInfo();
            transient.WriteInfo();
        }

        public void WriteInfo2()
        {
            Console.WriteLine(">>>>>");
            Console.WriteLine(">>>>> Write Function | ScopeRepo 3 | Function 2");

            var singleton = serviceProvider.GetRequiredService<SingletonService>();
            var scope = serviceProvider.GetRequiredService<ScopeService>();
            var transient = serviceProvider.GetRequiredService<TransientService>();

            singleton.WriteInfo();
            scope.WriteInfo();
            transient.WriteInfo();
        }
    }
}
