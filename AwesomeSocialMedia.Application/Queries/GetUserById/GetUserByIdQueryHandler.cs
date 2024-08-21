using AwesomeSocialMedia.Application.Models;
using AwesomeSocialMedia.Users.Core.Repositories;

using MediatR;

namespace AwesomeSocialMedia.Application.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, BaseResult<GetUserByIdViewModel>>
{
    private readonly IUserRepository _userRepository;   
    public GetUserByIdQueryHandler(IUserRepository userRepository) 
    {
        _userRepository = userRepository;
    }
    public async Task<BaseResult<GetUserByIdViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);
        
        var viewModel = new GetUserByIdViewModel(user);

        return new BaseResult<GetUserByIdViewModel>(viewModel);
    }
}
