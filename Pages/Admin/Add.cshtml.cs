using BoniboNews.Models;
using BoniboNews.Data;
using BoniboNews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BoniboNews.DateTime;

namespace BoniboNews.Pages.Admin
{
    public class AddModel : PageModel
    {
        private MyContext _context;
        public AddModel(MyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddEditViewModel AddItems { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                var item = new Items()
                {
                    ItemName = AddItems.ItemName,
                    Description = AddItems.Description,
                    CreateDate = PersianDate.Persian(),
                    Comments = "ندارد",
                    ViewCount = 1
                };
                _context.Add(item);
                _context.SaveChanges();

                if (AddItems.Picture?.Length > 0)
                {
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot",
                        "images",
                        item.Id + Path.GetExtension(AddItems.Picture.FileName));
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        AddItems.Picture.CopyTo(stream);
                    }
                }

                return RedirectToPage("Index");
            }
        }
    }
}
