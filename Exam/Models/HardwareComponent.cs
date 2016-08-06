using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemSplitExam
{
    public abstract class HardwareComponent : Component
    {
        private int maximumCapacity;
        private int maximumMemory;
        private List<SoftwareComponent> softwares;

        public HardwareComponent(string name, string type, int maximumCapacity, int maximumMemory) : base(name, type)
        {
            this.MaximumCapacity = maximumCapacity;
            this.MaximumMemory = maximumMemory;
            this.Softwares = new List<SoftwareComponent>();
        }

        public virtual int MaximumCapacity
        {
            get { return this.maximumCapacity; }
            private set { this.maximumCapacity = value; }
        }
        public virtual int MaximumMemory
        {
            get { return this.maximumMemory; }
            private set { this.maximumMemory = value; }
        }

        public List<SoftwareComponent> Softwares { get; private set; }

        public void ImportSoftware(SoftwareComponent software)
        {
            if (this.MaximumCapacity - software.CapacityConsumption >=0 && this.MaximumMemory - software.MemoryConsumption >=0)
            {
                Softwares.Add(software);
            }
        }

        public void ReleaseSoftware(SoftwareComponent software)
        {
                Softwares.Remove(software);
        }
         
        public int TotalMemoryConsumption()
        {
            int sum = 0;
            if (Softwares.Count > 0)
            {
                foreach (var software in Softwares)
                {
                    sum += software.MemoryConsumption;
                }
            }
            return sum;
        }
        public int TotalCapacityTaken()
        {
            int sum = 0;
            if (Softwares.Count >0)
            {
                foreach (var software in Softwares)
                {
                    sum += software.CapacityConsumption;
                }
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Hardware Component - {this.Name}");
            sb.Append(Environment.NewLine);
            sb.Append($"Express Software Components - {Softwares.Count(x=>x.Type.Contains("Express"))}");
            sb.Append(Environment.NewLine);
            sb.Append($"Light Software Components - {Softwares.Count(x => x.Type.Contains("Light"))}");
            sb.Append(Environment.NewLine);
            sb.Append($"Memory Usage: {this.Softwares.Sum(x => x.MemoryConsumption)} / {this.MaximumMemory}");
            sb.Append(Environment.NewLine);
            sb.Append($"Capacity Usage: {this.Softwares.Sum(x => x.CapacityConsumption)} / {this.MaximumCapacity}");
            sb.Append(Environment.NewLine);
            sb.Append($"Type: {this.Type}");
            sb.Append(Environment.NewLine);
            if (Softwares.Count > 0)
            {
                sb.Append($"Software Components: {string.Join(", ", Softwares.Select(x => x.Name))}");
            }
            else
            {
                sb.Append($"Software Components: None");
            }
            return sb.ToString();
        }
    }
}