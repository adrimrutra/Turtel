using TurtleLibrary.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Reflection;
using TurtleLogger;

namespace TurtleLibrary
{
    public class Writer : IWriter
    {
        private ILog logger;
        private static Writer consoleWriter;

        /// <summary>
        /// Privat constarctor
        /// </summary>
        private Writer()
        {
            logger = new Logger();
        }

        /// <summary>
        /// The class is singleton so method create an Instance
        /// </summary>
        /// <returns>Instance of Writer class</returns>
        public static Writer Instance()
        {
            if (null == consoleWriter)
                consoleWriter = new Writer();
            return consoleWriter;
        }


        /// <summary>
        /// Method writes informatin to concole
        /// </summary>
        /// <param name="states">List of Sequence: status</param>
        public void Write(List<IState> states)
        {
            logger.Info(MethodBase.GetCurrentMethod().ReflectedType.ToString() + MethodBase.GetCurrentMethod().Name);
            for (int i = 0; i < states.Count; i++)
            {
                Console.WriteLine(String.Format("Sequence {0} :  {1}", i, states[i].Description));
            }
        }
    }
}
