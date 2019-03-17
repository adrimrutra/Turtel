using System.Reflection;
using TurtleLibrary.BusinessLogic;
using TurtleLogger;

namespace TurtleLibrary
{
    public class Observer : IObserver
    {
        private Board board;
        private int width;
        private int height;
        private ILog logger;
        public Observer(Board board)
        {
            this.logger = new Logger ();
            this.board = board;
            this.width = board.Width;
            this.height = board.Height;
        }

        /// <summary>
        /// Method observing point and returning a state
        /// </summary>
        /// <param name="point">point for observing</param>
        /// <returns>IState</returns>
        public IState Observe(Point point)
        {
            logger.Info(MethodBase.GetCurrentMethod().ToString());
            if (OutOfRange(point))
                return new IsOutOfRange(Description.OutOfRange);
            else if (Exit(point))
                return new IsExit(Description.Exit);
            else if (Dead(point))
                return new IsMine(Description.Mine);
            else
                return new IsDanger(Description.Danger);
        }

        /// <summary>
        /// Method observing if the given point is not out of range of the board
        /// </summary>
        /// <param name="point">given point</param>
        /// <returns>bool</returns>
        private bool OutOfRange(Point point)
        {
            return point.X < 0 || point.X >= height || point.Y < 0 || point.Y >= width;
        }

        /// <summary>
        /// Method obsorving if the giveng point is an exit point
        /// </summary>
        /// <param name="point">given point</param>
        /// <returns>bool</returns>
        private bool Exit(Point point)
        {
            return board[point] is Exit;
        }

        /// <summary>
        /// Method observing if the given point is a Mine
        /// </summary>
        /// <param name="point">given point</param>
        /// <returns>bool</returns>
        private bool Dead(Point point)
        {
            return board[point] is Mine;
        }
    }
}
