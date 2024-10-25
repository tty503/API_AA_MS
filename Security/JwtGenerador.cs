using Application.Interfaces;
using Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Security
{
    public class JwtGenerador : IJwtGenerador
    {
        public string CrearToken(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, usuario.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("unaClaveMuyLargaParaEjemploHMACSHA512ConAlMenos512BitsDeLongitudParaQueElAlgoritmoFuncioneCorrectamente"));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescripcion = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credenciales

            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescripcion);


            return tokenHandler.WriteToken(token);
        }
    }
}