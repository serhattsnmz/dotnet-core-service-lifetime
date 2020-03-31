using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestServices.Services
{
    public class SingletonService : ServiceBase
    {
        ~SingletonService()
        {
            Console.WriteLine($">>>>> {serviceID} | {this.GetType().Name} | Disposed");
        }
    }
}
