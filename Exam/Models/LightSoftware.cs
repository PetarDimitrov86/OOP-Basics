namespace SystemSplitExam
{
    public class LightSoftware : SoftwareComponent
    {
        private const string Type = "Light";

        public LightSoftware(string name, string hardwarePlacement, int capacityConsumption, int memoryConsumption) : base(name, Type, hardwarePlacement, capacityConsumption, memoryConsumption)
        {
        }

        public override int CapacityConsumption
        {
            get { return base.CapacityConsumption + base.CapacityConsumption/2; }
        }

        public override int MemoryConsumption
        {
            get { return base.MemoryConsumption - base.MemoryConsumption/2; }
        } 
    }
}