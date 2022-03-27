using Domain;
using MongoDB.Driver;

namespace Persistence.MongoContext
{
	public interface IDbContext
	{
		IMongoCollection<Blog> Blogs { get; }
	}
}
