using AwesomeSocialMedia.Application.Models;
using AwesomeSocialMedia.Users.Core.Repositories;

using MediatR;

namespace AwesomeSocialMedia.Application.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, BaseResult>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public async Task<BaseResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);
        user.Update(
                request.DisplayName, 
                request.Header, 
                request.Description, 
                request.Location.ToValueObject(), 
                request.Contact.ToValueObject());

        await _userRepository.UpdateAsync(user);

        return new BaseResult();
    }
}
