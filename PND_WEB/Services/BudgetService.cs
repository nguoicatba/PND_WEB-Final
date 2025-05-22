public class BudgetService
{
    private decimal _limit;

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

    public bool CanSpend(decimal amount)
    {
        return amount <= _limit;
    }
}
