using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09建造者模式
{
    class WebmasterDirector
    {
        private SystemInstallBuilder _builder;
        public WebmasterDirector(SystemInstallBuilder builder)
        {
            _builder = builder;
        }

        public void InstallSystem()
        {
            _builder.DownLoadOperatingSystem();
            _builder.WriteToUSBFlashDisk();
            _builder.InstallOperaingSystem();
            _builder.InstallDriverProgram();
            Console.WriteLine("All Finished !");
        }
    }
}
