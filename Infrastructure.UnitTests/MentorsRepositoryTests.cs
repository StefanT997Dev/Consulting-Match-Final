using Application.Core;
using AutoFixture;
using AutoMapper;
using Domain;
using Infrastructure.RepositoriesImpl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Infrastructure.UnitTests
{
	public class MentorsRepositoryTests
	{
		[Theory]
		[InlineData(0, false)]
		[InlineData(5, true)]
		public async Task GetMentorsPaginatedAsync_MentorsExistOrNot_ReturnsAdequateResult(
			int numberOfMentors,
			bool returnsMentors
			)
		{
			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingProfiles());
			});
			var fixture = new Fixture();
			fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
			fixture.Behaviors.Add(new OmitOnRecursionBehavior());
			var users = fixture
				.Build<AppUser>()
				.With(u => u.Role, new Role { Id = 1, Name = "Mentor", Users = null })
				.CreateMany(numberOfMentors);

			// Insert seed data into the database using one instance of the context
			using (var context = new DataContext(CreateNewContextOptions()))
			{
				context.Users.AddRange(users);
				context.SaveChanges();

				MentorsRepository mentorsRepository = new MentorsRepository(context, mappingConfig.CreateMapper());
				var mentors = await mentorsRepository.GetMentorsPaginatedAsync(1, 5, null);

				var mentorsList = mentors.Item1.ToList();

				Assert.Equal(returnsMentors, mentorsList.Any());
			}
		}
		private static DbContextOptions<DataContext> CreateNewContextOptions()
		{
			// Create a fresh service provider, and therefore a fresh 
			// InMemory database instance.
			var fixture = new Fixture();
			var dbName = fixture.Build<string>().Create();
			var serviceProvider = new ServiceCollection()
				.AddEntityFrameworkInMemoryDatabase()
				.BuildServiceProvider();

			// Create a new options instance telling the context to use an
			// InMemory database and the new service provider.
			var builder = new DbContextOptionsBuilder<DataContext>();
			builder.UseInMemoryDatabase(dbName)
				   .UseInternalServiceProvider(serviceProvider);

			return builder.Options;
		}
	}
}
