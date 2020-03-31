using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestServices.Services;

namespace TestServices.Repository
{
    public class SingletonRepo2
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public SingletonRepo2(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public void WriteInfo1()
        {
            Console.WriteLine(">>>>>");
            Console.WriteLine(">>>>> Write Function | SingletonRepo 2 | Function 1");

            var singleton = (SingletonService)httpContextAccessor.HttpContext.RequestServices.GetService(typeof(SingletonService));
            var scope = (ScopeService)httpContextAccessor.HttpContext.RequestServices.GetService(typeof(ScopeService));
            var transient = (TransientService)httpContextAccessor.HttpContext.RequestServices.GetService(typeof(TransientService));

            singleton.WriteInfo();
            scope.WriteInfo();
            transient.WriteInfo();
        }

        public void WriteInfo2()
        {
            Console.WriteLine(">>>>>");
            Console.WriteLine(">>>>> Write Function | SingletonRepo 2 | Function 2");

            var singleton = (SingletonService)httpContextAccessor.HttpContext.RequestServices.GetService(typeof(SingletonService));
            var scope = (ScopeService)httpContextAccessor.HttpContext.RequestServices.GetService(typeof(ScopeService));
            var transient = (TransientService)httpContextAccessor.HttpContext.RequestServices.GetService(typeof(TransientService));

            singleton.WriteInfo();
            scope.WriteInfo();
            transient.WriteInfo();
        }
    }
}
