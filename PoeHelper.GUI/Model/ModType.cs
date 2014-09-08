using System;
using System.Collections.Generic;

namespace PoeHelper.GUI.Model
{
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

		public int ModRequiredLevel
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

	public class ModDefinition
	{
		public string Name
		{
			get;
			set;
		}

		public IEnumerable<ModTier> Tiers
		{
			get;
			set;
		}
	}

	public class ModTier
	{
		public int RequiredLevel
		{
			get;
			set;
		}

		public ValueRange DamageRange
		{
			get;
			set;
		}
	}

	public class ValueRange
	{
		public decimal Max
		{
			get;
			set;
		}

		public decimal Min
		{
			get;
			set;
		}

		public bool IsWithin(decimal value)
		{
			return value <= Max && value >= Min;
		}
	}
}
