using System.Diagnostics;

// butun processler gorunur, sonda ise, New Task, End Task bolmesi olur.
// eger New Task sechilse, process adi daxil olunur, ve hemin process ishe dushur.
// eger End Task sechilse, process id'si daxil olunur, ve hemin process kill olunur

Process process = new Process();
to:
bool check = true;
while (true)
{
    try
    {
        Console.Write("1. New Task\n2. End Task\nMake Choise : ");
        int choise = int.Parse(Console.ReadLine());
        switch (choise)
        {
            case 1:
            proce:
                Console.Write("Enter Proc Name : ");
                var proc = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(proc))
                {
                    Process.Start(proc);
                }
                else { goto proce; }
                break;
            case 2:
            Begin:
                var processes = Process.GetProcesses();
                foreach (var i in processes)
                {
                    Console.WriteLine($"{i.Id}. {i.ProcessName}");
                }
                try
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (check == false) { Console.WriteLine("False Id Try Again"); }
                    Console.ResetColor();
                    Console.Write("Enter Id : ");
                    int id = int.Parse(Console.ReadLine());
                    var fOD = processes.FirstOrDefault(p => p.Id == id);
                    if (fOD is not null)
                    {
                        var t = Process.GetProcessById(id);
                        t.Kill();
                        check = true;//check sadece false id ni rahat gormek ucun istifade edirem. yeni else veziyyetinde fasle idni ekrana cixarsin.
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Deleted {t.ProcessName}\nEnter Continue");
                        Console.ResetColor();
                    }
                    else { Console.WriteLine("False Id Try Again : \nEnter Continue."); check = false; goto Begin; }
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (Exception)
                {
                    check = false;
                    Console.Clear();
                    goto Begin;
                }
                break;
            default:
                Console.Clear();
                Console.WriteLine("Wrong choise! Try Again ");
                goto to;
        }

    }
    catch (Exception)
    {
        Console.Clear();
        goto to;
    }
}