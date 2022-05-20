namespace Diploma.Model
{
    public class Reception
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
        public string Diagnosis { get; set; }
        public string TypeOfTreatment { get; set; }
    }
}
