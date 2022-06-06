using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Notes.Models;
using System.Threading.Tasks;
namespace Notes.Data
{
    public class NotesDB
    {
        readonly SQLiteAsyncConnection db;
        public NotesDB(string connectionString)
        {
            db = new SQLiteAsyncConnection(connectionString);
            db.CreateTableAsync<Note>().Wait();

        }

        public Task<List<Note>> GetNotesAsync() {
        return db.Table<Note>().ToListAsync();
        }
        /*   public Task<List<Note>> GetNoteAsync(int id) {

               return db.Table<Note>().Where(i => i.ID == id).FirstOrDefaultAsync();

           }*/
        public Task<Note> GetNoteAsync(int id)
        {
            return db.Table<Note>().FirstOrDefaultAsync(x => x.ID == id);
        }

        public Task<int> SaveNoteAsync(Note note) {
            if (note.ID != 0)
            {
                return db.UpdateAsync(note);
            }
            else 
            {
            
                return db.InsertAsync(note);
            
            }
        
        }

        public Task<int> DeleteNoteAsync(Note note) {
        
        return db.DeleteAsync(note);
        
        }

    }
}
