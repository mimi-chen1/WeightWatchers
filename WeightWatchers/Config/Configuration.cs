using AutoMapper;
using WeightWatchers.core.Interface.BAL;
using WeightWatchers.core.Interface.DAL;
using WeightWatchers.DAL;
using WeightWatchers.Service;

namespace WeightWatchers.Config
{
    public static  class Configuration
    {
        public static void ConfigurationService(this IServiceCollection services)
        {
            services.AddScoped<IWeightWatchersRepository, WeightWatchersRepository>();
            services.AddScoped<IWeightWatchersService, WeightWatchersService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new WeightWatchersProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

    }
}
