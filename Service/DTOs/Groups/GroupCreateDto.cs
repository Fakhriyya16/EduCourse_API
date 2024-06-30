
using FluentValidation;

namespace Service.DTOs.Groups
{
    public class GroupCreateDto
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int EducationId { get; set; }
        public int RoomId { get; set; }
        public List<int> TeacherId { get; set; }
    }

    public class GroupCreateDtoValidator : AbstractValidator<GroupCreateDto>
    {
        public GroupCreateDtoValidator()
        {
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.Capacity).NotEmpty().GreaterThan(0).WithMessage("Capacity cannot be negative");
            RuleFor(m => m.EducationId).NotEmpty();
            RuleFor(m => m.RoomId).NotEmpty();
            RuleFor(m => m.TeacherId).NotEmpty();
        }
    }
}
