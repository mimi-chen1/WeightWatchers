using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightWatchers.core.Response;
using WeightWatchers.data.Model;

namespace WeightWatchers.core.Interface.DAL
{
    public  interface IWeightWatchersRepository
    {
        Task<BaseResponseGeneral<bool>> Post(Subscriber subscriber, double height);
        public Task<BaseResponseGeneral<int?>> Login(string email, string password);
        bool ExsitEmail(string email);
        public Task< BaseResponseGeneral<SubscriberCardResponse>> GetCardById(int id);
        public bool IsExsitCard(int id);


    }
}
