using System;
using System.Collections.Generic;
using System.Linq;
using SystemSplitExam;
using SystemSplitExam.Factories;

public class SystemSplit
{
    static void Main(string[] args)
    {
        List<HardwareComponent> hardwareComponents = new List<HardwareComponent>();
        List<SoftwareComponent> softwareComponents = new List<SoftwareComponent>();
        List<HardwareComponent> dumpedComponents = new List<HardwareComponent>();
        string input = Console.ReadLine();
        while (input != "System Split")
        {
            if (input == "Analyze()")
            {
                AnalyzeData(hardwareComponents);
                input = Console.ReadLine();
                continue;
            }
            else if (input == "DumpAnalyze")
            {

                input = Console.ReadLine();
                continue;
            }

            string[] commands = input.Split(new char[] { ',', ' ', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            Component currentComponent = ComponentFactory.CreateComponent(input);

            string targetedHardwareName = commands[1];
            HardwareComponent targetedComponent = dumpedComponents.FirstOrDefault(x => x.Name == targetedHardwareName);
            if (input.Contains("Release"))
            {
                ReleaseSoftwareFromHardware(commands, hardwareComponents, softwareComponents);
            }
            else if (input.Contains("Dump") && commands.Length > 1)
            {
                dumpedComponents.Add(targetedComponent);
                hardwareComponents.Remove(targetedComponent);
            }
            else if (input.Contains("Restore"))
            {
                hardwareComponents.Add(targetedComponent);
                dumpedComponents.Remove(targetedComponent);
            }
            else if (input.Contains("Destroy"))
            {
                dumpedComponents.Remove(targetedComponent);
            }
            else if (input.Contains("Hardware"))
            {
                hardwareComponents.Add(currentComponent as HardwareComponent);
            }
            else if (input.Contains("Software"))
            {
                HardwareComponent desiredComponent = hardwareComponents.FirstOrDefault(x => x.Name == targetedHardwareName);
                softwareComponents.Add(currentComponent as SoftwareComponent);
                desiredComponent.ImportSoftware(currentComponent as SoftwareComponent);
            }
            input = Console.ReadLine();
        }
        foreach (var hardwareComponent in hardwareComponents.OrderByDescending(x=>x.Type))
        {
            Console.WriteLine(hardwareComponent);
        }
    }

    private static void ReleaseSoftwareFromHardware(string[] commands, List<HardwareComponent> hardwareComponents, List<SoftwareComponent> softwareComponents)
    {
        string desiredHardwareName = commands[1];
        string softwareToRemoveName = commands[2];
        HardwareComponent desiredComponent = hardwareComponents.FirstOrDefault(x => x.Name == desiredHardwareName);
        SoftwareComponent unwantedSoftware = softwareComponents.FirstOrDefault(x => x.Name == softwareToRemoveName);
        if (desiredComponent.Softwares.Any(x => x.Name == softwareToRemoveName))
        {
            desiredComponent.Softwares.Remove(unwantedSoftware);
        }
        desiredComponent.ReleaseSoftware(unwantedSoftware);
    }

    private static void AnalyzeData(List<HardwareComponent> hardwareComponents)
    {
        Console.WriteLine("System Analysis");
        Console.WriteLine($"Hardware Components: {hardwareComponents.Count}");
        if (!hardwareComponents.Any(x=>x.Softwares.Count < 0))
        {
            Console.WriteLine($"Software Components: {hardwareComponents.Sum(x => x.Softwares.Count)}");
        }
        int totalSum = 0;
        foreach (var hardware in hardwareComponents)
        {
            totalSum += hardware.TotalMemoryConsumption();
        }
        Console.WriteLine($"Total Operational Memory: {totalSum} / {hardwareComponents.Sum(x => x.MaximumMemory)}");
        Console.WriteLine(
            $"Total Capacity Taken: {hardwareComponents.Sum(x => x.TotalCapacityTaken())} / {hardwareComponents.Sum(x => x.MaximumCapacity)}");
    }
}