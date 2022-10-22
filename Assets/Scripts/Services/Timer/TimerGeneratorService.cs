using Services.Utils;
using UnityEngine;

namespace Services.Timer
{
    [CreateAssetMenu(fileName = "TimerGeneratorService", menuName = "Loadable/Services/TimerGeneratorService")]
    public class TimerGeneratorService : LoadableComponent, ITimerGenerator
    {
        public global::Utils.Timer GenerateTimer(float timeToWait, bool repeatable)
        {
            var timer = new global::Utils.Timer();
            timer.Init(timeToWait, repeatable);
            return timer;
        }

        public override void Execute()
        {
            Debug.Log("[TimerGeneratorService] Iniciamos inicializacion");
        }
    }
}