using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace KanbanMetaWeb.Interfaces
{
    public interface IDbManager
    {
        public void SaveData(Object obj, string path);

        public IEnumerable GetData(string path);

        public object UpdateData();

        public void DeleteData();
    }
}
