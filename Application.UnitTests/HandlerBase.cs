﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UnitTests
{
	public class HandlerBase
	{
		protected readonly CancellationToken cancellationToken;
		public HandlerBase()
		{
			cancellationToken = new CancellationToken();
		}
	}
}
