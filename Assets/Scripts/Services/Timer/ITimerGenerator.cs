namespace Services.Timer
{
    public interface ITimerGenerator
    {
        global::Utils.Timer GenerateTimer(float timeToWait, bool repeatable = false);
    }
}