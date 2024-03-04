using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class World
    {
        private readonly List<Location> _locations = new List<Location>();
        internal void AddLocation(int xCoordinate, int yCoordinate, string name, string description, string imageName)
        {
            var loc = new Location();
            loc.XCoordinate = xCoordinate;
            loc.YCoordinate = yCoordinate;
            loc.Name = name;
            loc.Description = description;
            loc.ImageName = $"D:\\Projects\\SOSCSRPG\\Engine\\Images\\Locations\\{imageName}";
            _locations.Add(loc);
        }
        public Location LocationAt(int xCoordinate, int yCoordinate)
        {
            foreach (var loc in _locations)
            {
                if (loc.XCoordinate == xCoordinate && loc.YCoordinate == yCoordinate)
                {
                    return loc;
                }
            }
            return null;
        }
    }
}
