using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Templete.Data.Model;
using Templete.Identity.Model;
using WebApi.Token.Jwt;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;


        public AccountController(SignInManager<IdentityUser> signInManager,
                                    UserManager<IdentityUser> userManager, IOptions<AppSettings> appSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost("nova-conta")]
        public async Task<ActionResult> Post([FromBody] RegiterUser regiterUser)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
                }else
                {
                    var user = new IdentityUser
                    {
                        UserName = regiterUser.Email,
                        Email = regiterUser.Email,
                        EmailConfirmed = true
                    };

                    //Criar o usuario com user-manager
                    var result = await _userManager.CreateAsync(user, regiterUser.Password);

                    //Se o correr um erro ao tentar registar o usuario retornar os erros
                    if (!result.Succeeded) return BadRequest(result.Errors);

                    //Caso contrario autenticar o usuario
                    await _signInManager.SignInAsync(user, false);

                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost("entrar")]
        public async Task<ActionResult> Login([FromBody] LoginUser loginUser)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
                }
                else
                {

                    //Autenticar o usuario
                    var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);


                    if(result.Succeeded)
                    {
                        return Ok(await GerarToken(loginUser.Email));
                    }

                    return BadRequest("Usuário Invalido");

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("gerar-token")]
        public async Task<string> GerarToken( string email)
        {

                    //Buscar o usuario
                    var result = await _userManager.FindByEmailAsync(email);

            //Adicionar claims do utilizador no Token no acto da criação
            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(await _userManager.GetClaimsAsync(result));


            var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = identityClaims,
                    Issuer = _appSettings.Emissor,
                    Audience = _appSettings.ValidoEm,
                    Expires = DateTime.UtcNow.AddDays(_appSettings.ExpiracaoHoras),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
                };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
   
        }
    }
}
