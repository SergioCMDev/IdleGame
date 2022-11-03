using System;
using Services.SavegameInteractorService;
using Services.Utils;
using UnityEngine;
using Utils;

namespace Services.TimerOutsideCounterService
{
    //We can add interface in case we need another implementation
    [CreateAssetMenu(fileName = "TimeNotPlayingCounterService",
        menuName = "Loadable/Services/TimeNotPlayingCounterService")]
    public class TimeNotPlayingCounterService : LoadableComponent
    {
        private SaveGameBuildingInteractorService _savegameBuildingInteractorService;

        public void ExitingApp()
        {
            _savegameBuildingInteractorService.SavegameFile.LastTimeOpened = DateTime.Now;
            Debug.Log(
                $"[TimeNotPlayingCounterService] Exiting at {_savegameBuildingInteractorService.SavegameFile.LastTimeOpened}");
            _savegameBuildingInteractorService.SaveGame();
        }

        public int GetMinutesOutside()
        {
            var lastTime = _savegameBuildingInteractorService.SavegameFile.LastTimeOpened;
            if (lastTime == DateTime.MinValue) return 0;
            var difference = DateTime.Now - lastTime;
            var minutesSinceLastExiting = difference.Days * 24 * 60 +
                                          difference.Hours * 60 +
                                          difference.Minutes;
            _savegameBuildingInteractorService.SavegameFile.LastTimeOpened = DateTime.MinValue;
            _savegameBuildingInteractorService.SaveGame();
            Debug.Log(
                $"[TimeNotPlayingCounterService] Get Minutes {minutesSinceLastExiting}");

            return minutesSinceLastExiting;
        }

        public override void Execute()
        {
            Debug.Log("[TimeNotPlayingCounterService] Iniciamos inicializacion");
            _savegameBuildingInteractorService = ServiceLocator.Instance.GetService<SaveGameBuildingInteractorService>();
        }
    }
}