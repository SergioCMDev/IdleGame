namespace Buildings
{
    public interface IProfitable
    {
        float GetBenefitForMinute();
        float GetBenefitForSecond();
        float GetBenefitForMinuteAtNextLevel();
    }
}