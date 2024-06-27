
namespace Service.DTOs.Students
{
    public class StudentDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<string> Groups { get; set; }
    }
}
