using RestSharp;
using Newtonsoft.Json;
using Tamagotchi;
using System.Collections.Generic;

var client = new RestClient("https://pokeapi.co");

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
        Console.WriteLine(); //Ver mascostes
        break;
    case 3:
        break;

}

async void listarMascotesDisponiveis()
{
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
}

async void listarOQueDeseja(string mascote)
{
    Console.Clear();
    Console.WriteLine("\n---------------------------------------------------------------------------------\n");
    Console.WriteLine("O Que Você Deseja?:\n");
    Console.WriteLine("1 - Saber Mais");
    Console.WriteLine("2 - Adotar");
    Console.WriteLine("3- Voltar");
    var resposta = int.Parse(Console.ReadLine());
    Console.Clear();

    if (resposta == 1)
    {
        ObterInformaoces.ObterInformacoesMascoteCompleto(client, mascote).Wait();
    }

}


