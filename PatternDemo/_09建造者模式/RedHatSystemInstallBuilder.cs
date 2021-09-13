using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09建造者模式
{
    class RedHatSystemInstallBuilder : SystemInstallBuilder
    {
        public override void DownLoadOperatingSystem()
        {
            Console.WriteLine("Red Hat Download !");
        }

        public override void WriteToUSBFlashDisk()
        {
            Console.WriteLine("Write Red Hat To USB Device !");
        }

        public override void InstallOperaingSystem()
        {
            Console.WriteLine("Red Hat Install UI Start,,,,,,");
            Console.WriteLine("Red Hat Install.......");
            Console.WriteLine("Red Hat Install Finished !");
        }

        public override void InstallDriverProgram()
        {
            Console.WriteLine("Sign In Red Hat !");
            Console.WriteLine("Install Driver......");
            Console.WriteLine("Reboot.......");

        }
    }
}
