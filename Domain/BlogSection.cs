using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class BlogSection
	{
		public string Type { get; set; }
		public string Align { get; set; }
		public ICollection<BlogSectionChild> Children { get; set; }
	}
}
