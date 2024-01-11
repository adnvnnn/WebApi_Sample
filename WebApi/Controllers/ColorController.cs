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


    }
}
