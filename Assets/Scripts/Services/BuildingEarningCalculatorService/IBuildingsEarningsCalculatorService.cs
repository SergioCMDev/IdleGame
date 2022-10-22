using Buildings;

namespace Services.BuildingEarningCalculatorService
{
    public interface IBuildingsEarningsCalculatorService
    {
        int GetCurrentEarnings(ILeveable queueEntrance);
    }
}