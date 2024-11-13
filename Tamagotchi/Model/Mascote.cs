using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Tamagotchi.Model
{
    public class Mascote
    {
        public List<Ability> Abilities { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }

    }

}
