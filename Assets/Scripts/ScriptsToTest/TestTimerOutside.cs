using Services.TimerOutsideCounterService;
using UnityEngine;
using Utils;

namespace ScriptsToTest
{
    public class TestTimerOutside : MonoBehaviour
    {
        private TimeNotPlayingCounterService _timerNotPlaying;

        [SerializeField] private bool _exitApp;

        // Start is called before the first frame update
        void Start()
        {
            _timerNotPlaying = ServiceLocator.Instance.GetService<TimeNotPlayingCounterService>();
            if (_exitApp)
            {
                _timerNotPlaying.ExitingApp();
                return;
            }

            var minutes = _timerNotPlaying.GetMinutesOutside();
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