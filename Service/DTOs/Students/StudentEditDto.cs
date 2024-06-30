
using FluentValidation;
using Swashbuckle.AspNetCore.Annotations;

namespace Service.DTOs.Students
{
    public class StudentEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public List<int> GroupId { get; set; }
    }

    public class StudentEditDtoValidator : AbstractValidator<StudentEditDto>
    {
        public StudentEditDtoValidator()
        {
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.Surname).NotEmpty();
            RuleFor(m => m.Address).NotEmpty();
            RuleFor(m => m.Email).NotEmpty();
            RuleFor(m => m.Age).NotEmpty().GreaterThan(0);
            RuleFor(m => m.GroupId).NotEmpty();
        }
    }
}

