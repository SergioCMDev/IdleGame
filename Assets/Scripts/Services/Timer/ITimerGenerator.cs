namespace Services.Timer
{
    public interface ITimerGenerator
    {
        Utils.Timer GenerateTimer(float timeToWait, bool repeatable = false);
    }
}