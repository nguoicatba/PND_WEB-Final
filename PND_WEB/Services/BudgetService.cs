public class BudgetService
{
    private static decimal _limit;

    public BudgetService()
    {
        _limit = 10000000;
    }

    public decimal GetLimit()
    {
        return _limit;
    }

    public void SetLimit(decimal newLimit)
    {
        _limit = newLimit;
    }

}
