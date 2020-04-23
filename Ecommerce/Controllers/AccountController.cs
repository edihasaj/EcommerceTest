using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
public class AccountController : Controller
{
    private readonly UserManager<LoginViewModel> _userManager;
    private readonly SignInManager<LoginViewModel> _signInManager;

    public AccountController(UserManager<LoginViewModel> userManager, 
                             SignInManager<LoginViewModel> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if(ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(model, false);
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Invalid login attempt");
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}