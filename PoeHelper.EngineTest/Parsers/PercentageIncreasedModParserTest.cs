using PoeHelper.Engine.Parsers;
using Xunit;

namespace PoeHelper.EngineTest.Parsers
{
	internal class PercentageIncreasedModParserTest
	{
		[Fact]
		public void WhatDoesItTest()
		{
			var target = new PercentageIncreasedModParser();
			var line = "144% increased Physical Damage";

			var mod = target.Parse(line);
		}
	}
}
