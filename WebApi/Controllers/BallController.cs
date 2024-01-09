using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.Ball;
using WebApi.Repositories.Ball;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using WebApi.Entities;
using System.Net;
using Microsoft.Extensions.Logging;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BallController : BaseController<BallTbl,BallSingleDto,PostBallDto,PutBallDto>
    {
        private readonly IBallRepository _context;
        private readonly ILogger<BallController> _logger;
        private readonly IMapper _mapper;

        public BallController(IBallRepository context, ILogger<BallController> logger, IMapper mapper) :base(context, logger, mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }



        [HttpPatch("{ballId}")]
        public async Task<ActionResult> PatchBall(int ballId, JsonPatchDocument<PatchBallDto> patchDocument)
        {
            try
            {
                if (!_context.Exist(x => x.Id == ballId))
                {
                    _logger.LogWarning($"Invalid Id Entered => {ballId}");

                    return NotFound();
                }

                var ball = await _context.GetAsync(x => x.Id == ballId);

                var ballToPatch = _mapper.Map<PatchBallDto>(ball);

                patchDocument.ApplyTo(ballToPatch, ModelState);

                if (!ModelState.IsValid)
                {
                    _logger.LogCritical($"Invalid Data => {ballId}");

                    return BadRequest(ModelState);
                }

                if (!TryValidateModel(ballToPatch))
                {
                    _logger.LogCritical($"Invalid data for patch => {ballId}");

                    return BadRequest(ModelState);
                }

                _mapper.Map(ballToPatch, ball);

                if (!await _context.SaveChangesAsync())
                {
                    _logger.LogWarning("Data base doesn't SaveChanges");

                    throw new Exception();
                }

                _logger.LogInformation($"Data id ={ballId} 'patched'");

                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogCritical($"Error in data base to 'patch'  Id = {ballId}", e);

                return StatusCode(500, "Server Error");
            }
        }

    }
}
