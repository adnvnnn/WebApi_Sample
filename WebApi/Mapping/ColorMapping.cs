using AutoMapper;
using WebApi.DTOs.Color;
using WebApi.Entities;

namespace WebApi.Mapping
{
    public class ColorMapping :Profile
    {
        public ColorMapping()
        {
            CreateMap<ColorTbl, ColorDto>();


            CreateMap<ColorDto, ColorTbl>();

            CreateMap<ColorTbl, PutColorDto>();

            CreateMap<PutColorDto, ColorTbl>();


        }
    }
}
