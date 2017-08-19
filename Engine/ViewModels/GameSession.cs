using Engine.Models;

namespace Engine.ViewModels
{
    class GameSession
    {
        public Player CurrentPlayer { get; set; }

        public GameSession()
        {
            CurrentPlayer = new Player();
            CurrentPlayer.Name = "Mike";
            CurrentPlayer.Gold = 100000;
        }
    }
}
