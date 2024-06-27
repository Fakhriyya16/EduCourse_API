
using Domain.Common;

namespace Domain.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int GroupId { get; set; }
        public ICollection<StudentGroups> StudentGroups { get; set; }
    }
}
