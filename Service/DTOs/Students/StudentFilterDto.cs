

using FluentValidation;

namespace Service.DTOs.Students
{
    public class StudentFilterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
    }

    public class StudentFilterDtoValidator : AbstractValidator<StudentFilterDto>
    {
        public StudentFilterDtoValidator()
        {
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.Surname).NotEmpty();
            RuleFor(m => m.MinAge).NotEmpty().GreaterThan(0);
            RuleFor(m => m.MaxAge).NotEmpty().GreaterThan(0);
        }
    }
}
