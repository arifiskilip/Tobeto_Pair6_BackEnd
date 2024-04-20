using AutoMapper;
using Business.Abstract;
using Business.Features.Auth.Rules;
using Core.Entities;
using Core.Utilities.Security.Hashing;
using MediatR;

namespace Business.Features.Auth.Commands.Register
{
	public class RegisterCommand :IRequest<RegisterResponse>
	{
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }



		public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
		{

			private readonly IMapper _mapper;
			private readonly IAuthService _authService;
			private readonly IUserService _userService;
			private readonly AuthBusinessRules _authBusinessRules;

			public RegisterCommandHandler(IMapper mapper, IAuthService authService, IUserService userService, AuthBusinessRules authBusinessRules)
			{
				_mapper = mapper;
				_authService = authService;
				_userService = userService;
				_authBusinessRules = authBusinessRules;
			}

			public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
			{
				/// Validation 
				/// Business Rules
				await _authBusinessRules.CheckDuplicateEmailAsync(request.Email);

				byte[] passwordHash, passwordSalt;
				HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
				var user = _mapper.Map<User>(request);
				user.PasswordSalt = passwordSalt;
				user.PasswordHash = passwordHash;
				await _userService.AddAsync(user);
				var token = await _authService.CreateAccessTokenAsync(user);
				return new()
				{
					User = user,
					Token = token
				};
			}
		}
	}
}
