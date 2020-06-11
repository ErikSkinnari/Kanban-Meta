using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using KanbanMetaWeb.Managers;
using KanbanMetaWeb.Models;
using System.Collections;

namespace KanbanMetaWeb.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, JsonFileService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        public JsonFileService ProductService { get; }
        public IEnumerable Cards { get; private set; }

        public void OnGet()
        {
            Cards = ProductService.GetData("cards.json");
            Console.Write(Cards);
        }
    }
}
