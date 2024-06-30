
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Data;
using Repository.Repositories;
using Repository.Repositories.Interfaces;

namespace Repository
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
        {
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IEducationRepository, EducationRepository>();

            services.AddScoped(typeof(IBaseRepository<>),typeof(BaseRepository<>));

            return services;
        }
    }
}
    