using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.Color;
using WebApi.DTOs.Model;
using WebApi.Entities;
using WebApi.Repositories.Color;
using WebApi.Repositories.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : BaseController<ModelTbl,ModelDto, ModelDto,PutModelDto>
    {
        private readonly IModelRepository _context;
        private readonly ILogger<ModelController> _logger;
        private readonly IMapper _mapper;

        public ModelController(IModelRepository context, ILogger<ModelController> logger, IMapper mapper) : base(context,logger, mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }


        //[HttpGet]
        //public async Task<IActionResult> GetModels()
        //{
        //    try
        //    {
        //        if (!_context.Exist())
        //        {
        //            _logger.LogInformation("Empty value returned");

        //            return NoContent();
        //        }

        //        var allModels = await _context.GetAllAsync();

        //        _logger.LogInformation($"All Data in {allModels.GetType()} table returned");

        //        return Ok(_mapper.Map<IEnumerable<ModelDto>>(allModels));

        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogCritical(message: "Error from data base", exception: e);

        //        return StatusCode(500, "Server Error");
        //    }
        //}


        //[HttpGet("{modelId}", Name = "GetModel")]
        //public async Task<IActionResult> GetModel(int modelId)
        //{
        //    try
        //    {
        //        if (!_context.Exist(x => x.Id == modelId))
        //        {
        //            _logger.LogWarning($"Invalid Id Entered => {modelId}");

        //            return NotFound();
        //        }

        //        var model = await _context.GetAsync(x => x.Id == modelId);

        //        _logger.LogInformation($"{model.Model} with Id = {model.Id} returned");

        //        return Ok(_mapper.Map<ModelDto>(model));

        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogCritical($"Error in data base to 'get' => Id = {modelId}", e);

        //        return StatusCode(500, "Server Error");
        //    }

        //}


        //[HttpPost]
        //public async Task<IActionResult> PostModel(ModelDto modelDto)
        //{
        //    try
        //    {
        //        var modelTbl = _mapper.Map<ModelTbl>(modelDto);

        //        _context.PostAsync(modelTbl);

        //        if (!ModelState.IsValid)
        //        {
        //            _logger.LogCritical($"Invalid Data => {modelDto.Model}");

        //            return BadRequest();
        //        }

        //        if (!await _context.SaveChangesAsync())
        //        {
        //            _logger.LogWarning("Data base doesn't SaveChanges");

        //            throw new Exception();
        //        }


        //        _logger.LogInformation($"Data Inserted to {modelTbl.GetType()}");

        //        var retVal = _mapper.Map<ModelDto>(modelTbl);

        //        _logger.LogInformation("'get' inserted data");

        //        return CreatedAtAction("GetModel",
        //            new
        //            {
        //                ballId = modelTbl.Id,
        //                withRelations = true
        //            },
        //            retVal);
        //    }
        //    catch (Exception e)
        //    {

        //        _logger.LogCritical($"Error in data base to 'insert' => name = {modelDto.Model}", e);

        //        return StatusCode(500, "Server Error");
        //    }


        //}


        //[HttpPut]
        //public async Task<IActionResult> PutModel(PutModelDto putModelDto)
        //{
        //    try
        //    {
        //        if (!_context.Exist(x => x.Id == putModelDto.Id))
        //        {
        //            _logger.LogWarning($"Invalid Id Entered => {putModelDto.Id}");

        //            return NotFound();
        //        }

        //        var model = await _context.GetAsync(x => x.Id == putModelDto.Id);

        //        var mappedColor = _mapper.Map(putModelDto, model);

        //        _context.PutAsync(mappedColor);

        //        if (!ModelState.IsValid)
        //        {

        //            _logger.LogCritical($"Invalid Data => {putModelDto.Model}");

        //            return BadRequest(ModelState);
        //        }

        //        if (!await _context.SaveChangesAsync())
        //        {
        //            _logger.LogWarning("Data base doesn't SaveChanges");

        //            throw new Exception();
        //        }

        //        _logger.LogInformation($"Data id ={putModelDto.Id} 'updated' in {putModelDto.GetType()}");

        //        return NoContent();
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogCritical($"Error in data base to 'put'  Id = {putModelDto.Model}", e);

        //        return StatusCode(500, "Server Error");
        //    }
        //}


        //[HttpDelete("{modelId}")]
        //public async Task<ActionResult> DeleteModel(int modelId)
        //{

        //    try
        //    {
        //        if (!_context.Exist(x => x.Id == modelId))
        //        {
        //            _logger.LogWarning($"Invalid Id Entered => {modelId}");

        //            return NotFound();
        //        }

        //        _context.Delete(modelId);

        //        if (!await _context.SaveChangesAsync())
        //        {
        //            _logger.LogWarning("Data base doesn't SaveChanges");

        //            throw new Exception();
        //        }

        //        _logger.LogInformation($"Data id ={modelId} has been 'delete'");

        //        return NoContent();
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogCritical($"Error in data base to 'patch'  Id = {modelId}", e);

        //        return StatusCode(500, "Server Error");
        //    }
        //}
    }
}
