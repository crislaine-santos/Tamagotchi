namespace Tamagotchi.Model
{
   
    public class MascoteInteracoes
    {       
        public int Alimentacao { get; private set; } //fome
        public int Humor { get; private set; } //brincar
        public int Energia { get; private set; } // descanso       
        public string? Nome { get; set; }        

        public MascoteInteracoes() //esse construtor garante que o Tamagotchi tenha valores aleatórios para suas necessidades básicas
        {
            var rend = new Random(); //"Random" é para criar umm numero aleatório
            Alimentacao = rend.Next(11); // O método Next() da classe Random gera um número aleatório não negativo menor que o valor especificado
            Humor = rend.Next(11);
            Energia = rend.Next(11);
        }

        public void AtualizarPropriedade(string mascote)
        {
            Nome = mascote;
        }

        public void Alimentar()
        {
            Alimentacao = Math.Min(Alimentacao + 2, 10); //"Math.Min" garante que o valor de Alimentação nunca seja maior que 10
            Energia = Math.Max(Energia - 1, 0); //garante que o valor de Energia nunca seja negativo

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
