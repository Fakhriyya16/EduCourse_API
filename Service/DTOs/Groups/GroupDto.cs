
namespace Service.DTOs.Groups
{
    public class GroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<string> Students { get; set; }
    }
}
