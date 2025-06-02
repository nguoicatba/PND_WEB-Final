public class BudgetServiceStaff
{
    private static decimal _limitstaff;

    public BudgetServiceStaff()
    {
        _limitstaff = 500000;
    }

    public decimal GetLimit()
    {
        return _limitstaff;
    }

    public void SetLimit(decimal newLimit2)
    {
        _limitstaff = newLimit2;
    }

}
