using System;
using Foundation;
using UIKit;
using System.Linq;
using System.Reflection;

namespace MPDCSegueInitializer
{
    public class SegueInitializer
    {
        public SegueInitializer()
        {
        }


        public static void PrepareForSegue(string identifier ,UIViewController parentViewController,
                                        UIViewController destViewController,NSObject sender){


            var methods = parentViewController.GetType().GetRuntimeMethods()
                                              .Where(o => o.GetCustomAttributes(true).Any(a => a is SegueInitAttribute)).ToList();


            foreach (var item in methods)
            {
                var attr = item.GetCustomAttributes(true).FirstOrDefault(o=>o is SegueInitAttribute) as SegueInitAttribute;


                if(attr.SegueIdentifier==identifier){

                    item.Invoke(parentViewController, new object[]{destViewController,sender});
                }
            }

        }

      
    }
}
