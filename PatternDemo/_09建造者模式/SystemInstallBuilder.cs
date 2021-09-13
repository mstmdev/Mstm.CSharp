using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09建造者模式
{
    abstract class SystemInstallBuilder
    {
        public abstract void DownLoadOperatingSystem();

        public abstract void WriteToUSBFlashDisk();

        public abstract void InstallOperaingSystem();

        public abstract void InstallDriverProgram();
    }
}
