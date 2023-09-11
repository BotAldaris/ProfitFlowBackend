using System.ComponentModel.DataAnnotations;

namespace ProfitFlowBackend.Data.Dtos.User;

public class LoginUserDto
{
    [Required]
    public string Username { get; set; }
    [Required] public string Password { get; set; }
}
