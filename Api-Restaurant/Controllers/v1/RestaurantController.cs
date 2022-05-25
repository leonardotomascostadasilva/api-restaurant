using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Api_Restaurant.Domain.Entities;
using Api_Restaurant.Domain.Enums;
using Api_Restaurant.Models.Request;
using Api_Restaurant.Models.Response;
using Api_Restaurant.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Api_Restaurant.Controllers.v1
{
    [ApiController]
    [Route("v1/[controller]")]
    [Produces("application/json")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(RestaurantRequest), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateRestaurantAsync([FromBody] RestaurantRequest restaurantRequest)
        {
            var result = _restaurantService.InsertRestaurant(restaurantRequest);

            if (result is null)
                return BadRequest();

            return Ok((RestaurantResponse)result);
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(RestaurantRequest), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllRestaurantAsync()
        {
            var result = _restaurantService.GetAllRestaurant();

            if (result is null)
                return BadRequest();

            return Ok(result.Select(r => (RestaurantResponse)r));
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RestaurantRequest), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetRestaurantByIdAsync(string id)
        {
            var result = _restaurantService.GetRestaurantById(id);

            if (result is null)
                return BadRequest();

            return Ok((RestaurantResponse)result);
        }
        
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateRestaurantAsync([FromBody]  RestaurantRequest restaurantRequest)
        {
            var result = _restaurantService.UpdateRestaurant(restaurantRequest);

            if (!result)
                return BadRequest();

            return Ok();
        }
        
        [HttpGet("filter")]
        [ProducesResponseType(typeof(RestaurantRequest), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetRestaurantByFilterAsync([FromQuery] string search)
        {
            var result = await _restaurantService.GetRestaurantFilter(search);

            if (result is null)
                return BadRequest();

            return Ok(result.Select(r => (RestaurantResponse)r));
        }
    }
}