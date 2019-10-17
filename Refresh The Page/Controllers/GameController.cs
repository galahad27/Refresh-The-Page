using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Refresh_The_Page.Controllers
{
    public class GameController : ApiController
    {
        public string[] Get()
        {
            return new string[] { "Hello", "World" };
        }
    }
}
