﻿namespace TeamUpSpace.IdeaGeneratorService
{
	public class Extra
	{
		private readonly List<string> extra = new List<string>() {
				"софт", "облачные технологии", "программирование", "Интернет вещей",
				"кибербезопасность", "сетевое оборудование", "виртуализация",
				"искусственный интеллект", "блокчейн", "аналитика данных",
				"машинное обучение", "кластеризация", "хранение данных",
				"сетевая безопасность", "цифровая трансформация",
				"электронная коммерция", "электронная почта", "мобильное приложение",
				"робототехника", "технологии голосового управления", "веб-разработка",
				"информационные системы", "обработка естественного языка",
				"дизайн интерфейсов", "технологии распознавания образов",
				"графический дизайн", "разработка игр", "технологии беспроводной связи",
				"системы управления базами данных", "автоматизация процессов",
				"технологии виртуальной реальности", "интернет-маркетинг",
				"технологии автоматической идентификации", "аудио- и видеотехнологии",
				"технологии распределенных реестров", "технологии геолокации",
				"системы электронной подписи", "технологии микросервисов",
				"компьютерные сети", "вычислительная техника", "программное обеспечение"
				};
		private int seed;
		private Random random;
		public Extra()
		{
			seed = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
			random = new Random(seed);
		}
		public string GetRandomExtra()
		{
			return extra[random.Next(0, extra.Count)];
		}
	}
}