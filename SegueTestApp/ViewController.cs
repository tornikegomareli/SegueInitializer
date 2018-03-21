using System;
using Foundation;
using MPDCSegueInitializer;
using UIKit;

namespace SegueTestApp
{
    
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }


        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            SegueInitializer.PrepareForSegue(segue.Identifier,this,segue.DestinationViewController,sender);

        }


        [SegueInit("argumentSegue")]
        private void argumentSegueMethod(TestViewController destVc, NSObject sender)
        {
            

            destVc.Argument = textField.Text;
        }

        const string Kutu = "thirdSegue";


        [SegueInit(Kutu)]
        private void thirdSegueTestMethod(UIViewController destVc, NSObject sender)
        {

            var testVc =destVc as TestViewController;
            testVc.Argument = "third segue";

        }




        [SegueInit("segueIdentiFier")]
        private void segueMethodName(UIViewController destVc, NSObject sender)
        {
            var testVc = destVc as TestViewController;
            testVc.Argument = ".i.";
        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
