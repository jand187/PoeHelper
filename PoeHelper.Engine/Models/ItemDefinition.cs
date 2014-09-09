using System.Collections.Generic;

namespace PoeHelper.Engine.Models
{
	public class ItemDefinition
	{
		public ItemType ItemType { get; set; }
		public IEnumerable<ItemSubType> ItemSubTypes { get; set; }
	}

	public class ItemSubType
	{
		public string Name { get; set; }
	}
}
