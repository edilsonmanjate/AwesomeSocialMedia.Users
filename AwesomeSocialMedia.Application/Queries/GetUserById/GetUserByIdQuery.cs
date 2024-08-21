using AwesomeSocialMedia.Application.Models;

using MediatR;

namespace AwesomeSocialMedia.Application.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<BaseResult<GetUserByIdViewModel>>
{
    public GetUserByIdQuery(Guid id)
    {
        Id= id;
    }
    public Guid Id { get; private set; }


}
