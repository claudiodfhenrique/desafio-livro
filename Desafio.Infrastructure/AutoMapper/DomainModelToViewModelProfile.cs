using AutoMapper;
using Desafio.Application.Queries.Assuntos.ViewModel;
using Desafio.Domain.Entities;

namespace Desafio.Infrastructure.AutoMapper
{
    public class DomainModelToViewModelProfile : Profile
    {
        public DomainModelToViewModelProfile()
        {
            CreateMap<Assunto, AssuntoViewModel>()
                .ReverseMap();
        }
    }
}
