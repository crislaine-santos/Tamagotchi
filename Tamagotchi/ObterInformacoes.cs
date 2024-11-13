using Newtonsoft.Json;
using RestSharp;


namespace Tamagotchi
{
    public static class ObterInformaoces
    {
        public static async Task ObterNomeMascote(RestClient client, int id) //"async, Task" que essa função é assíncrona
        {
            try
            {
                var request = new RestRequest($"/api/v2/pokemon/{id}", Method.Get);
                var resposta = await client.ExecuteAsync(request);

                if (resposta.IsSuccessStatusCode) // Essa propriedade retorna um valor booleano (verdadeiro ou falso) indicando se a operação HTTP foi bem-sucedida ou não.
                {
                    var respostaDeserializada = JsonConvert.DeserializeObject<Mascote>(resposta.Content);
                    NomeMascote(respostaDeserializada);
                }
                else
                {
                    Console.WriteLine("Desculpe não pude encontrar as informações!");
                }

            }
            catch (Exception mensage)
{
                Console.WriteLine(mensage);
            }
        }

        public static async Task ObterInformacoesMascoteCompleto(RestClient client, string mascote) 
        {
            try
            {
                var request = new RestRequest($"/api/v2/pokemon/{mascote}", Method.Get);
                var resposta = await client.ExecuteAsync(request);

                if (resposta.IsSuccessStatusCode) 
                {
                    var respostaDeserializada = JsonConvert.DeserializeObject<Mascote>(resposta.Content);
                    InfomacoesMascote(respostaDeserializada);
                }
                else
                {
                    Console.WriteLine("Desculpe não pude encontrar as informações!");
                }

            }
            catch (Exception mensage)
            {
                Console.WriteLine(mensage);
            }
        }

        public static void InfomacoesMascote(Mascote respostaDeserializada)
        {
            
            Console.WriteLine($"Nome: {respostaDeserializada.name}");
            Console.WriteLine($"ID: {respostaDeserializada.id}");
            Console.WriteLine($"Altura: {respostaDeserializada.weight}");
            Console.WriteLine($"Peso: {respostaDeserializada.height}");
            

            Console.WriteLine("Habilidades: ");
            foreach (var ability in respostaDeserializada.abilities)
            {
                var abilityResult = ability.ability;
                Console.WriteLine($"-{abilityResult.name}");
            }
            Console.WriteLine("===============");

        }

        public static void NomeMascote(Mascote respostaDeserializada)
        {
            Console.WriteLine($"Nome: {respostaDeserializada.name}");               
        }


    }
}
