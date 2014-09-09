using System;
using System.Collections.Generic;
using PoeHelper.Engine.Models;

namespace PoeHelper.Engine.Parsers
{
	internal interface IParser<TEntity, out TProperty>
	{
		IEnumerable<Func<Item, TProperty>> Parse(IEnumerable<string> lines);
	}
}
