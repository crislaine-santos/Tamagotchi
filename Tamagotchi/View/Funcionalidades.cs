using RestSharp;
using Tamagotchi.Controller;
using Tamagotchi.Model;

namespace Tamagotchi.View
{
    public class Funcionalidades
    {        
        private MascoteInteracoes mascoteAdotado = new();
        private string? NomeMascote { get; set; }     
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
            string? input = Console.ReadLine();
            int escolha;
            Console.Clear();

            if (int.TryParse(input, out escolha)) 
            {
                switch (escolha)
                {
                    case 1:
                        ListarMascotesDisponiveis();
                        break;
                    case 2:
                        InteragirMascote();
                        break;
                    case 3:
                        Console.WriteLine("\nObrigado por jogar! Até a próxima! : )");
                        break;
                    default:
                        Console.WriteLine("\n**********OPÇÃO INVÁLIDA**********");
                        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
                        Console.ReadKey();
                        Console.Clear();
                        Menu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\n**********ENTRADA INVÁLIDA, POR FAVOR DIGITE UM NÚMERO**********");
                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
                Console.ReadKey();
                Console.Clear();
                Menu();
            }


        }
        public void ListarMascotesDisponiveis() 
        {
            var client = new RestClient("https://pokeapi.co");

            Console.Clear();
            Console.WriteLine("\n--------------------------------ADOTAR UM MASCOTE--------------------------------\n");
            Console.WriteLine("Escolha uma espécie\n");
            List<string> listaPokemons = new() { "bulbasaur", "charmander", "squirtle", "pikachu" };
            foreach (string pokemon in listaPokemons)
            {

                ObterInformaoces.ObterNomeMascotePorString(client, pokemon).Wait();
            }
            
            Console.WriteLine("\n");
            NomeMascote = Console.ReadLine();            
            
            if (listaPokemons.Contains(NomeMascote!))
            {
                Console.Clear();
                ListarOQueDeseja();
            }
            else
            {                
                Console.WriteLine($"\nO mascote digitado não existe! Por favor escolha um mascote existente na lista" +
                                  $"\nPressione qualquer tecla para voltar");               
                Console.ReadKey();                
                ListarMascotesDisponiveis();
            }                   
        }
        public void ListarOQueDeseja()
        {
            var client = new RestClient("https://pokeapi.co");

            Console.WriteLine("\n---------------------------------------------------------------------------------\n");
            Console.WriteLine("O Que Você Deseja?\n");
            Console.WriteLine($"1 - Saber Mais sobre o {NomeMascote}");
            Console.WriteLine($"2 - Adotar {NomeMascote}");
            Console.WriteLine($"3- Voltar");
            string? input = Console.ReadLine();
            int escolha;
            Console.Clear();

            if (int.TryParse(input, out escolha)) 
            {
                if (escolha == 1)
                {
                    ObterInformaoces.ObterInformacoesMascoteCompleto(client, NomeMascote!).Wait();

                    ListarOQueDeseja();
                }
                else if (escolha == 2)
                {
                    var tamagotchi = new MascoteInteracoes();
                    tamagotchi.AtualizarPropriedade(NomeMascote!);
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
                else if (escolha == 3)
                {
                    ListarMascotesDisponiveis();
                }
                else
                {
                    Console.WriteLine("\n**********OPÇÃO INVÁLIDA**********");
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    Console.Clear();
                    ListarOQueDeseja();
                }
            }
            else
            {               
                Console.WriteLine("\n**********ENTRADA INVÁLIDA, POR FAVOR DIGITE UM NÚMERO**********");
                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
                Console.ReadKey();
                Console.Clear();
                ListarOQueDeseja();
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
            Console.Write("\nEscolha uma opção: ");
            string? input = Console.ReadLine();
            int escolha;

            if (int.TryParse(input, out escolha)) 
            {
               switch (escolha) 
               { 
                   case 1:                   
                       mascoteAdotado.MostrarStatus();
                       OpçãoVoltarMenu();                    
                     break;
                   case 2:
                       mascoteAdotado.Alimentar();
                       OpçãoVoltarMenu();
                       break;
                   case 3:                    
                       mascoteAdotado.Brincar();
                       OpçãoVoltarMenu();
                       break;
                   case 4:
                       mascoteAdotado.Descansar();
                       OpçãoVoltarMenu();
                       break;
                   case 5:
                       Console.Clear();
                       Menu();
                       break;
                   default:
                        Console.Clear();
                        Console.WriteLine("\n**********OPÇÃO INVÁLIDA**********");
                        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu interação...");
                        Console.ReadKey();                       
                        InteragirMascote();
                        break;
               }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\n**********ENTRADA INVÁLIDA, POR FAVOR DIGITE UM NÚMERO**********");
                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
                Console.ReadKey();
                
                InteragirMascote();
            }
        }         
        public void OpçãoVoltarMenu()
        {
            Console.WriteLine("\n\nPressione qualquer tecla para voltar ao menu interação...");
            Console.ReadKey();
            Console.Clear();
            InteragirMascote();
        }                 
    }
}
