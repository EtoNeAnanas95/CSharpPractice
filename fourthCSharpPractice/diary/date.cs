using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diary
{
    internal class Date
    {
        public DateTime datetime = new DateTime();
        public List<Note> notes = new List<Note>();
        public int Print()
        {
            int index = 0;

            int position = 1;
            foreach (Note note in this.notes)
            {
                Console.SetCursorPosition(2, position);
                int length = note.name.Length;
                for (int j = 0; j < length; j++)
                {
                    Console.Write(" ");
                    j++;
                    j++;
                }
                Console.SetCursorPosition(2, position);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"({index + 1})");
                Console.ResetColor();
                Console.WriteLine($" {note.name}");
                index++;
                position++;
            }
            return index;
        }
        public int index()
        {
            int index = 0;

            int position = 1;
            foreach (Note note in this.notes)
            {
                index++;
                position++;
            }
            return index;
        }

        public Date(DateTime dateTime) 
        {
            this.datetime = new DateTime();
        }
        public Date(DateTime dateTime, Note note)
        {
            this.datetime = new DateTime();
            this.notes = new List<Note>();
        }
        public Date(Note note)
        {
            this.notes = new List<Note>();
        }
        public Date()
        {
            this.datetime = new DateTime();
        }
        public void AddNote(Note note) {
            this.notes.Add(note);
        }
    }
}
