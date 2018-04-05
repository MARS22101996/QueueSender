using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FortuneSender.BLL.Dto;
using FortuneSender.BLL.Interfaces;
using FortuneSender.DAL.Entities;
using FortuneSender.DAL.Interfaces;

namespace FortuneSender.BLL.Services
{
   public class FortuneService : IFortuneService
   {
      private readonly IQueueRepository _queueRepository;
      private readonly IMapper _mapper;
      private List<FortuneMessage> _listOFortuneMessages;

      public FortuneService(
         IQueueRepository queueRepository,
         IMapper mapper)
      {
         _queueRepository = queueRepository;
         _mapper = mapper;
         InitializeMessages();
      }

      public FortuneMessageDto ConfigureAndSendFortuneMessage()
      {
         var fortuneMessage = GetFortuneMessage();

         _queueRepository.Send(fortuneMessage);

         var fortuneMessageDto = _mapper.Map<FortuneMessageDto>(fortuneMessage);

         return fortuneMessageDto;
      }

      private FortuneMessage GetFortuneMessage()
      {
         var randomNumber = GenerateRandomNumber();

         var message = _listOFortuneMessages.FirstOrDefault(x => x.Id == randomNumber);

         return message;
      }

      private int GenerateRandomNumber()
      {
         var rnd = new Random();

         var randomNumber = rnd.Next(1, 4);
         return randomNumber;
      }

      private void InitializeMessages()
      {
         _listOFortuneMessages = new List<FortuneMessage>
         {
            new FortuneMessage { Id = 1, Topic = "Love", Body = "You will be happy in love" },
            new FortuneMessage { Id = 2, Topic = "Love", Body = "You will be divorsed" },
            new FortuneMessage { Id = 3, Topic = "Work", Body = "You will have well-paid work" },
            new FortuneMessage { Id = 4, Topic = "Work", Body = "You will have bad-paid work" }
         };
      }
   }
}
