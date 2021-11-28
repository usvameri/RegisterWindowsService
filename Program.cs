using System;
using System.Diagnostics;
using System.IO;

namespace ServiceRegisterer
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: service start type is will be selectable
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
                        ServiceAction(serviceName, serviceDirectory, "create");
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
                        ServiceAction(serviceName,null, action:"delete");
                    else
                        goto DNAME;
                }
                else if (action == "s" || action == "start")
                {
                    SNAME:
                    Console.WriteLine("Enter a service name: ");
                    serviceName = Console.ReadLine();
                    if (serviceName != "")
                        ServiceAction(serviceName,null, action:"start");
                    else
                        goto SNAME;
                }
                else if (action == "st" || action == "stop")
                {
                    STSNAME:
                    Console.WriteLine("Enter a service name: ");
                    serviceName = Console.ReadLine();
                    if (serviceName != "")
                        ServiceAction(serviceName,null, action:"stop");
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
    
        static void ServiceAction(string serviceName, string serviceDirectory, string action)
        {
            Process proc = new Process(); //call new Process
            ProcessStartInfo info = new ProcessStartInfo(); //call new ProcessStartInfo
            
            if (action == "create" || action == "c")
            {
                info.Arguments = string.Format(@"{0} {1} binpath={2} start=auto", action, serviceName, serviceDirectory);//set the arguments)

            }
            else
                info.Arguments = string.Format(@"{0} {1} ",action, serviceName); //set the arguments)
            info.FileName = "sc.exe"; //set the file name (location)
            info.UseShellExecute = true;
            info.Verb = "runas";
            proc.StartInfo = info; //put the StartInfo into the Procces method
            proc.Start(); //Start the procces (sc.exe with the arguments)
            proc.WaitForExit(); //waits till the procces is done
        }
    }
}
