using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FortuneSender.BLL.Interfaces;

namespace FortuneSender.Controllers
{
   public class FortuneController : Controller
   {
      private readonly IFortuneService _fortuneService;

      public FortuneController(IFortuneService fortuneService)
      {
         _fortuneService = fortuneService;
      }

      [HttpGet]
      public ActionResult Index()
      {
         return View();
      }

      [HttpGet]
      public ActionResult SendFortuneMessage()
      {
         var message = _fortuneService.ConfigureAndSendFortuneMessage();

         return View("Index", message);
      }
   }
}