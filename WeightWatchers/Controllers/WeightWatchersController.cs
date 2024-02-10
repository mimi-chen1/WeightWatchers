using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeightWatchers.core.DTO;
using WeightWatchers.core.Interface.BAL;
using WeightWatchers.core.Response;
using WeightWatchers.data.Entites;

namespace WeightWatchers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightWatchersController : ControllerBase
    {
        readonly IWeightWatchersService _weightWatchersService;
        public WeightWatchersController(IWeightWatchersService weightWatchersService)
        {
            _weightWatchersService= weightWatchersService;
        }
        [HttpPost]

        public async Task<ActionResult<BaseResponseGeneral<bool>>> Post(SubscriberDTO subscriber) 
        {
            BaseResponseGeneral <bool> baseResponseGeneral = new BaseResponseGeneral<bool>();
            baseResponseGeneral=await _weightWatchersService.Post(subscriber);
            if (!baseResponseGeneral.Succsed)
                return NotFound(baseResponseGeneral);
            return Ok(baseResponseGeneral);
           
        }
        
        [HttpGet]
       [Route("GetById")]
        public async Task<ActionResult<BaseResponseGeneral<int?>>> GetCardById(int id)
        {
            BaseResponseGeneral<SubscriberCardResponse> response = new BaseResponseGeneral<SubscriberCardResponse>();
            response=await _weightWatchersService.GetCardById(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);    
            
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<BaseResponseGeneral<int?>>> Login(string email,string password)
        {
            BaseResponseGeneral<int?> baseResponse = new BaseResponseGeneral<int?>();
            baseResponse=await _weightWatchersService.Login(email,password);
           if(baseResponse.Data == null)
            {
                return Unauthorized(baseResponse);
            }
           
            
           return Ok(baseResponse);

        }



    }
}
