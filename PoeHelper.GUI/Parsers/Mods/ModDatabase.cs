using System;
using System.Collections.Generic;
using System.Linq;
using PoeHelper.GUI.Model;

namespace PoeHelper.GUI.Parsers.Mods
{
	public interface IModDatabase
	{
		int GetLevel(int amount, string modName);
	}

	public class ModDatabase : IModDatabase
	{
		private readonly IEnumerable<ModDefinition> modDefinitions;

		public ModDatabase(IEnumerable<ModDefinition> modDefinitions)
		{
			this.modDefinitions = modDefinitions;
		}

		public int GetLevel(int amount, string modName)
		{
			try
			{
				var tiers = modDefinitions
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
