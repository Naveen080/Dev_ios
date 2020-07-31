using System;
using System.Collections.Generic;
using UIKit;

namespace dev.iOS
{
    public partial class EditViewController : UIViewController
    {
        iosDatabase db = new iosDatabase();
        private List<Employee> employee;
        Employee emp1 = new Employee();
        //EmployeeViewController owner;//= new EmployeeViewController((IntPtr)null);
        public EditViewController(IntPtr handle) : base(handle)
        {
            //owner = new EmployeeViewController(handle);
            db.CreateDB();
            db.CreateTable();
            employee = new List<Employee>();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            using (var connection = new SQLite.SQLiteConnection(db.dbpath))
            {
                var querry = connection.Table<Employee>();
                //Console.WriteLine("{0}\n", querry.Count());
                foreach (Employee s in querry)
                {
                    if(s.id == EmployeeViewController.index1)
                    {
                        EditName.Text = s.name;
                        EditID.Text = s.employeeid;
                    }
                }

            }

            EditSubmit.TouchUpInside += delegate {
                
                var tapalert = UIAlertController.Create("Edit", "Update the employee data", UIAlertControllerStyle.Alert);
                tapalert.AddAction(UIAlertAction.Create("Update", UIAlertActionStyle.Default, alert => update()));
                tapalert.AddAction(UIAlertAction.Create("cancel", UIAlertActionStyle.Cancel, null));
                PresentViewController(tapalert, true, null);

            };

            DeleteButton .TouchUpInside += delegate {
                var tapalert = UIAlertController.Create("Delete", "Delete the employee data", UIAlertControllerStyle.Alert);
                tapalert.AddAction(UIAlertAction.Create("Delete", UIAlertActionStyle.Default, alert => delete()));
                tapalert.AddAction(UIAlertAction.Create("cancel", UIAlertActionStyle.Cancel, null));
                PresentViewController(tapalert, true, null);


            };
           
        }
        public void update()
        {
            DeleteLabel.Text = "";
            using (var connection = new SQLite.SQLiteConnection(db.dbpath))
            {
                var querry = connection.Table<Employee>();
                //Console.WriteLine("{0}\n", querry.Count());
                foreach (Employee s in querry)
                {
                    if (s.id == EmployeeViewController.index1)
                    {
                        emp1.name = EditName.Text;
                        emp1.id = EmployeeViewController.index1;
                        emp1.employeeid = EditID.Text;

                        connection.Update(emp1);
                        //EditID.Text = s.employeeid;
                        UpdateLabel.Text = "Emplyee data updated successfully";

                    }
                }

            }
        }

        public void delete()
        {
            UpdateLabel.Text = "";
            if (EditName.Text.Length > 0 && EditID.Text.Length > 0)
            {
                DeleteLabel.Text = db.DeleteData(EditName.Text, EditID.Text);
                EditName.Text = "";
                EditID.Text = "";
            }
            else
            {
                DeleteLabel.Text = "Please enter valid details";
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

