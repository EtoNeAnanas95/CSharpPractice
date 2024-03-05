using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diary
{
    internal class Note
    {
        public string name;
        public string description;

        // Если ничего не указано, ставим пустые поля
        public Note() 
        {
            this.name = "отсутствует";
            this.description = "отсутствует";
        }

        // Если указано только имя, ставим пустое поле для описания и устанавливаем имя
        public Note(string name) 
        {
            this.name = name;
            this.description = "отсутствует";
        }

        // Если указано оба поля, то устанавливаем их
        public Note(string name, string description) 
        {
            this.name = name;
            this.description = description;
        }
    }
}
