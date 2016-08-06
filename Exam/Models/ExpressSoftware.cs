namespace SystemSplitExam
{
    public class ExpressSoftware : SoftwareComponent
    {
        private const string Type = "Express";

        public ExpressSoftware(string name, string hardwarePlacement, int capacityConsumption, int memoryConsumption) : base(name, Type, hardwarePlacement, capacityConsumption, memoryConsumption)
        {
        }

        public override int MemoryConsumption
        {
            get { return 2 * base.MemoryConsumption; }
        }       
    }
}