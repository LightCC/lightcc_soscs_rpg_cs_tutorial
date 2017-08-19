using Engine.Models;

namespace Engine.ViewModels
{
    public class GameSession
    {
        public Player CurrentPlayer { get; set; }

        public GameSession()
        {
            CurrentPlayer = new Player();
            CurrentPlayer.Name = "Mike";
            CurrentPlayer.CharacterClass = "Fighter";
            CurrentPlayer.HP = 10;
            CurrentPlayer.Gold = 1000000;
            CurrentPlayer.XP = 0;
            CurrentPlayer.Level = 1;
        }
    }
}
