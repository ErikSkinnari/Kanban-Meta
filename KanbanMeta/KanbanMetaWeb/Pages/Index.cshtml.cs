using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using KanbanMetaWeb.Controllers;
using KanbanMetaWeb.Models;
using System.Collections;

namespace KanbanMetaWeb.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, CardControllerService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        public CardControllerService ProductService { get; }
        public IEnumerable Cards { get; private set; }

        public void OnGet()
        {
            //Cards = ProductService.GetData("cards.json");
            //Console.Write(Cards);

            //Card card = new Card() {id = "1337", boardId = "1", title = "Elite", description = "Hej", columnId = 0 };
            //ProductService.SaveData(card, "cards.json");

            ProductService.DeleteData("1337", "cards.json");
        }
    }
}
