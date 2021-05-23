﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FcpSims
{
    static class Simulator
    {
        /// define logger
        /// 
        
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        public static MainSim mainForm;

        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // config logger
                log4net.Config.XmlConfigurator.Configure(
                    new System.IO.FileInfo("config/sofcsims-log4net.xml"));

                mainForm = new MainSim();

                Application.Run(mainForm);
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message);
            }
        }
    }
}
