using AutoMapper;
using WebApi.DTOs.Color;
using WebApi.DTOs.Model;
using WebApi.Entities;

namespace WebApi.Mapping
{
    public class ModelMapping :Profile
    {
        public ModelMapping()
        {
            CreateMap<ModelTbl, ModelDto>();

            CreateMap<ModelDto, ModelTbl>();

            CreateMap<ModelTbl, PutModelDto>();

            CreateMap<PutModelDto, ModelTbl>();


        }
    }
}
