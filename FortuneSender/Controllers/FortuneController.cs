using System.Web.Mvc;
using AutoMapper;
using FortuneSender.BLL.Interfaces;
using FortuneSender.ViewModels;

namespace FortuneSender.Controllers
{
   public class FortuneController : Controller
   {
      private readonly IFortuneService _fortuneService;
      private readonly IMapper _mapper;

      public FortuneController(
         IFortuneService fortuneService,
         IMapper mapper)
      {
         _fortuneService = fortuneService;
         _mapper = mapper;
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

         var messageViewModel = _mapper.Map<FortuneMessageViewModel>(message);

         return View("Index", messageViewModel);
      }
   }
}