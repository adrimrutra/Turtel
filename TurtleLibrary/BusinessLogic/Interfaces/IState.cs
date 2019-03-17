using TurtleLibrary.Models;

namespace TurtleLibrary.BusinessLogic
{
    public interface IState
    {      
        string Description { get; }

        /// <summary>
        ///  State Pattern
        /// </summary>
        void SetTransitionable(ITransitionable transitionable);
        void SetState(IState state);
    }
}
