﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roboto.Modules
{
    public abstract class RobotoModuleDataTemplate
    {
        public DateTime lastBackgroundUpdate = DateTime.MinValue;
        internal RobotoModuleDataTemplate() { } 
        
        //for serialisation
        /// <summary>
        /// Logging wrapper
        /// </summary>
        /// <param name="text"></param>
        /// <param name="level"></param>
        /// <param name="colour"></param>
        /// <param name="noLineBreak"></param>
        public void log(string text, logging.loglevel level = logging.loglevel.normal, ConsoleColor colour = ConsoleColor.White, bool noLineBreak = false)
        {
            Roboto.log.log(text, level, colour, noLineBreak, false);
        }
    }


}
