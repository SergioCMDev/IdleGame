using Services.BuildingEarningCalculatorService;
using Services.TimerOutsideCounterService;
using UnityEngine;
using Utils;

namespace ScriptsToTest
{
    public class TestTimerOutside : MonoBehaviour
    {
        private TimeNotPlayingCounterService _timerNotPlaying;
        private IProfitCalculatorService _profitCalculatorService;

        [SerializeField] private bool _exitApp;

        void Start()
        {
            _timerNotPlaying = ServiceLocator.Instance.GetService<TimeNotPlayingCounterService>();
            _profitCalculatorService = ServiceLocator.Instance.GetService<IProfitCalculatorService>();
            if (_exitApp)
            {
                _timerNotPlaying.ExitingApp();
                return;
            }

            var minutes = _timerNotPlaying.GetMinutesOutside();

            var profitGenerated = _profitCalculatorService.GetCurrentEarningsForMinuteAllBuildings() * minutes;
            
            
        }

        private void OnApplicationQuit()
        {
            _timerNotPlaying.ExitingApp();
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus)
            {
                _timerNotPlaying.ExitingApp();
            }
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}