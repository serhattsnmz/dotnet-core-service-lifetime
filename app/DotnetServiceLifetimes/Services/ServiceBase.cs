using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestServices.Services
{
    public abstract class ServiceBase
    {
        protected readonly Guid serviceID;

        public ServiceBase()
        {
            serviceID = Guid.NewGuid();
            Console.WriteLine($">>>>> {serviceID} | {this.GetType().Name} | CREATED");
        }

        public void WriteInfo()
        {
            Console.WriteLine($">>>>> {serviceID} | {this.GetType().Name} | INFO!");
        }
    }
}