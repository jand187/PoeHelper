using System;
using System.Text.RegularExpressions;
using PoeHelper.GUI.Model;

namespace PoeHelper.GUI.Parsers
{
	public class PhysicalDamagaParser : IParser<PoeItem>
	{
		public bool CanParse(string line)
		{
			return Regex.Match(line, @"^Physical Damage: (\d+)-(\d+)").Success;
		}

		public PoeItem Parse(string line, PoeItem target)
		{
			var match = Regex.Match(line, @"^Physical Damage: (\d+)-(\d+)");

			target.AddDamageType(new DamageType
			{
				Type = "Physical",
				Low = Convert.ToDecimal(match.Groups[1].Value),
				High = Convert.ToDecimal(match.Groups[2].Value),
			});

			return target;
		}
	}
}
