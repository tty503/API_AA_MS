using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Net.WebSockets;

namespace Application.CuentaApp
{
    public class Consulta
    {
        public class ListaCuentas : IRequest<List<Cuenta>> { }
        public class Handler : IRequestHandler<ListaCuentas, List<Cuenta>>
        {
            private readonly API_AA_MS_Context _context;
            private readonly IMapper _mapper;

            public Handler(API_AA_MS_Context context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<Cuenta>> Handle(ListaCuentas request, CancellationToken cancellationToken)
            {
                var cuentas = await _context.Cuenta
                                                    .Include(x => x.Usuario)
                                                    .ToListAsync();
                return cuentas;
            }
        }
    }
}
