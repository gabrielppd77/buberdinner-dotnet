using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Users;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands.Register;

public class RegisterCommandHandler :
	IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
	private readonly IJwtTokenGenerator _jwtTokenGenerator;
	private readonly IUserRepository _userRepository;

	public RegisterCommandHandler(
		IJwtTokenGenerator jwtTokenGenerator,
		IUserRepository userRepository)
	{
		_jwtTokenGenerator = jwtTokenGenerator;
		_userRepository = userRepository;
	}

	public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
	{
		await Task.CompletedTask;

		if (_userRepository.GetUserByEmail(request.Email) is not null)
		{
			return Errors.User.DuplicateEmail;
		}

		var user = new User()
		{
			FirstName = request.FirstName,
			LastName = request.LastName,
			Email = request.Email,
			Password = request.Password
		};
		_userRepository.Add(user);

		var token = _jwtTokenGenerator.GenerateToken(user);

		return new AuthenticationResult(user, token);
	}
}