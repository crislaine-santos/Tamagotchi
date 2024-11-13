using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Tamagotchi
{
    public class Mascote
    {
        public List<Ability> abilities { get; set; }              
        public int id { get; set; }        
        public string name { get; set; }        
        public int weight { get; set; }
        public int height { get; set; }

    } 

}
