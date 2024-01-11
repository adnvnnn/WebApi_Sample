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

    }
}
