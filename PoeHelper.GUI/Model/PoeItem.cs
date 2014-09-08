using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoeHelper.GUI.Model
{
	public class PoeItem
	{
		private readonly List<DamageType> damageTypes;
		private readonly List<ModType> modTypes;

		public PoeItem()
		{
			damageTypes = new List<DamageType>();
			modTypes = new List<ModType>();
		}

		public IEnumerable<DamageType> DamageTypes
		{
			get
			{
				return damageTypes;
			}
		}

		public decimal AttackSpeed
		{
			get;
			set;
		}

		public int ItemLevel
		{
			get;
			set;
		}

		public string Report()
		{
			var returnText = new StringBuilder();

			returnText.AppendLine(string.Format("APS: {0}", AttackSpeed));
			returnText.AppendLine(string.Format("DPS: {0}", DamageTypes.Sum(d => d.AverageDamage)*AttackSpeed));
			returnText.AppendLine(string.Format("Physical DPS: {0}", DamageTypes.Where(d => d.Type == "Physical").Sum(d => d.AverageDamage)*AttackSpeed));
			returnText.AppendLine(string.Format("Elemental DPS: {0}", DamageTypes.Where(d => d.Type == "Elemental").Sum(d => d.AverageDamage)*AttackSpeed));
			returnText.AppendLine(string.Format("Item level: {0}", ItemLevel));
			returnText.AppendLine();
			returnText.AppendLine("Mods:");
			foreach (var modType in modTypes)
			{
				returnText.AppendLine(modType.ToString());
			}

			return returnText.ToString();
		}

		public void AddDamageType(DamageType damageType)
		{
			damageTypes.Add(damageType);
		}

		public void AddMod(ModType modType)
		{
			modTypes.Add(modType);
		}
	}
}
