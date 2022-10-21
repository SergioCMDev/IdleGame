using System;
using UnityEngine;

namespace Services.TimerOutsideCounterService
{
    //We can add interface in case we need another implementation
    [CreateAssetMenu(fileName = "TimeNotPlayingCounterService", menuName = "Loadable/Services/TimeNotPlayingCounterService")]
    public class TimeNotPlayingCounterService : LoadableComponent
    {
        // private ILoader _loader;
        // private ISaver _saver;
        private DateTime lastTime;

        public void ExitingApp()
        {
            lastTime = DateTime.Now;
            //Save
        }

        public int GetMinutesOutside()
        {
            //Load lastTime
            var difference = DateTime.Now - lastTime;
            int minutesSinceLastExiting = difference.Days * 24 * 60 +
                                          difference.Hours * 60 +
                                          difference.Minutes;
            return minutesSinceLastExiting;
        }

        public override void Execute()
        {
            Debug.Log("[TimeNotPlayingCounterService] Iniciamos inicializacion");
            //Get loader and saver
        }
    }
}