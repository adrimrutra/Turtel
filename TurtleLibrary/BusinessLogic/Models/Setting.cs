using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLibrary
{
    public class Settings
    {
        public int BoardWidth { get; set; }
        public int BoardHeight { get; set; }
        public List<Point> MineList { get; set; } = new List<Point>();
        public Point ExitPoint { get; set; }
        public Point TurtlePosition { get; set; }
        public string TurtleDirection { get; set; }
        public string [] Moves { get; set; }   
    }
}
