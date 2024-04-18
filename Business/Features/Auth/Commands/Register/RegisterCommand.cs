using DataAccess.Abstract;
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

			private readonly IUserDal _userDal;

			public RegisterCommandHandler(IUserDal userDal)
			{
				_userDal = userDal;
			}

			public Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
			{
				/// Validation 
				throw new NotImplementedException();
			}
		}
	}
}
