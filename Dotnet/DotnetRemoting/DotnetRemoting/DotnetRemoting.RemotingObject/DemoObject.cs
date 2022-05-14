using DotnetRemoting.RemotingObject.model;
using System;

namespace DotnetRemoting.RemotingObject
{
    /// <summary>
    /// 由于Remoting传递的对象是以引用的方式，
    /// 因此所传递的远程对象类必须继承MarshalByRefObject
    /// </summary>
    public class DemoObject : MarshalByRefObject
    {
        public BaseModel Get(BaseParam param)
        {
            Logger.Write("Get");
            return new BaseModel()
            {
                Id = 1,
                CreateStamp = DateTime.Now
            };
        }

        public int Add(BaseModel model)
        {
            Logger.Write("Add");
            return 1;
        }

        public void Update(BaseModel model)
        {
            Logger.Write("Updates");
            Console.WriteLine("Update");
        }

        public void Delete(int id)
        {
            Logger.Write("Delete");
            Console.WriteLine("Delete");
        }
    }
}
