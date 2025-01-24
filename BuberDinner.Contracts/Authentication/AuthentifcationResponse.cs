namespace BuberDinner.Contracts.Authentication;

public record AuthentifcationResponse(
	Guid Id,
	string FirstName,
	string LastName,
	string Email,
	string Token
);