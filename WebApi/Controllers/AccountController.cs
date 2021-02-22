using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Templete.Data.Model;
using Templete.Identity.Model;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;


        public AccountController(SignInManager<IdentityUser> signInManager,
                                    UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
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
                        return Ok();
                    }

                    return BadRequest("Usuário Invalido");

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
