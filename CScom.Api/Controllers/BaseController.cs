using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CScom.Core.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CScom.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Base")]
    public class BaseController : Controller
    {
        protected IServiceWrapper _serviceWrapper;

        public BaseController(IServiceWrapper serviceWrapper)
        {
            this._serviceWrapper = serviceWrapper;
        }
    }
}