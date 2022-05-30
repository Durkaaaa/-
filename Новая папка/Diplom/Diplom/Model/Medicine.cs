using System.Collections.Generic;

namespace Diplom.Model
{
    public class Medicine
    {
        public int Id { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }
        public string Titl { get; set; }

        // Ссылка на мед. страницы
        public List<MedicalRecord> MedicalRecords { get; set; }
    }
}
