using MediatR;
using ProductApi.Application.Dtos;

namespace ProductApi.Application.Products.Queries
{
    public class DashboardQuery : IRequest<IEnumerable<DashboardDto>>
    {

    }
}
