using System;
using System.Text.RegularExpressions;
using PoeHelper.GUI.Model;

namespace PoeHelper.GUI.Parsers.Mods
{
	public class AddedPropertyModParser : IParser<PoeItem>
	{
		private readonly IModDatabase modDatabase;
		private readonly string pattern;

		public AddedPropertyModParser(IModDatabase modDatabase)
		{
			this.modDatabase = modDatabase;
			pattern = @"\+(\d+) to ([\w ]+)";
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
					ModRequiredLevel = modDatabase.GetLevel(amount, string.Format("+ to {0}", name)),
					DisplayText = m => string.Format("+{0} to {1} ({2})", m.Amount, m.Name, m.ModRequiredLevel),
				});

			return target;
		}
	}
}
