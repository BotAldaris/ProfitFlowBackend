using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProfitFlowBackend.Data;
using ProfitFlowBackend.Data.Dtos.User;
using ProfitFlowBackend.Services;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{

    private UserService _userService;
    private ProfitFlowDbContext _context;
    private IMapper _mapper;


    public UsuarioController(UserService cadastroService, ProfitFlowDbContext context, IMapper mapper)
    {
        _userService = cadastroService;
        _context = context;
        _mapper = mapper;
    }


    [HttpPost("cadastro")]
    public async Task<IActionResult> CadastraUsuario
        (CreateUserDtos dto)
    {
        await _userService.Cadastra(dto);
        return Ok("Usuário cadastrado!");

    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDto dto)
    {
        var token = await _userService.Login(dto);
        return Ok(token);
    }
}