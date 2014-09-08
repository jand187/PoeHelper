using System;

namespace PoeHelper.GUI.Model
{
	public class DamageType
	{
		public string Type
		{
			get;
			set;
		}

		public decimal Low
		{
			get;
			set;
		}

		public decimal High
		{
			get;
			set;
		}

		public decimal AverageDamage
		{
			get
			{
				return (Low + High)/2;
			}
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

		public Func<ModType, string> DisplayText
		{
			get;
			set;
		}

		public void SetDiaplayFormat(Func<ModType, string> format)
		{
			DisplayText = format;
		}

		public override string ToString()
		{
			return DisplayText.Invoke(this);
		}
	}
}
