using AspnCrudDapper.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace AspnCrudDapper.Pages.Produto
{
    public class IndexModel : PageModel
    {
        IProdutoRepository _produtoRepository;
        public IndexModel(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [BindProperty]
        public List<Entities.Produto> listaProdutos { get; set; }

        [BindProperty]
        public Entities.Produto produto { get; set; }

        [TempData]
        public string Message { get; set; }

        public void OnGet()
        {
            listaProdutos = _produtoRepository.GetProdutos();
        }

        public IActionResult OnPostDelete(int id)
        {
            if (id > 0)
            {
                var count = _produtoRepository.Delete(id);
                if (count > 0)
                {
                    Message = "Produto Deletado com sucesso !";
                    return RedirectToPage("/Produto/Index");
                }
            }
            return Page();
        }
    }
}