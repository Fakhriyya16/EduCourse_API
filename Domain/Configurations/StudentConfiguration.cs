
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(m => m.Name).IsRequired();
            builder.Property(m => m.Surname).IsRequired();
            builder.Property(m => m.Address).IsRequired();
            builder.Property(m => m.Email).IsRequired();
            builder.Property(m => m.Age).IsRequired();
        }
    }
}
