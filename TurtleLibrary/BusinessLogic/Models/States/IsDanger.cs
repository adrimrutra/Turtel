using System;
using TurtleLibrary.Models;

namespace TurtleLibrary.BusinessLogic
{
    public class IsDanger : IState
    {
        private ITransitionable transitionable;
        private string description;
        string IState.Description
        {
            get
            {
                return description;
            }
        }
        public IsDanger(string description)
        {
            this.description = description;
        }

        /// <summary>
        ///  State Pattern
        /// </summary>
        public void SetTransitionable(ITransitionable transitionable)
        {
            this.transitionable = transitionable;
        }
        public void SetState(IState state)
        {
            this.transitionable.TransitionTo(state);
        }
    }
}
