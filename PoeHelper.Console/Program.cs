using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PoeHelper.Console
{
	internal class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			System.Console.Write("Category name: ");
			var category = System.Console.ReadLine();

			var html = Clipboard.GetText(TextDataFormat.Html);
			var text = Clipboard.GetText(TextDataFormat.Text);
			var data= text.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
			
			var firstLine = data.First();
			var parsers = GetParsers(firstLine);

			var lines = data.Skip(1).ToArray();

			for (var index = 0; index < lines.Length; index += 2)
			{
				var item = ParseItem(lines[index] + lines[index]);
			}

			System.Console.WriteLine(text);

			System.Console.ReadKey();
		}

		private static IEnumerable<IParser> GetParsers(string firstLine)
		{
			return null;
			var headers = firstLine.Split(new[] { "\t" }, StringSplitOptions.None);
			foreach (var header in headers)
			{
				
			}
		}

		private static Item ParseItem(string line)
		{
			return null;
//			var props = line.Split(new[] {"\t"}, StringSplitOptions.None);
//			return new Item
//			{
//				Name = props[0],
//				ReuiredLevel = props[1],
//				RequiredStrength = props[2],
//				ReuiredDexterity = props[3],
//--				ReuiredIntelligence = props[1],
//				Damage = props[4],
//				CriticalStrikeChance = props[5],
//				AttacksPerSecond= props[6],
//				DamagePerSecond = props[7],
//			};
		}
	}

	internal interface IParser
	{
	}

	internal class Item
	{
		public string Name
		{
			get;
			set;
		}

		public string ReuiredLevel
		{
			get;
			set;
		}
	}
}
