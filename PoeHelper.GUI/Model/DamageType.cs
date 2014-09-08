namespace PoeHelper.GUI.Model
{
	public class DamageType
	{
		public string Type { get; set; }
		public decimal Low { get; set; }
		public decimal High { get; set; }

		public decimal AverageDamage
		{
			get { return (Low + High)/2; }
		}
	}

	public class ModType
	{
		public int Amount
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}
	}
}