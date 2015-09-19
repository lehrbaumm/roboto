﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roboto.Modules
{

    public abstract class RobotoModuleTemplate
    {
        public bool chatHook = false;
        public bool chatEvenIfAlreadyMatched = false;
        public int chatPriority = 5;

        public bool backgroundHook = false;
        public int backgroundMins = 10;

        public Type pluginDataType;
       
        /// <summary>
        /// Initialise any code
        /// </summary>
        public abstract void init();
        /// <summary>
        /// Initialise general data
        /// </summary>
        public abstract void initData();
        /// <summary>
        /// Initialise chat specific data
        /// </summary>
        public abstract void initChatData();
        /// <summary>
        /// If creating a sample settings file, populate some dummy data in a RobotoModuleDataTemplate class, and store in settings
        /// using storeModuleData
        /// </summary>
        public abstract void sampleData();
        /// <summary>
        /// Called whenever a chat message is sent, if Settings.RegisterChatHook has been called during init. 
        /// </summary>
        /// <param name="chatID"></param>
        /// <param name="chatString"></param>
        /// <param name="userName"></param>
        public abstract bool chatEvent(message m);
        /// <summary>
        /// Called periodically, if Settings.RegisterBackgroundHook has been called during init
        /// </summary>
        protected abstract void backgroundProcessing();

        public void callBackgroundProcessing()
        {
            DateTime lastCall = getLastUpdate();
            if (DateTime.Now > lastCall.AddMinutes(backgroundMins))
            {
                Console.WriteLine("------");
                Console.WriteLine("Background Processing for " + GetType().ToString());
                backgroundProcessing();
                setLastUpdate(DateTime.Now);
            }

        }

        //Helper Methods
        public T getPluginData<T>()
        {
            return Roboto.Settings.getPluginData<T>();
        }
        public RobotoModuleDataTemplate getPluginData()
        {
            return Roboto.Settings.getPluginData(pluginDataType);
        }


        public DateTime getLastUpdate()
        {
            RobotoModuleDataTemplate data = getPluginData();

            return data.lastBackgroundUpdate;

        }

        public void setLastUpdate(DateTime update)
        {
            RobotoModuleDataTemplate data = getPluginData();
            data.lastBackgroundUpdate = update;

        }
    }
}