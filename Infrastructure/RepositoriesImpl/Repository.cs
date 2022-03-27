using Application.Interfaces.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.RepositoriesImpl
{
	public class Repository<TInput> : IRepository<TInput> where TInput:class 
	{
		protected readonly DbContext context;
		protected readonly IMapper mapper;
		protected readonly DbSet<TInput> entities;
		protected readonly IConfigurationProvider mapperConfigurationProvider;

		public Repository(DbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
			entities = this.context.Set<TInput>();
			mapperConfigurationProvider = mapper.ConfigurationProvider;
		}

		public async Task<bool> AddAsync<TInputDto>(TInputDto input)
		{
			entities.Add(mapper.Map<TInput>(input));

			return await context.SaveChangesAsync() > 0;
		}

		public async Task<IEnumerable<TOutput>> FindAsync<TOutput>(Expression<Func<TInput, bool>> expression) where TOutput : class
		{
			return await entities
				.Where(expression)
				.ProjectTo<TOutput>(mapperConfigurationProvider)
				.ToListAsync();
		}

		public async Task<IEnumerable<TOutput>> GetAllAsync<TOutput>() where TOutput : class
		{
			return await entities
				.ProjectTo<TOutput>(mapperConfigurationProvider)
				.ToListAsync();
		}

		public async Task<TOutput> GetAsync<TOutput>(Expression<Func<TInput, bool>> expression1, Expression<Func<TOutput, bool>> expression2) where TOutput : class
		{
			return await entities
				.Where(expression1)
				.ProjectTo<TOutput>(mapperConfigurationProvider)
				.FirstOrDefaultAsync(expression2);
		}
	}
}
