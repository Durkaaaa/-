using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom.Model
{
    public class Medicine
    {
        public int Id { get; set; }
        public int MedicalRecordId { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }
        public string Titl { get; set; }

        // Ссылка на мед. страницы
        [NotMapped]
        public List<MedicalRecord> MedicalRecords { get; set; }
    }
}
