using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Notes.Models
{
    public class Note
    {
        //AutoIncrement - автоматические инкрементируется при добавлении строк в таблицу
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        //
        public string Text { get; set; }
        //текст записки
        public DateTime Data { get; set; }
        //дата записки
    
    }
}
