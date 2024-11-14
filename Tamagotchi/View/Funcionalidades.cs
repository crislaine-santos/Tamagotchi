using RestSharp;
using Tamagotchi.Controller;
using Tamagotchi.Model;

namespace Tamagotchi.View
{
    public class Funcionalidades
    {        
        private MascoteInteracoes mascoteAdotado = new MascoteInteracoes();
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
            Console.WriteLine("2 - Interagir com meu mascote");           
            Console.WriteLine("3 - Sair do jogo\n");
            Console.Write("O que vc deseja fazer? ");
            var escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    ListarMascotesDisponiveis();
                    break;
                case 2:
                    InteragirMascote();
                    break;
                case 3:
                    Console.WriteLine("\nObrigado por jogar! Até a próxima!");
                    break;                
            }

        }

        async public void ListarMascotesDisponiveis()
        {
            var client = new RestClient("https://pokeapi.co");

            Console.Clear();
            Console.WriteLine("\n--------------------------------ADOTAR UM MASCOTE--------------------------------\n");
            Console.WriteLine("Escolha uma espécie\n");
            List<string> listaPokemons = new List<string> { "bulbasaur", "charmander", "squirtle", "pikachu" };//Adotar um pet
            foreach (string pokemon in listaPokemons)
            {

                ObterInformaoces.ObterNomeMascotePorString(client, pokemon).Wait();
            }
            
            Console.WriteLine("\n");
            nomeMascote = Console.ReadLine();            
            
            if (listaPokemons.Contains(nomeMascote))
            {
                Console.Clear();
                listarOQueDeseja();
            }else
            {                
                Console.WriteLine($"\nO mascote digitado não existe! Por favor escolha um mascote existente na lista" +
                                  $"\nPressione qualquer tecla para voltar");               
                Console.ReadKey();                
                ListarMascotesDisponiveis();
            }
                   
        }
        async public void listarOQueDeseja()
        {
            var client = new RestClient("https://pokeapi.co");

            Console.WriteLine("\n---------------------------------------------------------------------------------\n");
            Console.WriteLine("O Que Você Deseja?\n");
            Console.WriteLine($"1 - Saber Mais sobre o {nomeMascote}");
            Console.WriteLine($"2 - Adotar {nomeMascote}");
            Console.WriteLine($"3- Voltar");
            var resposta = int.Parse(Console.ReadLine());
            Console.Clear();

            if (resposta == 1)
            {
                ObterInformaoces.ObterInformacoesMascoteCompleto(client, nomeMascote).Wait();

                listarOQueDeseja();
            }
            else if (resposta == 2)
            {                
                var tamagotchi = new MascoteInteracoes();
                tamagotchi.AtualizarPropriedade(nomeMascote);
                mascoteAdotado = tamagotchi;

                Console.WriteLine($"MASCOTE ADOTADO COM SUCESSO, O OVO ESTA CHOCANDO: ");
                Console.WriteLine("────────────────────────────");
                Console.WriteLine("───────────▄████▄───────────");
                Console.WriteLine("─────────▄████████▄─────────");
                Console.WriteLine("─────────██████████─────────");
                Console.WriteLine("─────────▀████████▀─────────");
                Console.WriteLine("────────────▀██▀────────────");
                Console.WriteLine("────────────────────────────");

                Console.WriteLine("\n\nPressione qualquer tecla para voltar ao menu principal...");
                Console.ReadKey();
                Console.Clear();
                Menu();
            }
            else
            {
                ListarMascotesDisponiveis();
            }
        }

        public void InteragirMascote()
        {

            Console.Clear();
            Console.WriteLine("\n---------------------------------MENU INTERAÇÃO---------------------------------\n");            
            Console.WriteLine("1- Saber como o mascote está");
            Console.WriteLine("2- Alimentar o mascote");
            Console.WriteLine("3- Brincar com o mascote");
            Console.WriteLine("4- Por o mascote para dormir");
            Console.WriteLine("5- Voltar para o menu principal");
            Console.Write("Escolha uma opção: ");
            var escolha = int.Parse(Console.ReadLine());

            switch (escolha) 
            { 
                case 1:
                    //MascoteInteracoes.MostrarStatus();
                    mascoteAdotado.MostrarStatus();
                  break;
                case 2:
                    mascoteAdotado.Alimentar();
                    //MascoteInteracoes.Alimentar();
                    break;
                case 3:
                    //MascoteInteracoes.Brincar();
                    mascoteAdotado.Brincar();
                    break;
                case 4:
                    mascoteAdotado.Descansar();
                    //MascoteInteracoes.Descansar();
                    break;
                case 5:
                        Menu();
                    break;

            }

        }   
                 
    }
}
