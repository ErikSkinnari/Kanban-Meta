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
        public class CardToMove
        {
            public string CardId { get; set; }
            public string Direction { get; set; }
            public string BoardId { get; set; }
        }

        private IDataManager _dataManger;

        public int BoardId { get; set; }
        public Board Board { get; set; }
        public Card EditCard { get; set; }
        public Card NewCard { get; set; }
        public Card DeleteCard { get; set; }
        public CardToMove MoveCard { get; set; }
        public string SelectedCardId { get; set; }


        public BoardModel(IDataManager dataManager)
        {
            _dataManger = dataManager;

        }

        public IActionResult OnPostEditCard(Card EditCard)
        {
            var boardId = EditCard.BoardId;
            _dataManger.EditCard(EditCard);

            return RedirectToPage("Board", boardId);
        }

        public async Task<IActionResult> OnPostAddCard(Card NewCard)
        {
            var boardId = NewCard.BoardId;
            await _dataManger.AddCard(NewCard);

            return RedirectToPage("Board", boardId);
        }


        public async Task<IActionResult> OnPostDeleteCard(Card DeleteCard)
        {
            await _dataManger.DeleteCard(DeleteCard.Id);

            return RedirectToPage("Board", DeleteCard.BoardId);
        }

        public async Task<IActionResult> OnPostMoveCard(CardToMove MoveCard)
        {
            await _dataManger.MoveCard(MoveCard.CardId, MoveCard.Direction);
            
            return RedirectToPage("Board", MoveCard.BoardId);
        }

        public async void OnGet(string id = "94e25123-afac-4bb4-8b89-0496becc8433")
        {
            Board = await _dataManger.GetBoard(id);
        }
    }
}