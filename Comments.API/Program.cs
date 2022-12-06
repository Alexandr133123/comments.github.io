using Microsoft.EntityFrameworkCore;
using Comments.Infrastructure.DbContexts;
using Comments.Core.Interfaces.IService;
using Comments.Infrastructure.Interfaces.IRepository;
using Comments.Core.Services;
using Comments.Infrastructure.Repositories;
using Comments.Infrastructure.SqlScripts;
using Comments.Core.Managers;
using Comments.API.Hubs;

namespace Comments.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CommentsDbConnection"));
            });

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddTransient<ICommentRepository, CommentRepository>();
            builder.Services.AddTransient<ICommentService, CommentService>();
            builder.Services.AddTransient<CommentDataManager>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<CommentDataManager>();
            builder.Services.AddTransient<FileStorageFormatManager>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSignalR();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors();

            app.UseEndpoints(options =>
            {
                options.MapControllers();
                options.MapHub<CommentsHub>("/hub/comments");
            });

            app.Run();
        }
    }
}