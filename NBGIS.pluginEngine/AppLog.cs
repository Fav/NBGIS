using System;
using System.Collections.Generic;
using System.Text;
using log4net;

//����log4net������
[assembly: log4net.Config.XmlConfigurator(Watch=true)]
namespace NBGIS.PluginEngine
{
    /// <summary>
    /// ʹ��Log4net�����log��־����
    /// </summary>
    public class AppLog
    {
        /// <summary>
        /// ILog4net��־��̬�����
        /// </summary>
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger("NBGIS");
    }
}
