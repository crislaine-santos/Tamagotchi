using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi
{
    public class Funcionalidades
    {
        async public void listarMascotesDisponiveis()
        {
            var client = new RestClient("https://pokeapi.co");

            Console.Clear();
            Console.WriteLine("\n--------------------------------ADOTAR UM MASCOTE--------------------------------\n");
            Console.WriteLine("Escolha uma espécie\n");
            List<int> listaPokemons = new List<int> { 1, 4, 7, 25 };   //Adotar um pet
            foreach (int pokemon in listaPokemons)
            {

                ObterInformaoces.ObterNomeMascote(client, pokemon).Wait();
            }

            var resposta = Console.ReadLine();
            listarOQueDeseja(resposta);
            //Thread.Sleep(3000);
            var resposta2 = Console.ReadLine();
            listarOQueDeseja(resposta);

        }

        async public void listarOQueDeseja(string mascote)
        {
            var client = new RestClient("https://pokeapi.co");

            Console.Clear();
            Console.WriteLine("\n---------------------------------------------------------------------------------\n");
            Console.WriteLine("O Que Você Deseja?\n");
            Console.WriteLine($"1 - Saber Mais sobre o {mascote}");
            Console.WriteLine($"2 - Adotar {mascote}");
            Console.WriteLine($"3- Voltar");
            var resposta = int.Parse(Console.ReadLine());
            Console.Clear();

            if (resposta == 1)
            {
                ObterInformaoces.ObterInformacoesMascoteCompleto(client, mascote).Wait();
            }
            else if (resposta == 2)
            {
                Console.WriteLine($"MASCOTE ADOTADO COM SUCESSO, O OVO ESTA CHOCANDO: ");
                Console.WriteLine("──────────────");
                Console.WriteLine("────▄████▄────");
                Console.WriteLine("──▄████████▄──");
                Console.WriteLine("──██████████──");
                Console.WriteLine("──▀████████▀──");
                Console.WriteLine("─────▀██▀─────");
                Console.WriteLine("──────────────");
            }
            else
            {
                listarMascotesDisponiveis();
            }

        }
        public void VerMascotesAdotados()
        {
            Console.Clear();
            Console.WriteLine("\n--------------------------------SEUS MASCOTES------------------------------------\n");
        }
    }
}
