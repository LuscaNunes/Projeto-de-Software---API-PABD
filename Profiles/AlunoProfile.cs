using AutoMapper;
using Trabalho_Api.Dtos;
using Trabalho_Api.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Trabalho_Api.Profiles
{
    public class AlunoProfile : Profile
    {
        public AlunoProfile()
        {
            CreateMap<AlunoCreateDto, Aluno>()
                .ForMember(dest => dest.NomeCompleto, opt => opt.MapFrom(src => src.NomeCompleto))
                .ForMember(dest => dest.Idade, opt => opt.MapFrom(src => src.Idade))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf))
                .ForMember(dest => dest.NivelInicial, opt => opt.MapFrom(src => src.NivelInicial))
                .ForMember(dest => dest.DataMatricula, opt => opt.Ignore()) 
                .ForMember(dest => dest.Email, opt => opt.Ignore()); 

           
            CreateMap<Aluno, AlunoResponseDto>();

            CreateMap<AlunoUpdateDto, Aluno>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}