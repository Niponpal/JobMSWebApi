using JobMSWebApi.Auth_IdentityModel;
using JobMSWebApi.FilesUpload;
using JobMSWebApi.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobMSWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly IAuthService _authService;
    private readonly IFileService _fileService;

    public AccountController(
        SignInManager<User> signInManager,
        UserManager<User> userManager,
        IAuthService authService,
        IFileService fileService)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _authService = authService;
        _fileService = fileService;
    }

    // ================= REGISTER =================
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromForm] RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new
            {
                success = false,
                errors = ModelState
            });
        }

        string? imageFileName = null;

        if (model.ImageFile != null)
        {
            imageFileName = await _fileService.Upload(model.ImageFile, "uploads/users");
        }

        var result = await _authService.Register(model, imageFileName);

        if (!result.Success)
        {
            return BadRequest(new
            {
                success = false,
                errors = result.Errors
            });
        }

        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user == null)
        {
            return BadRequest(new
            {
                success = false,
                message = "User not found after registration."
            });
        }

        user.ImageUrl = imageFileName;
        await _userManager.UpdateAsync(user);

        await _signInManager.SignInAsync(user, isPersistent: false);

        return Ok(new
        {
            success = true,
            message = "Registration successful!",
            user = new
            {
                user.Id,
                user.Email,
                user.UserName,
                user.ImageUrl
            }
        });
    }

    // ================= LOGIN =================
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new
            {
                success = false,
                errors = ModelState
            });
        }

        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user == null)
        {
            return Unauthorized(new
            {
                success = false,
                message = "Invalid login attempt."
            });
        }

        var result = await _signInManager.PasswordSignInAsync(
            user,
            model.Password,
            isPersistent: false,
            lockoutOnFailure: false
        );

        if (!result.Succeeded)
        {
            return Unauthorized(new
            {
                success = false,
                message = "Invalid login attempt."
            });
        }

        var roles = await _userManager.GetRolesAsync(user);
        var roleName = roles.FirstOrDefault();

        return Ok(new
        {
            success = true,
            message = "Login successful!",
            user = new
            {
                user.Id,
                user.Email,
                user.UserName,
                role = roleName
            },
            redirectTo = (roleName == "Employer" || roleName == "Administrator")
                ? "/dashboard"
                : "/home"
        });
    }

    // ================= LOGOUT =================
    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();

        return Ok(new
        {
            success = true,
            message = "Logged out successfully!"
        });
    }

    // ================= ACCESS DENIED =================
    [HttpGet("access-denied")]
    [AllowAnonymous]
    public IActionResult AccessDenied()
    {
        return StatusCode(403, new
        {
            success = false,
            message = "Access denied"
        });
    }
}