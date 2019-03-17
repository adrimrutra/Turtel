using TurtleLibrary.BusinessLogic;
using TurtleLogger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TurtleLibrary
{
    public class Reader : IReader
    {
        private ILog logger;
        private static Reader settingReader;
        private string arg;
        private Settings settings;
        private List<string> gameSettings;

        /// <summary>
        /// Private constractor
        /// </summary>
        /// <param name="arg">Contains Path to location of the file to read</param>
        private Reader(string arg)
        {
            logger = new Logger();
            this.arg = arg;
            this.settings = new Settings();
            this.gameSettings = new List<string>();
            Initialize();           
        }

        /// <summary>
        /// The class is singleton so Method create Instance of class Reader
        /// </summary>
        /// <param name="arg"></param>
        /// <returns>Instance of Reader class</returns>
        public static Reader Instance(string arg)
        {
            if (null == settingReader)
                settingReader = new Reader(arg);
            return settingReader;
        }

        /// <summary>
        /// Factory method
        /// </summary>
        private void Initialize()
        {
            ReadFile();
            SetBoardSeze(gameSettings.First());
            gameSettings.RemoveAt(0);
            SetMineList(gameSettings.First());
            gameSettings.RemoveAt(0);
            SetExitPoint(gameSettings.First());
            gameSettings.RemoveAt(0);
            SetTurtlePositionAndDirection(gameSettings.First());
            gameSettings.RemoveAt(0);
            SetMoves(gameSettings);
        }

        /// <summary>
        /// Method opens and reads file with settings and adding into list of strings 
        /// </summary>
        private void ReadFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(arg))
                {
                    while (sr.Peek() >= 0)
                    {
                        gameSettings.Add(sr.ReadLine().Trim().ToUpper());
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(MethodBase.GetCurrentMethod().Name + ex.Message);
            }
        }

        /// <summary>
        /// Method parsing string and retriving width and height of board
        /// </summary>
        /// <param name="size">parsing string</param>
        private void SetBoardSeze(string size)
        {
            var tmp = size.Split(' ');
            int width, height;
            if (int.TryParse(tmp[0], out width))
                settings.BoardWidth = width;

            if (int.TryParse(tmp[1], out height))
                settings.BoardHeight = height;
        }

        /// <summary>
        /// Method parsing string and retriving list of mines
        /// </summary>
        /// <param name="mines">parsing string</param>
        private void SetMineList(string mines)
        {
            var minesList = mines.Split(' ');
            foreach (var mine in minesList)
            {
                settings.MineList.Add(SetPoint(mine, ','));
            }
        }

        /// <summary>
        /// Method parsing string and retriving exit point
        /// </summary>
        /// <param name="exitPoint"></param>
        private void SetExitPoint(string exitPoint)
        {
            settings.ExitPoint = SetPoint(exitPoint, ' ');
        }

        /// <summary>
        /// Method parsing string and retriving position and direction of turtle
        /// </summary>
        /// <param name="turtlePosition">parsing string</param>
        private void SetTurtlePositionAndDirection(string turtlePosition)
        {
            settings.TurtlePosition = SetPoint(turtlePosition, ' ');
            var direction = turtlePosition.Split(' ');
            settings.TurtleDirection = direction[2];
        }

        /// <summary>
        /// Method parsing string and returning point
        /// </summary>
        /// <param name="coord">parsing string</param>
        /// <param name="splitter">splitter for Split native string method</param>
        /// <returns>Point</returns>
        private Point SetPoint(string coord, char splitter)
        {
            int x, y;
            var point = coord.Split(splitter);
            if (int.TryParse(point[0], out x) && int.TryParse(point[1], out y))
                return new Point(x, y);
            return new Point(0, 0);
        }

        /// <summary>
        /// Method replacing white spaces and setting moves as string
        /// </summary>
        /// <param name="moveSequences">parsing string</param>
        private void SetMoves(List<string> moveSequences)
        {
            settings.Moves = moveSequences.Select(x => x.Replace(" ", string.Empty)).ToArray();
        }

        /// <summary>
        /// Method returning Game Settings
        /// </summary>
        /// <returns>Settings</returns>
        public Settings GetSettings()
        {
            logger.Info(MethodBase.GetCurrentMethod().ReflectedType.ToString() + MethodBase.GetCurrentMethod().Name);
            return settings;
        }
    }
}
