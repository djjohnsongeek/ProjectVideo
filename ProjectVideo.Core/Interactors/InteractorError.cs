using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVideo.Core.Interactors
{
	public class InteractorError
	{
		public string Message { get; private set; }

		public InteractorError(string message)		{
			Message = message;
		}

	}
}
