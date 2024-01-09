using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.Ball;
using WebApi.DTOs.Base;
using WebApi.Entities;
using WebApi.Repositories.Ball;
using WebApi.Repositories.Generic;

namespace WebApi.Controllers
{
    [Route("api/base/[controller]")]
    [ApiController]
    public class BaseController<T,TSingle,TPost,TPut> : ControllerBase where T : SeedEntity where TPut : SeedPut
    {
        private readonly IGenericRepository<T> _context;
        private readonly ILogger<BaseController<T, TSingle, TPost, TPut>> _logger;
        private readonly IMapper _mapper;

        public BaseController(IGenericRepository<T> context, ILogger<BaseController<T, TSingle, TPost, TPut>> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll(bool eager = false)
        {
            try
            {
                if (!_context.Exist())
                {
                    _logger.LogInformation("Empty value returned");

                    return NoContent();
                }

                var x = await _context.GetAllAsync(eager);

                _logger.LogInformation($"All Data in {x.GetType()} table returned");

                if (!eager)
                {
                    return Ok(_mapper.Map<IEnumerable<TSingle>>(x));
                }

                return Ok(_mapper.Map<IEnumerable<T>>(x));
            }
            catch (Exception e)
            {
                _logger.LogCritical(message: "Error from data base", exception: e);

                return StatusCode(500, "Server Error");
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id, bool eager = false)
        {
            try
            {
                if (!_context.Exist(x => x.Id == Id))
                {
                    _logger.LogWarning($"Invalid Id Entered => {Id}");

                    return NotFound();
                }

                var x = await _context.GetAsync(x => x.Id == Id, eager);

                _logger.LogInformation($"{x.Id} with Id = {x.Id} returned");

                if (!eager)
                {
                    return Ok(_mapper.Map<TSingle>(x));
                }
                return Ok(_mapper.Map<T>(x));

            }
            catch (Exception e)
            {
                _logger.LogCritical($"Error in data base to 'get' => Id = {Id}", e);

                return StatusCode(500, "Server Error");
            }

        }



        [HttpPost]
        public async Task<IActionResult> Post(TPost tPost)
        {
            try
            {
                var x = _mapper.Map<T>(tPost);

                _context.PostAsync(x);

                if (!ModelState.IsValid)
                {
                    _logger.LogCritical($"Invalid Data => {x.Id}");

                    return BadRequest();
                }

                if (!await _context.SaveChangesAsync())
                {
                    _logger.LogWarning("Data base doesn't SaveChanges");

                    throw new Exception();
                }


                _logger.LogInformation($"Data Inserted to {x.GetType()}");

                return NoContent();
                //var retVal = _mapper.Map<PostBallDto>(x);

                //_logger.LogInformation("'get' inserted data");

                //return CreatedAtAction("Get",
                //    new
                //    {
                //        ballId = x.Id,
                //        eager = true
                //    },
                //    retVal);
            }
            catch (Exception e)
            {

                _logger.LogCritical($"Error in data base to 'insert' => name ", e);

                return StatusCode(500, "Server Error");
            }


        }

        [HttpPut]
        public async Task<IActionResult> Put(TPut tPut)
        {

            try
            {
                if (!_context.Exist(x => x.Id == tPut.Id))
                {
                    _logger.LogWarning($"Invalid Id Entered => {tPut.Id}");

                    return NotFound();
                }

                var ball = await _context.GetAsync(x => x.Id == tPut.Id);

                var mappedBall = _mapper.Map(tPut, ball);

                _context.PutAsync(mappedBall);

                if (!ModelState.IsValid)
                {

                    _logger.LogCritical($"Invalid Data => {tPut.Id}");

                    return BadRequest(ModelState);
                }

                if (!await _context.SaveChangesAsync())
                {
                    _logger.LogWarning("Data base doesn't SaveChanges");

                    throw new Exception();
                }

                _logger.LogInformation($"Data id ={tPut.Id} 'updated' in {tPut.GetType()}");

                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogCritical($"Error in data base to 'put'  Id = {tPut.Id}", e);

                return StatusCode(500, "Server Error");
            }
        }


        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {

            try
            {
                if (!_context.Exist(x => x.Id == Id))
                {
                    _logger.LogWarning($"Invalid Id Entered => {Id}");

                    return NotFound();
                }

                _context.Delete(Id);

                if (!await _context.SaveChangesAsync())
                {
                    _logger.LogWarning("Data base doesn't SaveChanges");

                    throw new Exception();
                }

                _logger.LogInformation($"Data id ={Id} has been 'delete'");


                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogCritical($"Error in data base to 'patch'  Id = {Id}", e);

                return StatusCode(500, "Server Error");
            }
        }

    }
}
