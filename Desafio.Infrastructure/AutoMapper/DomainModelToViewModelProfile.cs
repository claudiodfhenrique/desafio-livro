using AutoMapper;
using Desafio.Domain.Entities;
using Desafio.Domain.Views;
using Desafio.Infrastructure.Queries.ViewModel;

namespace Desafio.Infrastructure.AutoMapper
{
    public class DomainModelToViewModelProfile : Profile
    {
        public DomainModelToViewModelProfile()
        {
            CreateMap<Assunto, AssuntoViewModel>()
                .ReverseMap();

            CreateMap<Autor, AutorViewModel>()
                .ReverseMap();

            CreateMap<Livro, LivroViewModel>();

            CreateMap<LivroAutor, LivroAutorViewModel>();

            CreateMap<VwLivrosPorAutor, VwLivrosPorAutorViewModel>();
        }
    }
}
