﻿namespace Tamagotchi.Model
{
    public class Mascote
    {
        public required List<Ability> Abilities { get; set; }
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }        
    }
    public class Ability
    {       
        public required AbilityResult ability { get; set; }
        public bool Is_hidden { get; set; }
        public int Slot { get; set; }
    }
    public class AbilityResult
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
    }   

}
