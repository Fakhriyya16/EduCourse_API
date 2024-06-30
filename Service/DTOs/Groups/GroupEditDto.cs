using FluentValidation;

namespace Service.DTOs.Groups
{
    public class GroupEditDto
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int EducationId { get; set; }
    }

    public class GroupEditDtoValidator : AbstractValidator<GroupEditDto>
    {
        public GroupEditDtoValidator()
        {
            RuleFor(m=>m.Name).NotEmpty();
            RuleFor(m=>m.EducationId).NotEmpty();
            RuleFor(m=>m.Capacity).NotEmpty().GreaterThan(0);
        }
    }
}
