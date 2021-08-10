using AspnCrudDapper.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnCrudDapper.Pages.Produto
{
    public class AddModel : PageModel
    {
        IProdutoRepository _produtoRepository;
        public AddModel(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [BindProperty]
        public Entities.Produto produto { get; set; }

        [TempData]
        public string Message { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var count = _produtoRepository.Add(produto);
                if (count > 0)
                {
                    Message = "Novo Produto incluído com sucesso !";
                    return RedirectToPage("/Produto/Index");
                }
            }
            return Page();
        }
    }
}