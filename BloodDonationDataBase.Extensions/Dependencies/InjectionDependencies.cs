﻿using BloodDonationDataBase.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace BloodDonationDataBase.Extensions.Dependencies
{
    public static class InjectionDependencies

    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            //Configuration Controllers
            services.AddControllers()
                .AddJsonOptions(op =>
                {
                    op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());// mostra no Schemas do swagger os valores do enum
                    op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                })
                .AddNewtonsoftJson(op => op.SerializerSettings.Converters.Add(new StringEnumConverter()));

            //DbContext
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BloodDataBaseDbContext>(opt =>
                            opt.UseSqlServer(connectionString));

            ////Dapper
            //services.AddSingleton<IDbConnection>(provider =>
            //{
            //    // Crie a conexão com o banco de dados
            //    var connection = new SqlConnection(connectionString);
            //    connection.Open();

            //    // Crie a instância do ApiDbContext e passe a conexão
            //    return connection;
            //});



            ////InjectionDependency
            //services.AddScoped<IBookRepository, BookRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<ILoanRepository, LoanRepository>();
            //services.AddScoped<IBookDapperRepository, BookDapperRepository>();
            //services.AddScoped<IEmailService, EmailService>();
            //services.AddScoped<ISendEmails, SendEmails>();

            ////FluentValidation
            //services.AddFluentValidationAutoValidation()
            //    .AddValidatorsFromAssemblyContaining<CreateBookCommandValidation>();

            ////Validation Commands
            //services.AddTransient<IPipelineBehavior<CreateLoanCommand, ResultViewModel<int>>, ValidateCreateLoancommand>();
            //services.AddTransient<IPipelineBehavior<EndLoanCommand, ResultViewModel>, ValidateEndLoanCommand>();

            //var myHandlers = AppDomain.CurrentDomain.Load("BookManager.Application");
            //services.AddMediatR(config =>
            //    config.RegisterServicesFromAssembly(myHandlers));

            ////AutoMapper
            //services.AddAutoMapper(typeof(BookProfile));
            //services.AddAutoMapper(typeof(LoanProfile));
            //services.AddAutoMapper(typeof(UserProfile));



            return services;

        }
    }
}
