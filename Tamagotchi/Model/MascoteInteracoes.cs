namespace Tamagotchi.Model
{
   
    public class MascoteInteracoes
    {       
        public int Alimentacao { get; private set; } 
        public int Humor { get; private set; } 
        public int Energia { get; private set; }     
        public string? Nome { get; set; }        

        public MascoteInteracoes() 
        {
            var rend = new Random(); 
            Alimentacao = rend.Next(11); 
            Humor = rend.Next(11);
            Energia = rend.Next(11);
        }

        public void AtualizarPropriedade(string mascote)
        {
            Nome = mascote;
        }

        public void Alimentar()
        {
            Alimentacao = Math.Min(Alimentacao + 2, 10); 
            Energia = Math.Max(Energia - 1, 0); 

            Console.Clear();
            Console.WriteLine("(=^w^=)\n");
            Console.WriteLine("Mascote Alimentado!");
        }

        public void Brincar()
        {
            Humor = Math.Min(Humor + 3, 10);
            Energia = Math.Max(Energia - 2, 0);
            Alimentacao = Math.Max(Alimentacao - 1, 0);

            Console.Clear();
            Console.WriteLine("(=^w^=)\n");
            Console.WriteLine("Mascote está feliz!");
        }

        public void Descansar()
        {
            Energia = Math.Min(Energia + 4, 10);
            Humor = Math.Max(Humor - 1, 0);

            Console.Clear();
            Console.WriteLine("(- 0 -)\n");
            Console.WriteLine("Mascote está dormindo!");
        }

        public void MostrarStatus()
        {
            Console.Clear();
            Console.WriteLine($"Status do Mascote: {Nome}\n");
            Console.WriteLine($"Alimentação: {Alimentacao}");
            Console.WriteLine($"Humor: {Humor}");
            Console.WriteLine($"Energia: {Energia}");            

        }
    }
}
