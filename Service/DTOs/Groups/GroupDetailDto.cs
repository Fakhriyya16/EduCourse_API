
namespace Service.DTOs.Groups
{
    public class GroupDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<string> Students { get; set; }
    }

}
