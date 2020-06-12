﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using KanbanMetaWeb.Models;

namespace KanbanMetaWeb.Interfaces
{
    public interface IDataManager
    {
        public Task<Board> GetBoard(int boardId);

        public Task DeleteBoard(int boardId);

        public Task AddCard(Card card);

        public Task EditCard(int cardId, Card card);

        public Task DeleteCard(string cardId);

        //public void AddColumn(int boardId);

        //public void AddUser(int boardId, int userId);

    }
}