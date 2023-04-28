using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NetcoreCrudBaseApi.Domains.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace NetcoreCrudBaseApi.Infrastructure.Auth;

public class AuthTokenService
{

    private TokenConfiguration _tokenConfiguration;
    public AuthTokenService(IOptions<TokenConfiguration> option)
    {
        _tokenConfiguration = option.Value;
    }
    private IEnumerable<Claim> createClaimsUser(UserEntity user)
    {
        return new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub,user.Login),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.ToString()),
            new Claim("act",user.Active.ToString().ToLower()),
            new Claim("rol",user.Profile.Acronym),
            new Claim("pid",""),
        };
    }

    private SigningCredentials CreateSigningCredentials()
    {
        var sercretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfiguration.SecurityKey));
        return new SigningCredentials(sercretKey, SecurityAlgorithms.HmacSha256);
    }
    private DateTime ExpirationDate()
    {        
        return DateTime.Now.AddHours(_tokenConfiguration.DurationInHours);
        //return DateTime.Now.AddSeconds(30);
    }
    /**
     * sub (subject) = Entidade à quem o token pertence, normalmente o ID do usuário;
     * iss (issuer) = Emissor do token;
     * exp (expiration) = Timestamp de quando o token irá expirar;
     * iat (issued at) = Timestamp de quando o token foi criado;
     * aud (audience) = Destinatário do token, representa a aplicação que irá usá-lo.
     *
     * act (active) = Indicador de status do usuario
     * rol (role) = Indicador do perfil ou papel do usuario
     * pid (permission id) = Indicador dos ids das permissoes do usuario
     * pnm (permission name) = Indicador dos nomes das permissoes do usuario
     */
    public string CreateTokenUser(UserEntity user)
    {
        try
        {
            var claims = createClaimsUser(user);
            var singIn = CreateSigningCredentials();
            var token = new JwtSecurityToken(_tokenConfiguration.Issuer,
                                             _tokenConfiguration.Audience,
                                             claims,
                                             expires: ExpirationDate(),
                                             signingCredentials: singIn);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        catch (Exception ex)
        {
            throw new Exception("Error on create token user", ex);
        }
    }
}
