using TurtleLibrary.BusinessLogic;
using TurtleLibrary.Models;
using System;

namespace TurtleLibrary
{
    public class Turtle : Tile , ITransitionable
    {
        private static Turtle turtle;

        /// <summary>
        /// Constructor sets position and calls TransitionTo method with default state
        /// Pattern singleton and State pattern
        /// </summary>
        /// <param name="position"></param>
        private Turtle(Point position)
        {
            Position = position;
            TransitionTo(new IsDanger(Description.OutOfRange));
        }

        /// <summary>
        /// the class is singleton so method create instance of class Turtle
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static Turtle Instance(Point pos)
        {
            if (null == turtle)
                turtle = new Turtle(pos);
            return turtle;
        }
        public String TurtleDirection { get; set; }
        public IState State { get; private set; }


        /// <summary>
        /// Method move and rotate left or right position of turtle
        /// </summary>
        /// <param name="move"></param>
        public void Move(char move)
        {
            switch (TurtleDirection)
            {
                case Direction.N:
                    switch (move)
                    {
                        case TurtleLibrary.Move.M:
                            turtle.Position = new Point(turtle.Position.X, turtle.Position.Y - 1); break;
                        case TurtleLibrary.Move.R:
                            TurtleDirection = Direction.E; break;
                        case TurtleLibrary.Move.L:
                            TurtleDirection = Direction.W; break;
                    }
                    break;
                case Direction.E:
                    switch (move)
                    {
                        case TurtleLibrary.Move.M:
                            turtle.Position = new Point(turtle.Position.X + 1, turtle.Position.Y); break;
                        case TurtleLibrary.Move.R:
                            TurtleDirection = Direction.S; break;
                        case TurtleLibrary.Move.L:
                            TurtleDirection = Direction.N; break;
                    }
                    break;
                case Direction.S:
                    switch (move)
                    {
                        case TurtleLibrary.Move.M:
                            turtle.Position = new Point(turtle.Position.X, turtle.Position.Y + 1); break;
                        case TurtleLibrary.Move.R:
                            TurtleDirection = Direction.W; break;
                        case TurtleLibrary.Move.L:
                            TurtleDirection = Direction.E; break;
                    }
                    break;
                case Direction.W:
                    switch (move)
                    {
                        case TurtleLibrary.Move.M:
                            turtle.Position = new Point(turtle.Position.X - 1, turtle.Position.Y); break;
                        case TurtleLibrary.Move.R:
                            TurtleDirection = Direction.N; break;
                        case TurtleLibrary.Move.L:
                            TurtleDirection = Direction.S; break;
                    }
                    break;
            }
        }

        /// <summary>
        /// Method change state of turtle
        /// </summary>
        /// <param name="state"></param>
        public void TransitionTo(IState state)
        {
            State = state;
            State.SetTransitionable(this);
        }
    }
}
