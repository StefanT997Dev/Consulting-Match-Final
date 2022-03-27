using Application.DTOs;
using Application.Interfaces.Repositories.Mentors;
using Application.Mentors;
using AutoFixture;
using Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.QueryTests
{
	public class MentorsDetailsHandlerTests
	{
		private Details.Handler _sut;
		private Details.Query _query;
		private readonly CancellationToken _cancellationToken;
		public MentorsDetailsHandlerTests()
		{
			_cancellationToken = new CancellationToken();
		}

		[Fact]
		public async Task Handle_UserDoesNotGetReturnedFromRepo_IsSuccessIsFalse()
		{
			var fixture = new Fixture();
			var id = fixture.Build<string>().Create();
			_query = new Details.Query
			{
				Id = id 
			};
			var repository = new Mock<IMentorsRepository>();
			repository.Setup(repo => repo.GetMentorAsync<MentorDisplayDto>(
				id
			)).ReturnsAsync(It.Is<MentorDisplayDto>(x => x == null));
			_sut = new Details.Handler(repository.Object);

			var result = await _sut.Handle(_query, _cancellationToken);

			Assert.False(result.IsSuccess);
		}

		[Fact]
		public async Task Handle_UserReturnedFromRepo_ReturnsSuccess()
		{
			var fixture = new Fixture();
			var id = fixture.Build<string>().Create();
			_query = new Details.Query
			{
				Id = id
			};
			var mentorDto = new MentorDisplayDto();
			var repository = new Mock<IMentorsRepository>();
			repository.Setup(repo => repo.GetMentorAsync<MentorDisplayDto>(
				id
			)).ReturnsAsync(mentorDto);
			_sut = new Details.Handler(repository.Object);

			var result = await _sut.Handle(_query, _cancellationToken);

			Assert.True(result.IsSuccess);
		}
	}
}
