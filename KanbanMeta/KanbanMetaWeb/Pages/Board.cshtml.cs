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

#nullable enable
        public async void OnGet(string id)
        {
            //id = "94e25123-afac-4bb4-8b89-0496becc8433";
            //id = "9000";

            Board = await _dataManger.GetBoard(id);
        }
    }
#nullable disable
}