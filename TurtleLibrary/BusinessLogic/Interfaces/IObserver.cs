using TurtleLibrary.BusinessLogic;
namespace TurtleLibrary
{
    public interface IObserver
    {
        IState Observe(Point point);
    }
}
