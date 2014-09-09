using System.Collections.Generic;

namespace PoeHelper.Model
{
	public class SubType
	{
		public string Name { get; set; }
		public IEnumerable<IMod> ImplicitMods { get; set; }
	}
}