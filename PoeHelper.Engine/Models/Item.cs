namespace PoeHelper.Engine.Models
{
	public class Item
	{
		public ItemRarity Rarity { get; set; }
		public ItemType ItemType { get; set; }
	}

	public enum ItemRarity
	{
		Unknown,
		Normal,
		Magic,
		Rare,
		Unique,
		Currency,
		Gem
	}

	public enum ItemType
	{
		Unknown,
		Ring,
		Amulet,
		Belt,
		Helmet,
		Gloves,
		Boots,
		Chest,
		Shield,
		Wand,
		Dagger,
		Claws,
		Scepter,
		Staff,
		Bow,
		Sword1H,
		Axe1H,
		Sword2H,
		Axe2H,
		Mace1H,
		Mace2H,
		SkillGem,
		Currency
	}
}
