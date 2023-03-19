namespace TeamUpSpace.IdeaGeneratorService
{
	public class Adjectives
	{
		private readonly List<string> adjectives = new List<string>() { "удобный", "комфортный", "мягкий", "твердый", "легкий", "тяжелый",
			"мощный", "слабый", "быстрый", "медленный", "новый", "старый", "свежий", "засохший", "красивый", "уродливый",
			"яркий", "тусклый", "высокий", "низкий", "длинный", "короткий", "широкий", "узкий", "гладкий", "шершавый",
			"прочный", "хрупкий", "толстый", "тонкий", "большой", "маленький", "громкий", "тихий", "бесшумный", "безмолвный",
			"яростный", "спокойный", "радостный", "грустный" };

		public string GetRandomAdjective()
		{
			int seed = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
			Random random = new Random(seed);
			return adjectives[random.Next(0,adjectives.Count)];
		}
	}
}
