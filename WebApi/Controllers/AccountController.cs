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
using Templete.Data.Interface;
using Templete.Data.Model;
using Templete.Identity.Model;
using WebApi.Filter;
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
        private readonly ICliente _ClienteRepository;

        public AccountController(SignInManager<IdentityUser> signInManager,
                                    UserManager<IdentityUser> userManager, 
                                    IOptions<AppSettings> appSettings, ICliente ClienteRepository)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _ClienteRepository = ClienteRepository;
        }

        [ServiceFilter(typeof(AccountFilter))]
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

                    //Montar o objecto para criar conta do cliente
                    var UserCliente = new Cliente()
                    {
                        Email = regiterUser.Email,
                        Nome = regiterUser.Nome,
                        Telefone = regiterUser.Telefone,
                        Endereco = regiterUser.Endereco
                    };

                    //Montar o objecto para criar o usuário
                    var user = new IdentityUser
                    {
                        UserName = regiterUser.Email,
                        Email = regiterUser.Email,
                        EmailConfirmed = true
                    };

                    //Registar o cliente
                    var cliente = _ClienteRepository.Insert(UserCliente);

                    //Se a conta de utilizar for criado com sucesso
                    if(cliente == 1)
                    {
                        //Criar o usuario com user-manager
                        var result = await _userManager.CreateAsync(user, regiterUser.Password);

                        //Se o correr um erro ao tentar registar o usuario retornar os erros
                        if (!result.Succeeded) return BadRequest(result.Errors);

                        //Caso contrario autenticar o usuario
                        await _signInManager.SignInAsync(user, false);

                        var LoginUser = new LoginUser()
                        {
                            Email = regiterUser.Email,
                            Password = regiterUser.Password,
                            Nome = regiterUser.Nome
                        };

                        return Ok(await GerarToken(LoginUser));
                    }
                    else
                    {
                        return BadRequest("Ocorreu um erro ao tentar registar o cliente");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.InnerException.Message);
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
                        return Ok(await GerarToken(loginUser));
                    }

                    return BadRequest("Usuário Invalido");

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private async Task<LoginUser> GerarToken(LoginUser loginUser)
        {

            //Buscar o usuario
            var result = await _userManager.FindByEmailAsync(loginUser.Email);

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


            loginUser.Password = null;
            loginUser.Grupo = "Cliente";
            loginUser.Token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
            loginUser.Status = "Sucess";
            return loginUser;
   
        }
    }
}
