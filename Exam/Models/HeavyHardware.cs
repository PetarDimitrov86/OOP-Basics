using SystemSplitExam;

public class HeavyHardware : HardwareComponent
{
    private const string Type = "Heavy";

    public HeavyHardware(string name, int maximumCapacity, int maximumMemory)
        : base(name, Type, maximumCapacity, maximumMemory)
    {
    }

    public override int MaximumCapacity
    {
        get { return 2 * base.MaximumCapacity; }
    }

    public override int MaximumMemory
    {
        get { return base.MaximumMemory - base.MaximumMemory/4; }
    }
}