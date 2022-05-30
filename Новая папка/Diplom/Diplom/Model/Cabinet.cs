using System.Collections.Generic;

namespace Diplom.Model
{
    public class Cabinet
    {
        public int Id { get; set; }
        public string Titl { get; set; }

        // Ссылка на кабинеты
        public List<Cabinet> Cabinets { get; set; }
    }
}
