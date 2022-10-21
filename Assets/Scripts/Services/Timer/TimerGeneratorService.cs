using UnityEngine;

namespace Services.Timer
{
    [CreateAssetMenu(fileName = "TimerGeneratorService", menuName = "Loadable/Services/TimerGeneratorService")]
    public class TimerGeneratorService : LoadableComponent, ITimerGenerator
    {
        public Utils.Timer GenerateTimer(float timeToWait, bool repeatable)
        {
            var timer = new Utils.Timer();
            timer.Init(timeToWait, repeatable);
            return timer;
        }

        public override void Execute()
        {
        }
    }
}