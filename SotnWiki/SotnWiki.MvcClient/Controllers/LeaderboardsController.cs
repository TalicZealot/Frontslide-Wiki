using Bytes2you.Validation;
using Newtonsoft.Json;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Models;
using SotnWiki.MvcClient.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SotnWiki.MvcClient.Controllers
{
    public class LeaderboardsController : Controller
    {
        public ActionResult Leaderboards()
        {
            return View();
        }
    }
}