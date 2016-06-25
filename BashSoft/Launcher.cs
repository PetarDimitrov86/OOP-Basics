using System;
using Executor.Network;

namespace Executor
{
    class Launcher
    {
        static void Main()
        {
            Console.WindowWidth = 120;
            Tester tester = new Tester();
            DownloadManager downloadManager = new DownloadManager();
            IOManager ioManager = new IOManager();
            StudentsRepository repo = new StudentsRepository(new RepositorySorter(), new RepositoryFilter());     
                              
            CommandInterpreter currentInterpreter = new CommandInterpreter(tester, repo, downloadManager, ioManager);
            InputReader reader = new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}