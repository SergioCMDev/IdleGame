using System;
using Services.SavegameInteractorService;
using UnityEngine;
using Utils;

namespace Services.TimerOutsideCounterService
{
    //We can add interface in case we need another implementation
    [CreateAssetMenu(fileName = "TimeNotPlayingCounterService",
        menuName = "Loadable/Services/TimeNotPlayingCounterService")]
    public class TimeNotPlayingCounterService : LoadableComponent
    {
        private SaveGameInteractorService _savegameInteractorService;

        public void ExitingApp()
        {
            _savegameInteractorService.SavegameFile.LastTimeOpened = DateTime.Now;
            Debug.Log(
                $"[TimeNotPlayingCounterService] Exiting at {_savegameInteractorService.SavegameFile.LastTimeOpened}");
            _savegameInteractorService.SaveGame();
        }

        public int GetMinutesOutside()
        {
            var lastTime = _savegameInteractorService.SavegameFile.LastTimeOpened;
            if (lastTime == DateTime.MinValue) return 0;
            var difference = DateTime.Now - lastTime;
            var minutesSinceLastExiting = difference.Days * 24 * 60 +
                                          difference.Hours * 60 +
                                          difference.Minutes;
            _savegameInteractorService.SavegameFile.LastTimeOpened = DateTime.MinValue;
            _savegameInteractorService.SaveGame();
            Debug.Log(
                $"[TimeNotPlayingCounterService] Get Minutes {minutesSinceLastExiting}");

            return minutesSinceLastExiting;
        }

        public override void Execute()
        {
            Debug.Log("[TimeNotPlayingCounterService] Iniciamos inicializacion");
            _savegameInteractorService = ServiceLocator.Instance.GetService<SaveGameInteractorService>();
        }
    }
}