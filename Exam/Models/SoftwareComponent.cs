namespace SystemSplitExam
{
    public abstract class SoftwareComponent : Component
    {
        private int capacityConsumption;
        private int memoryConsumption;
        private string hardwarePlacement;

        public SoftwareComponent(string name, string type, string hardwarePlacement, int capacityConsumption, int memoryConsumption) : base(name, type)
        {
            this.CapacityConsumption = capacityConsumption;
            this.MemoryConsumption = memoryConsumption;
            this.HardwarePlacement = hardwarePlacement;
        }

        public virtual int CapacityConsumption { get; private set; }

        public virtual int MemoryConsumption { get; private set; }

        public virtual string HardwarePlacement { get; private set; }
    }
}