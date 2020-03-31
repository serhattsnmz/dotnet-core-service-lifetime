using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestServices.Services;

namespace TestServices.Repository
{
    public class SingletonRepo1
    {
        private readonly SingletonService singleton;
        // private readonly ScopeService scope;
        private readonly TransientService transient;

        public SingletonRepo1(SingletonService singleton, TransientService transient)
        {
            this.singleton = singleton;
            this.transient = transient;
        }

        public void WriteInfo1()
        {
            Console.WriteLine(">>>>>");
            Console.WriteLine(">>>>> Write Function | SingletonRepo 1 | Function 1");
            singleton.WriteInfo();
            transient.WriteInfo();
        }

        public void WriteInfo2()
        {
            Console.WriteLine(">>>>>");
            Console.WriteLine(">>>>> Write Function | SingletonRepo 1 | Function 2");
            singleton.WriteInfo();
            transient.WriteInfo();
        }
    }
}
