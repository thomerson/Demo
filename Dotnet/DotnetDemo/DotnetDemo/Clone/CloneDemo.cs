using System;

namespace DotnetDemo
{
    public class CloneDemo
    {
        public void Test()
        {
            // 值类型

            var aa = 11;
            var bb = aa;
            bb = 22;

            Console.WriteLine(aa); //11

            // string

            var cc = "11";
            var dd = cc;
            dd = "22";

            Console.WriteLine(cc); //"11"

            // 引用类型

            var ee = new CloneDemoInfo() { ID = 11, ExtensionInfo = new ExtensionInfo() { Name = "Name" } };
            var ff = ee;
            var gg = ee.ShallowCopy();
           

           

            ff.ID = 22;
            ff.ExtensionInfo = new ExtensionInfo() { Name = "newName" };

            Console.WriteLine(ee.ID); // 22

            Console.WriteLine(ee.ExtensionInfo.Name); // newName

            var hh = ee.Clone();

            hh.ID = 33;
            hh.ExtensionInfo = new ExtensionInfo() { Name = "CloneName" };

            Console.WriteLine(ee.ID); // 22

            Console.WriteLine(ee.ExtensionInfo.Name); // newName

        }
    }

    [Serializable]
    public class ExtensionInfo
    {
        public string Name { get; set; }
    }

    [Serializable]
    public class CloneDemoInfo : BaseClone<CloneDemoInfo>
    {

        public int ID { get; set; } //值类型

        public ExtensionInfo ExtensionInfo { get; set; } //引用类型

        /// <summary>
        /// 浅复制
        /// </summary>
        /// <returns></returns>
        public CloneDemoInfo ShallowCopy()
        {
            return (CloneDemoInfo)this.MemberwiseClone();
        }


    }
}
