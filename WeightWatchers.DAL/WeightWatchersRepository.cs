using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightWatchers.core.Interface.DAL;
using WeightWatchers.core.Response;
using WeightWatchers.data;
using WeightWatchers.data.Entites;
using WeightWatchers.data.Model;

namespace WeightWatchers.DAL
{
    public class WeightWatchersRepository: IWeightWatchersRepository
    {
        readonly WeightWatchersContex _weightWatchersContex;
        public WeightWatchersRepository(WeightWatchersContex weightWatchersContex)
        {
            _weightWatchersContex = weightWatchersContex;
        }
        public bool ExsitEmail(string email)
        {
           if( _weightWatchersContex.Subscribers.Where(t=>t.Email == email).FirstOrDefault()==null)
                return false;
           return true;
        }
        public bool IsExsitCard(int id)
        {
            if(_weightWatchersContex.Cards.Where(t=>t.Id==id).FirstOrDefault()==null)
                return false; 
            return true;
        }

        public async Task<BaseResponseGeneral<bool>> Post(Subscriber subscriber, double height)
        {
            BaseResponseGeneral<bool> response=new BaseResponseGeneral<bool>(); 
            try
            {
              var newsubscriber = _weightWatchersContex.Subscribers.Add(subscriber);
                _weightWatchersContex.SaveChanges();
                Card card = new Card()
                {
                    SubscriberId = subscriber.Id,
                    OpenDate = DateTime.Now,
                    BMI = 0,
                    Height = height,
                    Weight = 0

                };

                _weightWatchersContex.Cards.Add(card);
                _weightWatchersContex.SaveChanges();
                response.message = "Subscriber succeed";
                response.Succsed=true;
                return response;
            }
            catch (Exception ex) 
            {
                throw new Exception(" Subscriber failed");
            }
            
        }
        public async Task<BaseResponseGeneral<int?>> Login(string email, string password)
        {
            BaseResponseGeneral<int?> baseResponse = new BaseResponseGeneral<int?>();
            Subscriber subscriber = _weightWatchersContex.Subscribers.Where(t => t.Email == email && t.Password == password).FirstOrDefault();
            int id = 0;
            if (subscriber != null)
            {
               id = subscriber.Id;
            }
            
            Card card = _weightWatchersContex.Cards.Where(t =>t.SubscriberId == id).FirstOrDefault();
            if(card == null)
            {
                baseResponse.Data = null;
                baseResponse.Succsed=false;
                baseResponse.message = "You arent available enter";
             
            }
            else
            {
                baseResponse.Data = card.Id;
                baseResponse.Succsed=true;
                baseResponse.message = "Card is exsit";
               
            }
             return baseResponse;

        }
          public async  Task<BaseResponseGeneral<SubscriberCardResponse>> GetCardById(int id)
        {
            BaseResponseGeneral<SubscriberCardResponse> baseResponseGeneral=new BaseResponseGeneral<SubscriberCardResponse>();
            Card card = _weightWatchersContex.Cards.Where(c => c.Id == id).FirstOrDefault();
            Subscriber subscriber = _weightWatchersContex.Subscribers.Where(subscriber => subscriber.Id == id).FirstOrDefault();
            baseResponseGeneral.Data = new SubscriberCardResponse();
           baseResponseGeneral.Data.id = subscriber.Id;
            baseResponseGeneral.Data.FirstName = subscriber.FirstName;
            baseResponseGeneral.Data.LastName = subscriber.LastName;
            baseResponseGeneral.Data.BMI = card.BMI;
            baseResponseGeneral.Data.Weight = card.Weight;
            baseResponseGeneral.Data.Height = card.Height;
            baseResponseGeneral.Succsed = true;
            baseResponseGeneral.message = "card is find";
            return baseResponseGeneral;
        }

    }
}
