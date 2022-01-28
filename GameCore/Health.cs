public class Health
{
    private int MaxValue { get; } = 100;
    private int MinValue { get; } = 0;

    private int HealthValue;

    public int Value
    {
        get
        {
            return HealthValue;
        }
        set
        {
            if (value < MinValue)
            {
                HealthValue = MinValue;
            }
            else if (value > MaxValue)
            {
                HealthValue = MaxValue;
            }
            else
            {
                HealthValue = value;
            }
        }
    }
}
