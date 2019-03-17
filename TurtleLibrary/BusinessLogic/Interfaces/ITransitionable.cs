using TurtleLibrary.BusinessLogic;

namespace TurtleLibrary.Models
{
    public interface ITransitionable
    {
        void TransitionTo(IState state);
    }
}
