using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestServices.Services;

namespace TestServices.Repository
{
    public class ScopeRepo1
    {
        private readonly SingletonService singleton;
        private readonly ScopeService scope;
        private readonly TransientService transient;

        public ScopeRepo1(SingletonService singleton, ScopeService scope, TransientService transient)
        {
            this.singleton = singleton;
            this.scope = scope;
            this.transient = transient;
        }

        public void WriteInfo1()
        {
            Console.WriteLine(">>>>>");
            Console.WriteLine(">>>>> Write Function | ScopeRepo 1 | Function 1");
            singleton.WriteInfo();
            scope.WriteInfo();
            transient.WriteInfo();
        }

        public void WriteInfo2()
        {
            Console.WriteLine(">>>>>");
            Console.WriteLine(">>>>> Write Function | ScopeRepo 1 | Function 2");
            singleton.WriteInfo();
            scope.WriteInfo();
            transient.WriteInfo();
        }
    }
}
