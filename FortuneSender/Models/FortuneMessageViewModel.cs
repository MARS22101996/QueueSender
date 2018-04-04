using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FortuneSender.Models
{
   public class FortuneMessageViewModel
   {
      public int Id { get; set; }

      public string Topic { get; set; }

      public string Body { get; set; }
   }
}