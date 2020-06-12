using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanbanMetaWeb.Interfaces;
using KanbanMetaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KanbanMetaWeb.Pages
{
    public class BoardModel : PageModel
    {
        private IDataManager _dataManger;

        public int BoardId { get; set; }
        public Board Board { get; set; }

        public BoardModel(IDataManager dataManager)
        {
            _dataManger = dataManager;
        }
        

        public void OnGet()
        {
            Board = _dataManger.GetBoard();
        }
    }
}