using AutoMapper;
using MercadoLivre.Clone.Api.Dtos;
using MercadoLivre.Clone.Business.Commands;

namespace MercadoLivre.Clone.Api.Mapper;

public class ViewModelToCommand : Profile
{
    public ViewModelToCommand()
    {
        CreateMap<CategoryViewModel, CategoryCommand>();
    }
}
