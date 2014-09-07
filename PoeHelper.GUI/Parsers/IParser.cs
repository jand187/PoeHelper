namespace PoeHelper.GUI.Parsers
{
	public interface IParser<TEntity>
	{
		bool CanParse(string line);
		TEntity Parse(string line, TEntity target);
	}
}