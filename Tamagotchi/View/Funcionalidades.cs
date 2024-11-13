using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Controller;
using Tamagotchi.Model;

namespace Tamagotchi.View
{
    public class Funcionalidades
    {
        
        //private List<Mascote> mascotesAdotados = new List<Mascote>();
        private string nomeMascote {  get; set; } 
        public void Menu()
        {

            Console.WriteLine(@"
████████╗░█████╗░███╗░░░███╗░█████╗░░██████╗░░█████╗░████████╗░█████╗░██╗░░██╗██╗
╚══██╔══╝██╔══██╗████╗░████║██╔══██╗██╔════╝░██╔══██╗╚══██╔══╝██╔══██╗██║░░██║██║
░░░██║░░░███████║██╔████╔██║███████║██║░░██╗░██║░░██║░░░██║░░░██║░░╚═╝███████║██║
░░░██║░░░██╔══██║██║╚██╔╝██║██╔══██║██║░░╚██╗██║░░██║░░░██║░░░██║░░██╗██╔══██║██║
░░░██║░░░██║░░██║██║░╚═╝░██║██║░░██║╚██████╔╝╚█████╔╝░░░██║░░░╚█████╔╝██║░░██║██║
░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚═╝░░╚═╝░╚═════╝░░╚════╝░░░░╚═╝░░░░╚════╝░╚═╝░░╚═╝╚═╝ ");
            Console.WriteLine("\n--------------------------------------MENU--------------------------------------\n");
            Console.WriteLine("1 - Adotar um Mascote Virtual");
            Console.WriteLine("2 - Ver Meus Mascotes");
            Console.WriteLine("3 - Sair\n");
            Console.Write("O que vc deseja fazer? ");
            var escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    listarMascotesDisponiveis();
                    break;
                case 2:
                    VerMascotesAdotados();
                    break;
                case 3:
                    Console.WriteLine("\nObrigado por jogar! Até a próxima!");
                    break;

            }

        }
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

            //preciso por uma validação para o usuario não poder colocar um nome errado
            nomeMascote = Console.ReadLine();
            // se o nome do mascote nao estiver na lista de nomes de mascote, de um aviso falando pra digitar um nome certo e ler a key denovo

            Console.Clear();
            listarOQueDeseja(nomeMascote);           
           

        }



        async public void listarOQueDeseja(string mascote)
        {
            var client = new RestClient("https://pokeapi.co");

            
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

                listarOQueDeseja(mascote);
            }
            else if (resposta == 2)
            {
                
                //var pokemon = await ObterInformaoces.ObterNomeMascote(client, mascote);
                //AdcionarMascotesAdotados(pokemon);

                Console.WriteLine($"MASCOTE ADOTADO COM SUCESSO, O OVO ESTA CHOCANDO: ");
                Console.WriteLine("──────────────");
                Console.WriteLine("────▄████▄────");
                Console.WriteLine("──▄████████▄──");
                Console.WriteLine("──██████████──");
                Console.WriteLine("──▀████████▀──");
                Console.WriteLine("─────▀██▀─────");
                Console.WriteLine("──────────────");

                //Menu();
            }
            else
            {
                listarMascotesDisponiveis();
            }

        }
        public void VerMascotesAdotados()
        {
            //Console.Clear();
            //Console.WriteLine("\n--------------------------------SEUS MASCOTES------------------------------------\n");
            //if (mascotesAdotados.Count == 0)
            //{
            //    Console.WriteLine("Você não tem mascotes adotados no Momento!");
            //}
            //else 
            //{
            //    Console.WriteLine("Mascotes adotados: ");
            //    foreach (var mascote in mascotesAdotados) 
            //    {
            //        Console.WriteLine($"- {mascote.Name}, Id{mascote.Id}...");
            //    }
            //}

        }
        //public void AdcionarMascotesAdotados(Mascote mascote)
        //{
        //    mascotesAdotados.Add(mascote);
        //}
    }
}
