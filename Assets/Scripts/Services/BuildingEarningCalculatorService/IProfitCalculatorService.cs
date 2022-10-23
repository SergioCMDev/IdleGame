using Buildings;

namespace Services.BuildingEarningCalculatorService
{
    public interface IProfitCalculatorService
    {
        float GetCurrentEarningsForSecond(IProfitable queueEntrance);

        float GetCurrentEarningsForMinute(IProfitable queueEntrance);
    }
}