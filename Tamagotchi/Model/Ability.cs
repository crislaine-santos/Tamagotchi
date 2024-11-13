using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Model
{
    public class Ability
    {
        public AbilityResult ability { get; set; }
        public bool Is_hidden { get; set; }
        public int Slot { get; set; }
    }
}
