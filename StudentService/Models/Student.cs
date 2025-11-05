namespace StudentService.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public decimal Fee { get; set; }
        public string Status { get; set; } = "Active"; // Active / Inactive
    }
}
