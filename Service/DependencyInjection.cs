
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Service.DTOs.Groups;
using Service.DTOs.Students;
using Service.Helpers;
using Service.Services;
using Service.Services.Interfaces;

namespace Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation(config =>
            {
                config.DisableDataAnnotationsValidation = true;
            });

            services.AddValidatorsFromAssemblyContaining<StudentCreateDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<GroupCreateDtoValidator>();
            services.AddScoped<IGroupService,GroupService> ();
            services.AddScoped<IStudentService,StudentService> ();
            services.AddScoped<IRoomService,RoomService> ();
            services.AddScoped<ITeacherService,TeacherService> ();
            services.AddScoped<IEducationService,EducationService> ();
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            return services;
        }
    }
}
