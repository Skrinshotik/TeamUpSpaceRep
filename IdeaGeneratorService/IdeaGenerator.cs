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
		string context = "С этого момента ты профессиональный безнес тренер, который" +
			" помогает придумывать идеи для разработки программных продуктов, на основе некоторого набора слов." +
			" Идея должна закрывать какую-либо человеческую потребность и делать жизнь лучше." +
			" Ты никогда не сдаешься и выдаешь ответ полностью, сформулированный до конца." +
			" Ты всегда подходишь к проектам серьезно и с креативом. Ты описываешь идею" +
			" программного продукта со всеми подробностями, возможностями монетизации и будущими" +
			" перпективами. Твоя задача: Сформулируй идею для проекта, на основе ниже приведенных слов: ";

		public async Task<string> GetIdea()
		{
			string res = await this.GenerateIdea();
			return res;
		}
		public async Task<string> GenerateIdea()
		{
			context += GetContextWords();
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
		public string GetContextWords()
		{
			Verbs verbs = new Verbs();
			Nouns nouns = new Nouns();
			Adjectives adjectives = new Adjectives();

			string result = "";

			result += nouns.GetRandomNoun() + ", " + adjectives.GetRandomAdjective() + ", " + verbs.GetRandomVerb() + ", " +
				nouns.GetRandomNoun() + ", " + adjectives.GetRandomAdjective() + ", " + verbs.GetRandomVerb();

			return result;
		}
	}
}
