using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using WeightWatchers.core.DTO;
using WeightWatchers.core.Response;

namespace WeightWatchers.core.Interface.BAL
{
    public interface IWeightWatchersService
    {
        Task<BaseResponseGeneral<bool>> Post(SubscriberDTO subscriber);
        public Task<BaseResponseGeneral<SubscriberCardResponse>> GetCardById(int id);
        public bool IsPasswordValid(string password);
        public bool IsEmailValid(string email);
        public Task<BaseResponseGeneral<int?>> Login(string email, string password);
        


    }
}
