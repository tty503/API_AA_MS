using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

using System.Net;

namespace Application.SeguridadApp
{
    public class Login
    {
        public class Ejecuta : IRequest<Usuario>
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        public class Validaciones : AbstractValidator<Ejecuta>
        {
            public Validaciones()
            {
                RuleFor(x => x.username).NotEmpty();
                RuleFor(x => x.password).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Ejecuta, Usuario> 
        {
            private readonly UserManager<Usuario> _userManager;
            private readonly SignInManager<Usuario> _signInManager;
            private readonly IJwtGenerador _jwtGenerador;

            public Handler(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IJwtGenerador jwtGenerador)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _jwtGenerador = jwtGenerador;
            }

            public async Task<Usuario> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var usuario = await _userManager.FindByIdAsync(request.username);
                if (usuario == null)
                {
                    throw new HandlerException(HttpStatusCode.Unauthorized);
                }
                var resultado = await _signInManager.CheckPasswordSignInAsync(usuario, request.password, false);
                if (resultado.Succeeded)
                {
                    return new Usuario 
                    { 
                        UserName = request.username,
                        Token = _jwtGenerador.CrearToken(usuario)
                    };
                }
                throw new HandlerException(HttpStatusCode.Unauthorized);
            }
        }
    }
}
