using AutoMapper;
using NoroNest.Application.Interfaces;
using NoroNest.Application.Profiles;
using NoroNest.Application.Services;
using NoroNest.Domain.Interfaces;
using NoroNest.Domain.Models.Identity;
using NoroNest.Infrastructure;
using NoroNest.Infrastructure.Contexts;
using NoroNest.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoroNest.Infrastructure.UnitOfWorks;
using NoroNest.Domain.Models.UserData;
using NoroNest.Domain.Models.Game;

namespace NoroNest.Application
{
	public static class DependencyContainer
	{
		public static IServiceCollection RegisterCadap(this IServiceCollection services, IConfiguration configuration)
		{
			/*services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 50 * 1024 * 1024; // 50MB
                options.ValueLengthLimit = 50 * 1024 * 1024;
            });*/

			RegisterCoreServices(services, configuration);
			RegisterDbContext(services, configuration);
			RegisterIdentity(services);
			RegisterRepositories(services);
			RegisterApplicationServices(services, configuration);
			RegisterAutoMapper(services);

			return services;
		}

		private static void RegisterCoreServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddHttpContextAccessor();
			services.AddMemoryCache();
			services.AddSingleton(TimeProvider.System);
		}

		private static void RegisterDbContext(IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<NoroNestDbContext>((provider, options) =>
			{
				var connStr = configuration.GetConnectionString("Default");

				options.UseSqlServer(connStr, sqlOptions =>
				{
					sqlOptions.MigrationsHistoryTable("__EFMigrationsHistory", "dbo");
				})
				.UseLazyLoadingProxies()
				.EnableSensitiveDataLogging()
				.LogTo(Console.WriteLine, LogLevel.Information);
			});
		}

		private static void RegisterIdentity(IServiceCollection services)
		{
			services.AddIdentityCore<User>(options =>
			{
				options.SignIn.RequireConfirmedAccount = false;
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireUppercase = true;
				options.Password.RequiredLength = 6;
				options.Password.RequiredUniqueChars = 1;

				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				options.Lockout.MaxFailedAccessAttempts = 5;
				options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
				options.User.RequireUniqueEmail = false;
			})
			.AddRoles<IdentityRole>()
			.AddUserManager<UserManager<User>>()
			.AddSignInManager<SignInManager<User>>()
			.AddDefaultTokenProviders()
			.AddEntityFrameworkStores<NoroNestDbContext>();

			services.ConfigureApplicationCookie(options =>
			{
				options.Cookie.HttpOnly = true;
				options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
				options.LoginPath = "/Auth/Login";
				options.AccessDeniedPath = "/Auth/AccessDenied";
				options.SlidingExpiration = true;
			});

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
				options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
				options.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
			})
			.AddCookie(IdentityConstants.ApplicationScheme);
		}

		private static void RegisterRepositories(IServiceCollection services)
		{
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IChurnRiskAssessmentRepository, ChurnRiskAssessmentRepository>();
			services.AddScoped<IGameActionRepository, GameActionRepository>();
			services.AddScoped<IGameLevelRepository, GameLevelRepository>();
			services.AddScoped<IGameRepository, GameRepository>();
			services.AddScoped<IGameSessionRepository, GameSessionRepository>();
			services.AddScoped<IPersonalizationSettingRepository, PersonalizationSettingRepository>();
			services.AddScoped<IUserProfileRepository, UserProfileRepository>();
			services.AddScoped<IProgressMetricRepository, ProgressMetricRepository>();
			services.AddScoped<IProgressReportRepository, ProgressReportRepository>();
			services.AddScoped<IUserAcquisitionRepository, UserAcquisitionRepository>();
			services.AddScoped<IUserMetricRepository, UserMetricRepository>();
			services.AddScoped<IWeeklyUsageSummaryRepository, WeeklyUsageSummaryRepository>();
		}

		private static void RegisterApplicationServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IChurnRiskAssessmentService, ChurnRiskAssessmentService>();
			services.AddScoped<IGameActionService, GameActionService>();
			services.AddScoped<IGameLevelService, GameLevelService>();
			services.AddScoped<IGameService, GameService>();
			services.AddScoped<IGameSessionService, GameSessionService>();
			services.AddScoped<IPersonalizationSettingService, PersonalizationSettingService>();
			services.AddScoped<IUserProfileService, UserProfileService>();
			services.AddScoped<IProgressMetricService, ProgressMetricService>();
			services.AddScoped<IProgressReportService, ProgressReportService>();
			services.AddScoped<IUserAcquisitionService, UserAcquisitionService>();
			services.AddScoped<IUserMetricService, UserMetricService>();
			services.AddScoped<IWeeklyUsageSummaryService, WeeklyUsageSummaryService>();
		}

		//private static void RegisterValidation(IServiceCollection services)
		//{
		//	services.AddTransient<IValidator<FlatAssignmentDto>, FlatAssignmentDtoValidator>();
		//	services.AddTransient<IValidator<FlatDto>, FlatDtoValidator>();
		//}

		private static void RegisterAutoMapper(IServiceCollection services)
		{
			var mapperConfig = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<Profiles.UserProfile>();
				cfg.AddProfile<ChurnRiskAssessmentProfile>();
				cfg.AddProfile<GameActionProfile>();
				cfg.AddProfile<GameLevelProfile>();
				cfg.AddProfile<GameProfile>();
				cfg.AddProfile<GameSessionProfile>();
				cfg.AddProfile<PersonalizationSettingProfile>();
				cfg.AddProfile<ProgressMetricProfile>();
				cfg.AddProfile<ProgressReportProfile>();
				cfg.AddProfile<UserAcquisitionProfile>();
				cfg.AddProfile<UserMetricProfile>();
				cfg.AddProfile<UserProfileProfile>();
				cfg.AddProfile<WeeklyUsageSummaryProfile>();
			});

			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);
		}
	}
}
