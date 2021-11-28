using System;
using System.Diagnostics;
using System.IO;

namespace ServiceRegisterer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                START:
                Console.WriteLine("Select the action to do (r,d,s) --> Register/r, Delete/d, Start/s, Stop/st");
                string action = Console.ReadLine().ToLower();
                string serviceName;

                if (action == "r" || action == "register")
                {
                    RNAME:
                    Console.WriteLine("Enter a service name: ");
                    serviceName = Console.ReadLine();
                    if (serviceName != "")
                    {
                        Console.WriteLine("Enter a service directory");
                        string serviceDirectory = Console.ReadLine();
                        RegisterService(serviceName, serviceDirectory);
                    }
                    else
                        goto RNAME;

                }
                else if (action == "d" || action == "delete")
                {
                    DNAME:
                    Console.WriteLine("Enter a service name: ");
                    serviceName = Console.ReadLine();
                    if(serviceName != "")
                        DeleteService(serviceName);
                    else
                        goto DNAME;
                }
                else if (action == "s" || action == "start")
                {
                    SNAME:
                    Console.WriteLine("Enter a service name: ");
                    serviceName = Console.ReadLine();
                    if (serviceName != "")
                        StartService(serviceName);
                    else
                        goto SNAME;
                }
                else if (action == "st" || action == "stop")
                {
                    STSNAME:
                    Console.WriteLine("Enter a service name: ");
                    serviceName = Console.ReadLine();
                    if (serviceName != "")
                        StopService(serviceName);
                    else
                        goto STSNAME;
                }
                else
                    goto START;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                Console.ReadKey();
            }
            

        }
    
        static void RegisterService(string serviceName, string serviceDirectory)
        {

            Process proc = new Process(); //call new Process
            ProcessStartInfo info = new ProcessStartInfo(); //call new ProcessStartInfo
            info.Arguments = string.Format(@"create {0} binpath={1} start=auto",serviceName,serviceDirectory); //set the arguments)
            info.FileName = "sc.exe"; //set the file name (location)
            info.UseShellExecute = true;
            info.Verb = "runas";
            proc.StartInfo = info; //put the StartInfo into the Procces method
            proc.Start(); //Start the procces (sc.exe with the arguments)
            proc.WaitForExit(); //waits till the procces is done
        }
        static void DeleteService(string serviceName)
        {

            Process proc = new Process(); 
            ProcessStartInfo info = new ProcessStartInfo(); 
            info.Arguments = string.Format(@"delete {0}", serviceName);
            info.FileName = "sc.exe"; 
            info.UseShellExecute = true;
            info.Verb = "runas";
            proc.StartInfo = info; 
            proc.Start(); 
            proc.WaitForExit(); 
        }
        static void StartService(string serviceName)
        {
            Process proc = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.Arguments = string.Format(@"start {0}", serviceName);
            info.FileName = "sc.exe";
            info.UseShellExecute = true;
            info.Verb = "runas";
            proc.StartInfo = info;
            proc.Start();
            proc.WaitForExit(); 
        }
        static void StopService(string serviceName)
        {
            Process proc = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.Arguments = string.Format(@"stop {0}", serviceName);
            info.FileName = "sc.exe";
            info.UseShellExecute = true;
            info.Verb = "runas";
            proc.StartInfo = info;
            proc.Start();
            proc.WaitForExit();
        }
    }
}
