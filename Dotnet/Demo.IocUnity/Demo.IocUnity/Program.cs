using Demo.IocUnity.Phone;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Demo.IocUnity
{
    class Program
    {
        static void Main(string[] args)
        {
            #region demo

            //IUnityContainer container = new UnityContainer();//1、定义一个空容器
            //container.RegisterType<IDbInterface, DbMSSQL>();//2、注册类型，表示遇到IDbInterface的类型，创建DbMSSQL的实例
            //var db = container.Resolve<IDbInterface>();
            //var result = db.Insert();

            //Console.WriteLine(result);
            #endregion

            #region config demo

           
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Unity.config");//找配置文件的路径
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
            IUnityContainer container = new UnityContainer();

            section.Configure(container, "testContainer");
            IDbInterface db = container.Resolve<IDbInterface>("sql");
            var result = db.Insert();
            Console.WriteLine(result);
            #endregion

            #region inject demo

            //IUnityContainer container = new UnityContainer();
            //container.RegisterType<IPhone, ApplePhone>();
            //container.RegisterType<IMicrophone, Microphone>();
            //container.RegisterType<IHeadphone, Headphone>();
            //container.RegisterType<IPower, Power>();

            //IPhone phone = container.Resolve<IPhone>();

            //Console.WriteLine($"phone.iHeadphone==null?  {phone.iHeadphone == null}");
            //Console.WriteLine($"phone.iMicrophone==null? {phone.iMicrophone == null}");
            //Console.WriteLine($"phone.iPower==null?      {phone.iPower == null}");
            #endregion

            Console.ReadKey();
        }
    }
}
