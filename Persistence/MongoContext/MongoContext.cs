using Domain;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.MongoContext
{
	public class MongoContext : IDbContext
	{
		public MongoContext(IConfiguration configuration)
		{
			var client = new MongoClient(configuration.GetConnectionString("MongoConnection"));
			var database = client.GetDatabase("MongoBlogDB");

			Blogs = database.GetCollection<Blog>("Blogs");
		}
		public IMongoCollection<Blog> Blogs { get; }
	}
}
