using BloodDonationDataBase.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;
using BloodDonationDataBase.Domain.IRepositories;
using BloodDonationDataBase.Infrastructure.Repositories;
using BloodDonationDataBase.Infrastructure.Services;
using BloodDonationDataBase.Application.FluentValidation.DonorValidations;
using FluentValidation.AspNetCore;
using FluentValidation;
using BloodDonationDataBase.Domain.IServices;
using MediatR;
using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Application.Commands.DonationCommands.CreateDonationCommands;
using BloodDonationDataBase.Application.Commands.DonorCommands.CreateDonorCommands;
using BloodDonationDataBase.Application.Commands.DonorCommands.UpdateDonorCommands;
using FastReport.Data;
using BloodDonationDataBase.Application.ServiceReport;

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

            //FastReport
            services.AddFastReport();
            FastReport.Utils.RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));

            //InjectionDependency
            services.AddScoped<IDonorRepository, DonorRepository>();
            services.AddScoped<IDonationRepository, DonationRepository>();
            services.AddScoped<IBloodStockRepository, BloodStockRepositoy>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAddressZipCode, AddressZipCode>();
            services.AddScoped<IGenerateDataTableReport, GenerateDataTableReport>();


            //fluentvalidation
            services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<CreateDonorValidation>();

            //Validation Commands
            services.AddTransient<IPipelineBehavior<CreateDonationCommand, ResultViewModel<int>>, ValidateCreateDonationCommand>();
            services.AddTransient<IPipelineBehavior<CreateDonorCommand, ResultViewModel<int>>, ValidationCreateDonorCommand>();
            services.AddTransient<IPipelineBehavior<UpdateDonorCommand, ResultViewModel<int>>, ValidationUpdateDonorCommand>();

            var myHandlers = AppDomain.CurrentDomain.Load("BloodDonationDataBase.Application");
            services.AddMediatR(config =>
                config.RegisterServicesFromAssembly(myHandlers));

            ////AutoMapper
            //services.AddAutoMapper(typeof(BookProfile));
            //services.AddAutoMapper(typeof(LoanProfile));
            //services.AddAutoMapper(typeof(UserProfile));



            return services;

        }
    }
}
