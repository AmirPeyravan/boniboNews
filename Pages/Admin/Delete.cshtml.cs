using BoniboNews.Data;
using BoniboNews.Models;
using BoniboNews.Data;
using BoniboNews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoniboNews.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private MyContext _context;
        public DeleteModel(MyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Items DeleteItems { get; set; }
        public void OnGet(int id)
        {
            DeleteItems = _context.Items.FirstOrDefault(c => c.Id == id);
        }

        public IActionResult OnPost(int id)
        {
            var product = _context.Items.Find(DeleteItems.Id);
            var item = _context.Items.First(c => c.Id == product.Id);
            _context.Items.Remove(item);
            _context.Items.Remove(product);
            _context.SaveChanges();

            string filePath = Path.Combine(Directory.GetCurrentDirectory(),
               "wwwroot",
               "Images",
               product.Id + ".jpg");
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            return RedirectToPage("Index");
        }
    }
}
