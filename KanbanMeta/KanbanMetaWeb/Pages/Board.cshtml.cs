using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanbanMetaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KanbanMetaWeb.Pages
{
    public class BoardModel : PageModel
    {
        public int BoardId { get; set; }
        public List<Column> Columns { get; set; }
        public List<Card> Cards { get; set; }
        

        public void OnGet()
        {

        }
    }
}