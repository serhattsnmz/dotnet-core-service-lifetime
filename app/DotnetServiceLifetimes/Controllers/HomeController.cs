using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestServices.Repository;
using TestServices.Services;

namespace TestServices.Controllers
{
    public class HomeController : Controller
    {
        private readonly SingletonRepo1 singletonRepo1;
        private readonly SingletonRepo2 singletonRepo2;
        private readonly SingletonRepo3 singletonRepo3;
        private readonly ScopeRepo1 scopeRepo1;
        private readonly ScopeRepo2 scopeRepo2;
        private readonly ScopeRepo3 scopeRepo3;

        public HomeController(
            SingletonRepo1 singletonRepo1,
            SingletonRepo2 singletonRepo2,
            SingletonRepo3 singletonRepo3,
            ScopeRepo1 scopeRepo1,
            ScopeRepo2 scopeRepo2,
            ScopeRepo3 scopeRepo3
            )
        {
            this.singletonRepo1 = singletonRepo1;
            this.singletonRepo2 = singletonRepo2;
            this.singletonRepo3 = singletonRepo3;
            this.scopeRepo1 = scopeRepo1;
            this.scopeRepo2 = scopeRepo2;
            this.scopeRepo3 = scopeRepo3;
        }

        public IActionResult Index()
        {
            scopeRepo1.WriteInfo1();
            scopeRepo1.WriteInfo2();

            scopeRepo2.WriteInfo1();
            scopeRepo2.WriteInfo2();

            scopeRepo3.WriteInfo1();
            scopeRepo3.WriteInfo2();

            singletonRepo1.WriteInfo1();
            singletonRepo1.WriteInfo2();

            singletonRepo2.WriteInfo1();
            singletonRepo2.WriteInfo2();

            singletonRepo3.WriteInfo1();
            singletonRepo3.WriteInfo2();

            return View();
        }
    }
}