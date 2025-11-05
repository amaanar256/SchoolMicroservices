using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace APIGateway.Controllers
{
    [ApiController]
    [Route("merged")]
    public class MergedController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public MergedController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet("students")]
        public async Task<IActionResult> GetMergedStudents()
        {
            // 1️⃣ Get students list
            var students = await _httpClient.GetFromJsonAsync<List<StudentDto>>("http://localhost:5041/api/students");

            // 2️⃣ Get fees list
            var fees = await _httpClient.GetFromJsonAsync<List<FeeDto>>("http://localhost:5110/api/fees");

            // 3️⃣ Merge both lists
            var merged = students!.Select(s => new
            {
                s.Id,
                s.Name,
                s.Class,
                s.Fee,
                s.Status,
                Fees = fees!.Where(f => f.StudentId == s.Id).ToList()
            });

            return Ok(merged);
        }
    }

    // DTOs
    public class StudentDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Class { get; set; }
        public decimal Fee { get; set; }
        public string? Status { get; set; }
    }

    public class FeeDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
        public decimal Fees { get; set; }
        public string? Month { get; set; }
        public string? Status { get; set; }
    }
}
