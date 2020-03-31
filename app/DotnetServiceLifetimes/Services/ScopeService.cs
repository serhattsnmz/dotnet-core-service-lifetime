using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestServices.Services
{
    public class ScopeService : ServiceBase
    {
        ~ScopeService()
        {
            Console.WriteLine($">>>>> {serviceID} | {this.GetType().Name} | Disposed");
        }
    }
}
