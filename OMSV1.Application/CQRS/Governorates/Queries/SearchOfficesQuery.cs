using MediatR;
using OMSV1.Application.Dtos.Governorates;

namespace OMSV1.Application.CQRS.Governorates
{
    public class SearchOfficesQuery : IRequest<List<OfficeCountDto>>
    {
        public int? GovernorateId { get; set; } // Optional GovernorateId
    }
}