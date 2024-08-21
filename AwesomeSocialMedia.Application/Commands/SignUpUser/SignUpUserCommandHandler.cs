using AwesomeSocialMedia.Application.Models;
using AwesomeSocialMedia.Users.Core.Repositories;

using MediatR;

namespace AwesomeSocialMedia.Application.Commands.SignUpUser;

public class SignUpUserCommandHandler : IRequestHandler<SignUpUserCommand, BaseResult<Guid>>
{
    public IUserRepository _userRepository { get; }

    public SignUpUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public async Task<BaseResult<Guid>> Handle(SignUpUserCommand request, CancellationToken cancellationToken)
    {
        var user = request.ToEntity();

        await _userRepository.AddAsync(user);

        return new BaseResult<Guid>(user.Id, true, "Profile successfuly created");
    }
}
