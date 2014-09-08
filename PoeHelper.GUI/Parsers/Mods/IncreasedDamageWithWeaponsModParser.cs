using System;
using System.Text.RegularExpressions;
using PoeHelper.GUI.Model;

namespace PoeHelper.GUI.Parsers.Mods
{
	public class IncreasedDamageWithWeaponsModParser : IParser<PoeItem>
	{
		private readonly ModDatabase modDatabase;
		private readonly string pattern;

		public IncreasedDamageWithWeaponsModParser(ModDatabase modDatabase)
		{
			this.modDatabase = modDatabase;
			pattern = @"(\d+)% increased ([\w ]+) Damage with Weapons";
		}

		public bool CanParse(string line)
		{
			return Regex.Match(line, pattern).Success;
		}

		public PoeItem Parse(string line, PoeItem target)
		{
			var match = Regex.Match(line, pattern);
			var amount = Convert.ToInt32(match.Groups[1].Value);
			var name = match.Groups[2].Value.TrimEnd();
			target.AddMod(
				new ModType
				{
					Amount = amount,
					Name = name,
					//ModRequiredLevel = modDatabase.GetLevel(amount, string.Format("% increased {0} Damage with Weapons", name)),
					DisplayText = m => string.Format("{0}% increased {1} Damage with Weapons", m.Amount, m.Name),
				});

			return target;
		}
	}
}
