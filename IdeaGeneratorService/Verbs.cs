namespace TeamUpSpace.IdeaGeneratorService
{
	public class Verbs
	{
		private readonly List<string> verbs = new List<string>() { "делать", "говорить", "слушать", "читать",
			"смотреть", "видеть", "писать", "рисовать", "играть", "петь", "танцевать", "бегать", "ходить",
			"сидеть", "лежать", "работать", "учиться", "учить", "научить", "обучать", "запоминать", "забывать", 
			"принимать", "давать", "получать", "покупать", "продавать", "заказывать", "готовить", "есть", "пить",
			"спать", "просыпаться", "одеваться", "раздеваться", "мыться", "чистить", "убирать" };

		public string GetRandomVerb()
		{
			int seed = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
			Random random = new Random(seed);
			return verbs[random.Next(0, verbs.Count)];
		}
	}
}
