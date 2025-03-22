using BoniboNews.Data;
using BoniboNews.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BoniboNews.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private MyContext _context;
        public IndexModel(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<Items> Items { get; set; }
        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                var results = _context.Users
                    .FirstOrDefault(c => c.UserName == User.Identity.Name);
                if (results.IsAdmin == true)
                {
                    Items = _context.Items.ToList();
                }
                else
                {
                    return Content("این حساب دسترسی به پنل ادمین را ندارد");
                }
            }
            else
            {
                return Content("ابتدا لاگین کنید");
            }
            return Page();
        }

        public void OnPost()
        {
        }
    }
}
