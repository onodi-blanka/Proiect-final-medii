using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Proiect.Pages
{

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;


        public IndexModel(ILogger<IndexModel> logger, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public IList<string> UserRoles { get; set; }
        //public void OnGet()
        //{

        //}
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                UserRoles = await _userManager.GetRolesAsync(user);
            }

            return Page();
        }
    }
}