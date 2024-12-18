﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using OMSV1.Application.Dtos.Offices;
using OMSV1.Application.Helpers;
using OMSV1.Application.Queries.Offices;
using OMSV1.Domain.Entities.Offices;
using OMSV1.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class GetAllOfficesQueryHandler : IRequestHandler<GetAllOfficesQuery, PagedList<OfficeDto>>
{
    private readonly IGenericRepository<Office> _repository;
    private readonly IMapper _mapper;

    public GetAllOfficesQueryHandler(IGenericRepository<Office> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedList<OfficeDto>> Handle(GetAllOfficesQuery request, CancellationToken cancellationToken)
    {
        // Retrieve the offices as IQueryable
        var officesQuery = _repository.GetAllAsQueryable();

        // Map to OfficeDto using AutoMapper's ProjectTo
        var mappedQuery = officesQuery.ProjectTo<OfficeDto>(_mapper.ConfigurationProvider);

        // Apply pagination
        var pagedOffices = await PagedList<OfficeDto>.CreateAsync(
            mappedQuery,
            request.PaginationParams.PageNumber,
            request.PaginationParams.PageSize
        );

        return pagedOffices;
    }
}