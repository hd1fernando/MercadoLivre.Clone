﻿using AutoMapper;
using MercadoLivre.Clone.Api.Dtos;
using MercadoLivre.Clone.Business.Commands;

namespace MercadoLivre.Clone.Api.Mapper;

public class ViewModelToCommandProfile : Profile
{
    public ViewModelToCommandProfile()
    {
        CreateMap<CategoryViewModel, CategoryCommand>();
    }
}