using TurtleLibrary.BusinessLogic;
using TurtleLogger;
using System;
using System.Collections.Generic;
using System.Reflection;
using TurtleLibrary.BusinessLogic.Interfaces;

namespace TurtleLibrary
{
    public class Core: ICore
    {
        private IReader reader;
        private Settings settings;
        private Board board;
        private IObserver observer;
        private IWriter writer;
        private List<IState> states;
        private ILog logger;

        /// <summary>
        /// Private constractor
        /// </summary>
        /// <param name="arg"></param>
        private Core(string arg)
        {
            logger = new Logger();
            reader = Reader.Instance(arg);
            settings = reader.GetSettings();
            board = new Board(settings.BoardWidth, settings.BoardHeight);
            observer = new Observer(board);
            states = new List<IState>();
            writer = Writer.Instance();
            Initialize();
            
        }
        /// <summary>
        /// Factory method
        /// </summary>
        private void Initialize()
        {
            SetTurtle(settings.TurtlePosition);
            SetMineList(settings.MineList);
            SetExit(settings.ExitPoint);
        }
        /// <summary>
        /// Setting position of turtle on board
        /// </summary>
        /// <param name="pos"></param>
        private void SetTurtle(Point pos)
        {
            try
            {
                board[pos] = Turtle.Instance(pos);
            }
            catch(Exception ex)
            {
                logger.Error(MethodBase.GetCurrentMethod().Name + ex.Message);
            }
        }
        /// <summary>
        /// Setting position of mine list on board
        /// </summary>
        /// <param name="mines"></param>
        private void SetMineList(List<Point> mines)
        {
            foreach (var pos in mines)
            {
                try
                {
                    board[pos] = new Mine() { Position = pos };
                }
                catch (Exception ex)
                {
                    logger.Error(MethodBase.GetCurrentMethod().Name + ex.Message);
                }
            }
        }
        /// <summary>
        /// Setting position of exit point on board
        /// </summary>
        /// <param name="pos"></param>
        private void SetExit(Point pos)
        {
            try
            {
                board[pos] = new Exit() { Position = pos };
            }
            catch (Exception ex)
            {
                logger.Error(MethodBase.GetCurrentMethod().Name + ex.Message);
            }
        }
        /// <summary>
        /// Resetting default position and direction and returning turtle instance
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="direction"></param>
        /// <returns>Turtle</returns>
        private Turtle GetTurtle(Point pos, string direction)
        {
            Turtle turtle = board[pos] as Turtle;
            if (null != turtle)
            {
                turtle.Position = pos;
                turtle.TurtleDirection = direction;
            }
            return turtle;
        }
        /// <summary>
        /// The class is singleton so the method create instance of Core class
        /// </summary>
        /// <param name="arg"></param>
        /// <returns>Core</returns>
        public static Core Create(string arg)
        {
            return new Core(arg);
        }

        public void Start()
        {
            logger.Info(MethodBase.GetCurrentMethod().ReflectedType.ToString() + MethodBase.GetCurrentMethod().Name);

            foreach (string move in settings.Moves)
            {
                Turtle turtle = GetTurtle(settings.TurtlePosition, settings.TurtleDirection);
                if (null != turtle)
                {
                    for (int i = 0; i < move.Length; i++)
                    {
                        turtle.Move(move[i]);
                        if (Move.M.Equals(move[i]))
                        {
                            turtle.TransitionTo(observer.Observe(turtle.Position));
                            if (turtle.State is IsOutOfRange || turtle.State is IsMine || turtle.State is IsExit)
                                break;
                        }
                    }
                    states.Add(turtle.State);
                }
            }
            writer.Write(states);
        }
    }
}
