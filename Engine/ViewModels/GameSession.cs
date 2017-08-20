using Engine.Models;
using Engine.Factories;
using System.ComponentModel;

namespace Engine.ViewModels
{
    public class GameSession : BaseNotificationClass
    {
        private Location _location;
        public enum Direction
        {
            North = 1,
            West = 2,
            East = 3,
            South = 4,
        }

        public World CurrentWorld { get; set; }
        public Player CurrentPlayer { get; set; }

        public Location CurrentLocation
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged(nameof(CurrentLocation));
                //OnPropertyChanged(nameof(HasLocation));
                OnPropertyChanged(nameof(HasLocationToNorth));
                OnPropertyChanged(nameof(HasLocationToWest));
                OnPropertyChanged(nameof(HasLocationToEast));
                OnPropertyChanged(nameof(HasLocationToSouth));
            }
        }

        public bool HasLocationToNorth { get { return HasLocation(Direction.North); } }
        public bool HasLocationToWest  { get { return HasLocation(Direction.West); } }
        public bool HasLocationToEast  { get { return HasLocation(Direction.East); } }
        public bool HasLocationToSouth { get { return HasLocation(Direction.South); } }

        public GameSession()
        {
            CurrentPlayer = new Player
            {
                Name = "Mike",
                CharacterClass = "Fighter",
                HitPoints = 10,
                Gold = 1000000,
                ExperiencePoints = 0,
                Level = 1
            };

            CurrentWorld = WorldFactory.CreateWorld();

            CurrentLocation = CurrentWorld.LocationAt(0, -1);
            CurrentLocation.ImageName = "/Engine;component/Images/Locations/Home.png";
        }

        public bool HasLocation(int xCoordinate, int yCoordinate)
        {
            return (CurrentWorld.LocationAt(xCoordinate, yCoordinate)
                != null);
        }

        public bool HasLocation(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return (CurrentWorld.LocationAt(CurrentLocation.XCoordinate,
                        CurrentLocation.YCoordinate + 1) != null);
                case Direction.West:
                    return (CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1,
                        CurrentLocation.YCoordinate) != null);
                case Direction.East:
                    return (CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1,
                        CurrentLocation.YCoordinate) != null);
                case Direction.South:
                    return (CurrentWorld.LocationAt(CurrentLocation.XCoordinate,
                        CurrentLocation.YCoordinate - 1) != null);
                default:
                    throw new System.Exception("System Error: Unhandled or Unknown Direction");
            }
        }

        public void MoveTo(int xCoordinate, int yCoordinate)
        {
            if (HasLocation(xCoordinate, yCoordinate))
            {
                CurrentLocation = CurrentWorld.LocationAt(xCoordinate, yCoordinate);
            }
            else
            {
                throw new System.Exception("System Error: Unknown Location in CurrentWorld");
            }
        }

        public void MoveTo(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    if (HasLocation(Direction.North))
                    {
                        MoveTo(CurrentLocation.XCoordinate,
                            CurrentLocation.YCoordinate + 1);
                    }
                    break;
                case Direction.West:
                    if (HasLocation(Direction.West))
                    {
                        MoveTo(CurrentLocation.XCoordinate - 1,
                            CurrentLocation.YCoordinate);
                    }
                    break;
                case Direction.East:
                    if (HasLocation(Direction.East))
                    {
                        MoveTo(CurrentLocation.XCoordinate + 1,
                        CurrentLocation.YCoordinate);
                    }
                    break;
                case Direction.South:
                    if (HasLocation(Direction.South))
                    {
                        MoveTo(CurrentLocation.XCoordinate,
                            CurrentLocation.YCoordinate - 1);
                    }
                    break;
                default:
                    throw new System.Exception("System Error: Unknown or Unhandled Direction");
            }
        }

    }
}
