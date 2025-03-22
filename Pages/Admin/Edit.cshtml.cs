using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BoniboNews.Models;
using BoniboNews.Data;
using Microsoft.EntityFrameworkCore;

namespace BoniboNews.Pages.Admin
{
    public class EditModel : PageModel
    {
        private MyContext _context;
        public EditModel(MyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddEditViewModel EditItems { get; set; }
        public void OnGet(int id)
        {
            EditItems = _context.Items
                .Where(p => p.Id == id)
                .Select(c => new AddEditViewModel()
                {
                    Id = c.Id,
                    ItemName = c.ItemName,
                    Description = c.Description
                }).FirstOrDefault();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var product = _context.Items.Find(EditItems.Id);
            var item = _context.Items.First(c => c.Id == product.Id);
            product.ItemName = EditItems.ItemName;
            product.Description = EditItems.Description;
            _context.SaveChanges();

            if (EditItems.Picture?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "Images",
                    product.Id + Path.GetExtension(EditItems.Picture.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    EditItems.Picture.CopyTo(stream);
                }
            }

            return RedirectToPage("Index");
        }

    }
}
