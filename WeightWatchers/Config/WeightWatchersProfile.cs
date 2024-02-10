using AutoMapper;
using WeightWatchers.core.DTO;
using WeightWatchers.data.Entites;
using WeightWatchers.data.Model;

namespace WeightWatchers.Config
{
    public class WeightWatchersProfile:Profile
    {
        public WeightWatchersProfile()
        {
            CreateMap<Subscriber, SubscriberDTO>().ForMember(dest => dest.Height, opt => opt.Ignore()).ReverseMap();
            CreateMap<Card, CardDTO>().ReverseMap();
        }
    }
}
