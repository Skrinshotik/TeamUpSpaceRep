using System.IO;
using System.Net.Http;
using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TeamUpSpace.IdeaGeneratorService
{
	public class IdeaGenerator
	{
		string apiKey = "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";
		string model = "text-davinci-003";
		string endPoint = "https://api.openai.com/v1/completions";
		string ideaContext = "С этого момента ты профессиональный безнес тренер, который" +
			" помогает придумывать идеи для разработки программных продуктов, на основе некоторого набора слов." +
			" Идея должна закрывать какую-либо человеческую потребность и делать жизнь лучше." +
			" Ты никогда не сдаешься и выдаешь ответ полностью, сформулированный до конца." +
			" Ты всегда подходишь к проектам серьезно и с креативом. Ты описываешь идею" +
			" программного продукта со всеми подробностями, возможностями монетизации и будущими" +
			" перпективами. Твоя задача: Сформулируй идею для проекта, на основе ниже приведенных слов: ";
		string nameContext = "С этого момента ты гениальный креативщик, который всегда придумывает локаничные и красивые" +
			" названия для проектов по их описанию. Ты не многословен, но крайне точен и хорош в своем деле." +
			" Когда тебе присылают идею проекта, ты присылаешь одно название, которое прекрасно описывает проект" +
			" и соответствует правилам нейминга проектов. Твоя задача придумать название длинной в одно слово на английском языке" +
			" для следующего проекта: ";

		public async Task<string> GetIdea()
		{
			string res = GetContextWords();
			res = await this.GenerateResponse(ideaContext+res);
			return res;
		}

		public async Task<string> GetIdeaName(string idea)
		{
			string res = await this.GenerateResponse(nameContext+idea);
			return res;
		}

		private async Task<string> GenerateResponse(string context)
		{
			HttpClient client = new HttpClient();
			try
			{
				client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

				var body = new
				{
					prompt = context,
					model = model,
					temperature = 0.8,
					max_tokens = 1000,
				};
				HttpResponseMessage response = await client.PostAsync(endPoint,
					new StringContent(JsonConvert.SerializeObject(body),
					Encoding.UTF8, "application/json"));

				Stream stream = await response.Content.ReadAsStreamAsync();
				StreamReader reader = new StreamReader(stream);
				try
				{
					var result = await reader.ReadToEndAsync();
					var res = JsonConvert.DeserializeObject<Response>(result);

					string finalResponse = "";
					foreach(var i in res.choices)
					{
						finalResponse += i.text;
					}
					return finalResponse;
				}
				finally
				{
					reader.Dispose();
					stream.Dispose();
				}
			}
			finally
			{
				client.Dispose();
			}


		}
		private string GetContextWords()
		{
			int seed = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
			Random random = new Random(seed);
			Verbs verbs = new Verbs(random);
			Nouns nouns = new Nouns(random);
			Adjectives adjectives = new Adjectives(random);
			Extra extra = new Extra(random);

			string result = "";

			result += extra.GetRandomExtra() + ", " +
				nouns.GetRandomNoun() + ", " + adjectives.GetRandomAdjective() + ", " + verbs.GetRandomVerb() + ", " +
				nouns.GetRandomNoun() + ", " + adjectives.GetRandomAdjective() + ", " + verbs.GetRandomVerb();

			return result;
		}
	}
}
