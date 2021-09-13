using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09建造者模式
{
    class Win7SystemInstallBuilder : SystemInstallBuilder
    {
        public override void DownLoadOperatingSystem()
        {
            Console.WriteLine("Win7 Download !");
        }

        public override void WriteToUSBFlashDisk()
        {
            Console.WriteLine("Write Win7 To USB Device !");
        }

        public override void InstallOperaingSystem()
        {
            Console.WriteLine("Win7 Install UI Start,,,,,,");
            Console.WriteLine("Win7 Install.......");
            Console.WriteLine("Win7 Install Finished !");
        }

        public override void InstallDriverProgram()
        {
            Console.WriteLine("Sign In Win7 !");
            Console.WriteLine("Install Driver......");
            Console.WriteLine("Reboot.......");
        }
    }
}
