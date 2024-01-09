using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.Ball;
using WebApi.DTOs.Color;
using WebApi.Entities;
using WebApi.Repositories.Ball;
using WebApi.Repositories.Color;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : BaseController<ColorTbl, ColorDto, ColorDto, PutColorDto>
    {
        private readonly IColorRepository _context;
        private readonly ILogger<ColorController> _logger;
        private readonly IMapper _mapper;

        public ColorController(IColorRepository context, ILogger<ColorController> logger, IMapper mapper) :base(context,logger,mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }


        //[HttpGet]
        //public async Task<IActionResult> GetColors()
        //{


        //    try
        //    {
        //        if (!_context.Exist())
        //        {
        //            _logger.LogInformation("Empty value returned");

        //            return NoContent();
        //        }

        //        var allColors = await _context.GetAllAsync();

        //        _logger.LogInformation($"All Data in {allColors.GetType()} table returned");

        //        return Ok(_mapper.Map<IEnumerable<ColorDto>>(allColors));
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogCritical(message: "Error from data base", exception: e);

        //        return StatusCode(500, "Server Error");
        //    }
        //}


        //[HttpGet("{colorId}", Name = "GetColor")]
        //public async Task<IActionResult> GetColor(int colorId)
        //{
        //    try
        //    {
        //        if (!_context.Exist(x => x.Id == colorId))
        //        {
        //            _logger.LogWarning($"Invalid Id Entered => {colorId}");

        //            return NotFound();
        //        }

        //        var color = await _context.GetAsync(x => x.Id == colorId);

        //        _logger.LogInformation($"{color.Color} with Id = {color.Id} returned");

        //        return Ok(_mapper.Map<ColorDto>(color));

        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogCritical($"Error in data base to 'get' => Id = {colorId}", e);

        //        return StatusCode(500, "Server Error");
        //    }

        //}



        //[HttpPost]
        //public async Task<IActionResult> PostColor(ColorDto colorDto)
        //{
        //    try
        //    {
        //        var colorTbl = _mapper.Map<ColorTbl>(colorDto);

        //        _context.PostAsync(colorTbl);

        //        if (!ModelState.IsValid)
        //        {
        //            _logger.LogCritical($"Invalid Data => {colorDto.Color}");

        //            return BadRequest();
        //        }

        //        if (!await _context.SaveChangesAsync())
        //        {
        //            _logger.LogWarning("Data base doesn't SaveChanges");

        //            throw new Exception();
        //        }


        //        _logger.LogInformation($"Data Inserted to {colorTbl.GetType()}");

        //        var retVal = _mapper.Map<ColorDto>(colorTbl);

        //        _logger.LogInformation("'get' inserted data");

        //        return CreatedAtAction("GetColor",
        //            new
        //            {
        //                ballId = colorTbl.Id,
        //                withRelations = true
        //            },
        //            retVal);
        //    }
        //    catch (Exception e)
        //    {

        //        _logger.LogCritical($"Error in data base to 'insert' => name = {colorDto.Color}", e);

        //        return StatusCode(500, "Server Error");
        //    }


        //}


        //[HttpPut]
        //public async Task<IActionResult> PutColor(PutColorDto putColorDto)
        //{
        //    try
        //    {
        //        if (!_context.Exist(x => x.Id == putColorDto.Id))
        //        {
        //            _logger.LogWarning($"Invalid Id Entered => {putColorDto.Id}");

        //            return NotFound();
        //        }

        //        var color = await _context.GetAsync(x => x.Id == putColorDto.Id);

        //        var mappedColor = _mapper.Map(putColorDto, color);

        //        _context.PutAsync(mappedColor);

        //        if (!ModelState.IsValid)
        //        {

        //            _logger.LogCritical($"Invalid Data => {putColorDto.Color}");

        //            return BadRequest(ModelState);
        //        }

        //        if (!await _context.SaveChangesAsync())
        //        {
        //            _logger.LogWarning("Data base doesn't SaveChanges");

        //            throw new Exception();
        //        }

        //        _logger.LogInformation($"Data id ={putColorDto.Id} 'updated' in {putColorDto.GetType()}");

        //        return NoContent();
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogCritical($"Error in data base to 'put'  Id = {putColorDto.Color}", e);

        //        return StatusCode(500, "Server Error");
        //    }
        //}


        //[HttpDelete("{colorId}")]
        //public async Task<ActionResult> DeleteColor(int colorId)
        //{

        //    try
        //    {
        //        if (!_context.Exist(x => x.Id == colorId))
        //        {
        //            _logger.LogWarning($"Invalid Id Entered => {colorId}");

        //            return NotFound();
        //        }
                
        //        _context.Delete(colorId);

        //        if (!await _context.SaveChangesAsync())
        //        {
        //            _logger.LogWarning("Data base doesn't SaveChanges");

        //            throw new Exception();
        //        }

        //        _logger.LogInformation($"Data id ={colorId} has been 'delete'");

        //        return NoContent();
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogCritical($"Error in data base to 'patch'  Id = {colorId}", e);

        //        return StatusCode(500, "Server Error");
        //    }
        //}

    }
}
