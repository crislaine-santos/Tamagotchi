using RestSharp;
using Newtonsoft.Json;
using Tamagotchi;
using System.Collections.Generic;
using System.Xml;


Funcionalidades funcionalidades = new Funcionalidades();

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
        funcionalidades.listarMascotesDisponiveis();
        break;
    case 2:
        funcionalidades.VerMascotesAdotados();
        break;
    case 3:
        Console.WriteLine("\nObrigado por jogar! Até a próxima!");
        break;

}

