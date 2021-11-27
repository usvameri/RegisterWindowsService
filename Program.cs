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
                DeleteService("LicenceWorkorder");
                RegisterService("LicenceWorkorder");
                StartService("LicenceWorkorder");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                Console.ReadKey();
            }
            

        }
    
        static void RegisterService(string serviceName)
        {

            Process proc = new Process(); //call new Process
            ProcessStartInfo info = new ProcessStartInfo(); //call new ProcessStartInfo
            info.Arguments = string.Format(@"create {0} binpath=c:\checklicence\LicenceWorkorder.exe start=auto",serviceName); //set the arguments)
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
            info.Arguments = string.Format(@"delete {0}", serviceName); )
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
    }
}
