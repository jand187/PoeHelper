using System.Collections.Generic;

namespace PoeHelper.Model
{
	public interface ISocket
	{
		SocketLocation Location { get; set; }
		IEnumerable<SocketLocation> Links { get; set; }
		SocketColor Color { get; set; }
	}
}