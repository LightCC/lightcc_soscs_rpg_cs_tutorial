using System;

namespace Engine.Models
{
    public class Player
    {
        public string Name { get; set; }
        public string CharacterClass { get; set; }
        public int HP { get; set; }
        public int XP { get; set; }
        public int Level { get; set; }
        public int Gold { get; set; }
    }
}
