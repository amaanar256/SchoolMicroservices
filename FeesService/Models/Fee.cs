namespace FeesService.Models
{
    public class Fee
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public string Month { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending"; // Paid / Pending
    }
}
