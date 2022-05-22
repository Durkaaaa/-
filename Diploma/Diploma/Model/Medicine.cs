namespace Diploma.Model
{
    public class Medicine
    {
        public int Id { get; set; }
        public int MedicalСardId { get; set; }
        public virtual MedicalСard MedicalСard { get; set; }
        public string Titl { get; set; }
    }
}
