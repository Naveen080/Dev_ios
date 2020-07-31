using System;
using UIKit;
using System.Collections.Generic;
using Foundation;


namespace dev.iOS
{
    public class Tableviewsource : UITableViewSource 
    {
        private List<string> empname,empid;
        private List<int> dbid;
        int index;
        //private List<Employee> employee1;
        EmployeeViewController owner;
        //EmployeeCellView employeecell = new EmployeeCellView();
        public Tableviewsource(List<string> _ename,List<string> _eid,List<int> _dbid,EmployeeViewController _owner)
        {
           // employee1 = new List<Employee>();
            empname = _ename;empid = _eid;owner = _owner;dbid = _dbid;
            //employee1 = table;
        }
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return empname.Count;
        }


        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            //var cell = tableView.DequeueReusableCell("EmplyeeCell",indexPath);
            //cell.TextLabel.Text = employeetable [indexPath.Row];
            //return null ;
            var cell = new UITableViewCell(UITableViewCellStyle.Default, "");

            string item = empname[indexPath.Row];
            //Console.WriteLine(item);
            cell.TextLabel.Text = item ;

           cell.ImageView.Image = UIImage.FromBundle("pencil.png");
            //cell.ImageView.Frame = new CoreGraphics.CGRect()
            cell.ImageView.UserInteractionEnabled = true;
            UITapGestureRecognizer tapGesture = new UITapGestureRecognizer(Tap);
            tapGesture.NumberOfTapsRequired = 1;
            cell.ImageView.AddGestureRecognizer(tapGesture);

            //cell.TextLabel.Text = item;
            //cell.DetailTextLabel.Text = "subtext";
            //cell.ImageView.Image = UIImage.from
            //cell.
            return cell;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            Console.WriteLine("row selected is" + indexPath.Row);
            //owner
            //Instantialte the Storyboard Object
            /*UIStoryboard storyboard = UIStoryboard.FromName("YourStoryboardName", null);
            //Instantiate the ViewController you want to navigate to.
            //Make sure you have set the Storyboard ID for this ViewController in your storyboard file.
            //Put this Storyboard ID in place of the TargetViewControllerName in below line. 
            UIViewController vcInstance = (UIViewController)storyboard.InstantiateViewController("TargetViewControllerName");

            //Get the Instance of the TopViewController (CurrentViewController) or the NavigationViewController to push the TargetViewController onto the stack. 
            //NavigationController is an Instance of the NavigationViewController
            NavigationController.PushViewController(vcInstance, true);*/
            //owner.PresentViewController(EditViewController , true, null);
            index = dbid[indexPath.Row];
            //Console.WriteLine(empid[indexPath.Row]);
            owner.navigate(index);

        }

        void Tap(UIGestureRecognizer tap1)
        {
            var tapalert = UIAlertController.Create("Edit", "Image tapped", UIAlertControllerStyle.Alert);
            tapalert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel,null  ));
            //tapalert.AddTextField(Action<"Hi">);
            owner.PresentViewController(tapalert, true, null);
            //owner.NavigationController.PushViewController(EditViewController, true);
            //owner.navigate();

        }


    }
}

       
