﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
	public class CategoryDto : IGenericModel<Guid>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
	}
}
