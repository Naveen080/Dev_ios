using System;
using System.IO;
using System.Text;
using UIKit;
using GlobalToast;

namespace dev.iOS
{
    public partial class AddProjectViewController : UIViewController
    {
        public AddProjectViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            AddButton.TouchUpInside += delegate {

                var document = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var filename = Path.Combine(document, "projects.txt");
                //var line = string.Format("{0} ; {1} ;", ProjectName.Text, ProjectDescription.Text);

                File.AppendAllText(filename,ProjectName.Text  + System.Environment.NewLine);
                File.AppendAllText(filename, ProjectDescription.Text  + System.Environment.NewLine);
                ProjectName.Text = "";ProjectDescription.Text  = "";
                Toast.MakeToast("Project added into file projects.txt").SetDuration(1.0).Show();
            };
             // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

