using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.Ball;
using WebApi.Entities;

namespace WebApi.Mapping
{
    public class BallMapping: Profile
    {
        public BallMapping()
        {
            CreateMap<BallTbl, BallDto>()
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.ColorTbl.Color))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.ModelTbl.Model));
            CreateMap<ActionResult<BallDto>, BallTbl>();

            CreateMap<PostBallDto, BallTbl>()
                .ForMember(dest => dest.FkColorId, opt => opt.MapFrom(src => src.FkColorId))
                .ForMember(dest => dest.FkModelId, opt => opt.MapFrom(src => src.FkModelId));
            CreateMap<BallTbl, PostBallDto>()
                .ForMember(dest => dest.FkColorId, opt => opt.MapFrom(src => src.FkColorId))
                .ForMember(dest => dest.FkModelId, opt => opt.MapFrom(src => src.FkModelId));


            CreateMap<BallSingleDto, BallTbl>();
            CreateMap<BallTbl, BallSingleDto>();


            CreateMap<PutBallDto, BallTbl>();

            CreateMap<BallTbl, PatchBallDto>();
            CreateMap<PatchBallDto, BallTbl>();
            //CreateMap<PostBallDto, BallDto>();

            //CreateMap<BallDto, BallTbl>();

            //CreateMap<IEnumerable<BallDto>, BallTbl>();


        }
    }
}
