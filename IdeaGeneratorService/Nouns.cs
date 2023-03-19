namespace TeamUpSpace.IdeaGeneratorService
{
	public class Nouns
	{
		private readonly List<string> nouns = new List<string>() { "еда", "напитки", "транспорт", "одежда",
			"обувь", "мобильные устройства", "компьютеры", "телевизоры", "музыка", "фильмы", "книги", "журналы",
			"газеты", "социальные сети", "игры", "спорт", "фитнес", "здоровье", "красота", "работа", "учеба", 
			"домашние животные", "природа", "путешествия", "банкоматы", "банки", "страховые компании", "магазины", 
			"супермаркеты", "рестораны", "кафе", "парки", "детские площадки", "медицинские учреждения", "почта",
			"аптеки", "косметика", "парикмахерские", "ремонтные услуги" };
		private Random random;
		public Nouns(Random rand)
		{
			random = rand;
		}
		public string GetRandomNoun()
		{
			int peek = random.Next(0, nouns.Count);
			return nouns[peek];

		}
	}
}
