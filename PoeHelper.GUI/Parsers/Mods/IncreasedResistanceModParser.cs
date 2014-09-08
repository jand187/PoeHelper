using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using PoeHelper.GUI.Model;

namespace PoeHelper.GUI.Parsers.Mods
{
	public class IncreasedResistanceModParser : IParser<PoeItem>
	{
		private readonly IEnumerable<ModDefinition> modTiers;
		private readonly string pattern;

		public IncreasedResistanceModParser(IEnumerable<ModDefinition> modDefinitions)
		{
			pattern = @"\+(\d+)% to ([\w ]+) Resistance$";
			modTiers = modDefinitions;
		}

		public bool CanParse(string line)
		{
			return Regex.Match(line, pattern).Success;
		}

		public PoeItem Parse(string line, PoeItem target)
		{
			var match = Regex.Match(line, pattern);
			var amount = Convert.ToInt32(match.Groups[1].Value);
			var name = match.Groups[2].Value;
			target.AddMod(
				new ModType
				{
					Amount = amount,
					Name = name,
					ModRequiredLevel = GetLevel(amount, string.Format("+% to {0} Resistance", name)),
					DisplayText = (m) => string.Format("+{0}% to {1} Resistance ({2})", m.Amount, m.Name, m.ModRequiredLevel),
				});
			return target;
		}

		private int GetLevel(int amount, string modName)
		{
			try
			{
				var tiers = modTiers
					.Single(m => m.Name == modName)
					.Tiers.ToList();

				return tiers
					.Single(t => t.DamageRange.IsWithin(amount)).RequiredLevel;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
			return 0;
		}

	}
}
