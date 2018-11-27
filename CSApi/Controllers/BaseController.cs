using CSApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CSApi.Controllers
{
    [Authorize]
    public class BaseController : ApiController
    {
        public ServiceProvider Service;
        public BaseController()
        {
            Service = new ServiceProvider();
        }
    }
}