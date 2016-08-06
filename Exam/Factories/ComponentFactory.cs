using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemSplitExam.Factories
{
    public static class ComponentFactory
    {
        public static Component CreateComponent(string input)
        {
            string[] commands = input.Split(new char[] {',', ' ', '(', ')'}, StringSplitOptions.RemoveEmptyEntries);
            string componentType = commands[0].Substring(8);
            string componentName = commands[1];
            string hardwarePlacement = string.Empty;

            int componentCapacity = 0;
            int componentMemory = 0;
            
            if (commands.Length== 4)
            {
                componentCapacity = int.Parse(commands[2]);
                componentMemory = int.Parse(commands[3]);
            }

            if (commands.Length== 5)
            {
                hardwarePlacement = commands[1];
                componentName = commands[2];
                componentCapacity = int.Parse(commands[3]);
                componentMemory = int.Parse(commands[4]);
            }
            switch (componentType)
            {
                case "PowerHardware": return new PowerHardware(componentName, componentCapacity, componentMemory);
                case "HeavyHardware": return new HeavyHardware(componentName, componentCapacity, componentMemory);
                case "LightSoftware": return new LightSoftware(componentName, hardwarePlacement, componentCapacity, componentMemory);
                case "ExpressSoftware": return new ExpressSoftware(componentName, hardwarePlacement, componentCapacity, componentMemory);
            }
            return null;
        }
    }
}
