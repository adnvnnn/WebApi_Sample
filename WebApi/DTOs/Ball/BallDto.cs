using AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.DTOs.Color;
using WebApi.DTOs.Model;
using WebApi.Entities;

namespace WebApi.DTOs.Ball
{
    public class BallDto
    {
        public string Name { get; set; } = string.Empty;

        public string? Model { get; set; }

        public string? Color { get; set; }
    
    }
}
