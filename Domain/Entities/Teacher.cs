
using Domain.Common;

namespace Domain.Entities
{
    public class Teacher : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Salary { get; set; }
        public int Age { get; set; }
        public ICollection<GroupTeachers> GroupTeachers { get; set; }
    }
}
