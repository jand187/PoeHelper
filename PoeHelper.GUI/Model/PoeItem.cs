using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoeHelper.GUI.Model
{
	public class PoeItem
	{
		private readonly List<DamageType> damageTypes;

		public PoeItem()
		{
			damageTypes = new List<DamageType>();
		}

		public IEnumerable<DamageType> DamageTypes
		{
			get { return damageTypes; }
		}

		public decimal AttackSpeed { get; set; }

		public string Report()
		{
			var returnText = new StringBuilder();

			//foreach (var damageType in DamageTypes)
			//{
			//	returnText.AppendLine(string.Format("DPS ({0}): {1}", damageType.Type, damageType.AverageDamage));
			//}

			returnText.AppendLine(string.Format("APS: {0}", AttackSpeed));
			returnText.AppendLine(string.Format("DPS: {0}", DamageTypes.Sum(d => d.AverageDamage)*AttackSpeed));
			returnText.AppendLine(string.Format("Physical DPS: {0}", DamageTypes.Where(d => d.Type == "Physical").Sum(d => d.AverageDamage)*AttackSpeed));
			returnText.AppendLine(string.Format("Elemental DPS: {0}", DamageTypes.Where(d => d.Type == "Elemental").Sum(d => d.AverageDamage)*AttackSpeed));

			return returnText.ToString();
		}

		public void AddDamageType(DamageType damageType)
		{
			damageTypes.Add(damageType);
		}
	}
}
