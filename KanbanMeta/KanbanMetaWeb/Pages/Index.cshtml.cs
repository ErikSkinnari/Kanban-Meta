﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using KanbanMetaWeb.Controllers;
using KanbanMetaWeb.Models;
using System.Collections;
using Microsoft.Extensions.DependencyInjection;
using KanbanMetaWeb.Interfaces;

namespace KanbanMetaWeb.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;

        private readonly IDataManager _dataService;

        public IndexModel(ILogger<IndexModel> logger, IDataManager dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }

        
        public IEnumerable Cards { get; private set; }

        public async void OnGet()
        {

            //Card card = new Card() { Id = "1337", BoardId = "1", Title = "Elite", Description = "Hej", ColumnId = 0 };

            //await DataService.AddCard(card);

            // await DataService.DeleteCard("1337");


        }
    }
}
