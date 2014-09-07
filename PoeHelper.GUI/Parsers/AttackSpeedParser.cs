using System.Globalization;
using System.Text.RegularExpressions;
using PoeHelper.GUI.Model;

namespace PoeHelper.GUI.Parsers
{
	public class AttackSpeedParser : IParser<PoeItem>
	{
		public bool CanParse(string line)
		{
			return Regex.Match(line, @"^Attacks per Second: (\d+\.\d+)").Success;
		}

		public PoeItem Parse(string line, PoeItem target)
		{
			var match = Regex.Match(line, @"^Attacks per Second: (\d+\.\d+)");
			target.AttackSpeed = decimal.Parse(match.Groups[1].Value, new CultureInfo("en"));
			return target;
		}
	}
}