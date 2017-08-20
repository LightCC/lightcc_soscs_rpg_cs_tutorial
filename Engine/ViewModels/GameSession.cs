using Engine.Models;
using Engine.Factories;
using System.ComponentModel;

namespace Engine.ViewModels
{
    public class GameSession : INotifyPropertyChanged
    {
        private Location _location;

        public World CurrentWorld { get; set; }
        public Player CurrentPlayer { get; set; }
        public Location CurrentLocation
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(HasLocationToNorth));
                OnPropertyChanged(nameof(HasLocationToWest));
                OnPropertyChanged(nameof(HasLocationToEast));
                OnPropertyChanged(nameof(HasLocationToSouth));
            }
        }

        public GameSession()
        {

            CurrentPlayer = new Player();
            CurrentPlayer.Name = "Mike";
            CurrentPlayer.CharacterClass = "Fighter";
            CurrentPlayer.HitPoints = 10;
            CurrentPlayer.Gold = 1000000;
            CurrentPlayer.ExperiencePoints = 0;
            CurrentPlayer.Level = 1;

            WorldFactory factory = new WorldFactory();
            CurrentWorld = factory.CreateWorld();

            CurrentLocation = CurrentWorld.LocationAt(0, -1);
            CurrentLocation.ImageName = "/Engine;component/Images/Locations/Home.png";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool HasLocationToNorth
        {
            get
            {
                return (CurrentWorld.LocationAt(CurrentLocation.XCoordinate,
                    CurrentLocation.YCoordinate + 1) != null);
            }
        }

        public bool HasLocationToWest
        {
            get
            {
                return (CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1,
                    CurrentLocation.YCoordinate) != null);
            }
        }

        public bool HasLocationToEast
        {
            get
            {
                return (CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1,
                    CurrentLocation.YCoordinate) != null);
            }
        }

        public bool HasLocationToSouth
        {
            get
            {
                return (CurrentWorld.LocationAt(CurrentLocation.XCoordinate,
                    CurrentLocation.YCoordinate - 1) != null);
            }
        }

        public void MoveNorth()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate,
                CurrentLocation.YCoordinate + 1);
        }

        public void MoveWest()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1,
                CurrentLocation.YCoordinate);
        }

        public void MoveEast()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1,
                CurrentLocation.YCoordinate);
        }

        public void MoveSouth()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate,
                CurrentLocation.YCoordinate - 1);
        }

    }
}
