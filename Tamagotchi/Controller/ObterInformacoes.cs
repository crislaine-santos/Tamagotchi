using Newtonsoft.Json;
using RestSharp;
using Tamagotchi.Model;


namespace Tamagotchi.Controller
{
    public static class ObterInformaoces
    {
        public static async Task ObterInformacoesMascoteCompleto(RestClient client, string mascote) 
        {
            try
            {
                var request = new RestRequest($"/api/v2/pokemon/{mascote}", Method.Get);
                var resposta = await client.ExecuteAsync(request);

                if (!string.IsNullOrEmpty(resposta.Content) && resposta.IsSuccessStatusCode) 
                {
                    var respostaDeserializada = JsonConvert.DeserializeObject<Mascote>(resposta.Content);
                    if (respostaDeserializada != null)
                    { 
                        InfomacoesMascote(respostaDeserializada); 
                    }
                    else
                    {
                        Console.WriteLine("Erro ao deserializar os dados.");
                    }
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
            Console.WriteLine($"Nome: {respostaDeserializada.Name}");
            Console.WriteLine($"ID: {respostaDeserializada.Id}");
            Console.WriteLine($"Altura: {respostaDeserializada.Weight}");
            Console.WriteLine($"Peso: {respostaDeserializada.Height}");

            Console.WriteLine("Habilidades: ");
            foreach (var ability in respostaDeserializada.Abilities)

            {
                var abilityResult = ability.ability; 
                Console.WriteLine($"-{abilityResult.Name}");
            }           

        }      
    }
}


