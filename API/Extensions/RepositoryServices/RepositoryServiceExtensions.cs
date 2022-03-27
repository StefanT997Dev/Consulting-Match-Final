using Application.Interfaces.Repositories.Blogs;
using Application.Interfaces.Repositories.Categories;
using Application.Interfaces.Repositories.JobApplications;
using Application.Interfaces.Repositories.Mentors;
using Application.Interfaces.Repositories.Mentorship;
using Application.Interfaces.Repositories.Package;
using Application.Interfaces.Repositories.Reviews;
using Infrastructure.RepositoriesImpl;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions.RepositoryServices
{
	public static class RepositoryServiceExtensions
	{
		public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
		{
			services.AddScoped<IMentorsRepository, MentorsRepository>();
			services.AddScoped<ICategoriesRepository, CategoriesRepository>();
			services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
			services.AddScoped<IReviewsRepository, ReviewsRepository>();
			services.AddScoped<IMentorshipRepository, MentorshipRepository>();
			services.AddScoped<IPackageRepository, PackageRepository>();
			services.AddScoped<IBlogRepository, BlogRepository>();

			return services;
		}
	}
}