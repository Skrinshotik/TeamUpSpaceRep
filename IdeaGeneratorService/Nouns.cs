namespace TeamUpSpace.IdeaGeneratorService
{
	public class Nouns
	{
		private readonly List<string> nouns = new List<string>() { "делать", "говорить", "слушать", "читать",
			"смотреть", "видеть", "писать", "рисовать", "играть", "петь", "танцевать", "бегать", "ходить",
			"сидеть", "лежать", "работать", "учиться", "учить", "научить", "обучать", "запоминать", "забывать", 
			"принимать", "давать", "получать", "покупать", "продавать", "заказывать", "готовить", "есть", "пить",
			"спать", "просыпаться", "одеваться", "раздеваться", "мыться", "чистить", "убирать" };
		private int seed;
		private Random random;
		public Nouns()
		{
			seed = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
			random = new Random(seed);
		}
		public string GetRandomNoun()
		{
			return nouns[random.Next(0, nouns.Count)];
		}
	}
}
