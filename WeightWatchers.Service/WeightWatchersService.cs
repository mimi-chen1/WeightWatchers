using AutoMapper;
//using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WeightWatchers.core.DTO;
using WeightWatchers.core.Interface.BAL;
using WeightWatchers.core.Interface.DAL;
using WeightWatchers.core.Response;
using WeightWatchers.data.Model;

namespace WeightWatchers.Service
{
    public class WeightWatchersService : IWeightWatchersService
    {
        readonly IWeightWatchersRepository _weightWatchersRepository;
        readonly IMapper _mapper;
        public WeightWatchersService(IWeightWatchersRepository weightWatchersRepository, IMapper mapper)
        {
            _weightWatchersRepository = weightWatchersRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponseGeneral<bool>> Post(SubscriberDTO subscriber)
        {
            Subscriber subscriber1 = _mapper.Map<Subscriber>(subscriber);
            BaseResponseGeneral<bool> responseGeneral = new BaseResponseGeneral<bool>();
            double height = subscriber.Height;
            try
            {
                if (_weightWatchersRepository.ExsitEmail(subscriber1.Email))
                {
                    responseGeneral.Succsed = false;
                    responseGeneral.message = "Email is alreay exsit";
                    return responseGeneral;

                }
                else
                    return await _weightWatchersRepository.Post(subscriber1, height);
            }
            catch (Exception ex)
            {
                throw new Exception("subscriber failed");
            }
        }
        public async Task<BaseResponseGeneral<int?>> Login(string email, string password)
        {
            BaseResponseGeneral<int?> responseGeneral = new BaseResponseGeneral<int?>();
            if (!IsPasswordValid(password))
            {
                responseGeneral.Data = null;
                responseGeneral.Succsed = false;
                responseGeneral.message = "The password isnt valid";
                return responseGeneral;
            }
            if (!IsEmailValid(email))
            {

                responseGeneral.Data = null;
                responseGeneral.Succsed = false;
                responseGeneral.message = "The email isnt valid";
                return responseGeneral;
            }

            return await _weightWatchersRepository.Login(email, password);


        }
        public bool IsEmailValid(string email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);

            }
            catch (FormatException)
            {
                return false;
                
            }
            return true;

        }
        public bool IsPasswordValid(string password)
        {
            if (password == null || password.Length < 6 || password.Length > 9)
                return false;
            return true;
           
        }
        public async Task<BaseResponseGeneral<SubscriberCardResponse>> GetCardById(int id)
        {
            BaseResponseGeneral <SubscriberCardResponse> responseGeneral = new BaseResponseGeneral<SubscriberCardResponse>();
            if (!_weightWatchersRepository.IsExsitCard(id))
            {
                
                responseGeneral.Succsed=false;
                responseGeneral.message = "Card isnt exsit";
                return responseGeneral;

            }
            return await _weightWatchersRepository.GetCardById(id);


        }

    }
}

