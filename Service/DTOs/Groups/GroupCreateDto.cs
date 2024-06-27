
using FluentValidation;

namespace Service.DTOs.Groups
{
    public class GroupCreateDto
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
    }

    public class GroupCreateDtoValidator : AbstractValidator<GroupCreateDto>
    {
        public GroupCreateDtoValidator()
        {
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.Capacity).NotEmpty().GreaterThan(0).WithMessage("Capacity cannot be negative");
        }
    }
}
