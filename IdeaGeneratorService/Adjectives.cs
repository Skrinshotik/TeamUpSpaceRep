namespace TeamUpSpace.IdeaGeneratorService
{
	public class Adjectives
	{
		private readonly List<string> adjectives = new List<string>() { "удобный", "комфортный", "мягкий", "твердый", "легкий", "тяжелый",
			"мощный", "слабый", "быстрый", "медленный", "новый", "старый", "свежий", "засохший", "красивый", "уродливый",
			"яркий", "тусклый", "высокий", "низкий", "длинный", "короткий", "широкий", "узкий", "гладкий", "шершавый",
			"прочный", "хрупкий", "толстый", "тонкий", "большой", "маленький", "громкий", "тихий", "бесшумный", "безмолвный",
			"яростный", "спокойный", "радостный", "грустный" };
		private int seed;
		private Random random;
		public Adjectives(Random rand)
		{
			random = rand;
		}

		public string GetRandomAdjective()
		{
			int peek = random.Next(0, adjectives.Count);
			return adjectives[peek];

		}
	}
}
