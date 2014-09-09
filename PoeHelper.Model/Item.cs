using System.Collections.Generic;

namespace PoeHelper.Model
{
	public class Item
	{
		public Definition Definition { get; set; }
		public IEnumerable<IProperty> Properties { get; set; }
		public IEnumerable<IRequirements> Requirements { get; set; }
		public IEnumerable<IMod> ExlicitMods { get; set; }
		public IEnumerable<ISocket> Sockets { get; set; }
		public int ItemLevel { get; set; }
		public string LoreText { get; set; }
	}
}
