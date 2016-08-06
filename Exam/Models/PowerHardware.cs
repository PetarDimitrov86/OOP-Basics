using SystemSplitExam;

public class PowerHardware : HardwareComponent
{
    private const string Type = "Power";

    public PowerHardware(string name, int maximumCapacity, int maximumMemory)
        : base(name, Type, maximumCapacity, maximumMemory)
    {
    }

    public override int MaximumCapacity
    {
        get { return base.MaximumCapacity - (3 * base.MaximumCapacity) / 4; }
    }

    public override int MaximumMemory
    {
        get { return base.MaximumMemory + (3 * base.MaximumMemory) / 4; }
    }
}