using System;

namespace DotnetRemoting.RemotingObject.model
{

    [Serializable]
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreateStamp { get; set; }
    }
}
