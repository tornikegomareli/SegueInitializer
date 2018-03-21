using System;
namespace MPDCSegueInitializer
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SegueInitAttribute:Attribute
    {
        public SegueInitAttribute(string SegueIdentifier)
        {
            this.SegueIdentifier = SegueIdentifier;
        }

        public string SegueIdentifier
        {
            get;
            set;
        }
    }
}
