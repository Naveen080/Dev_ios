using System;
using SQLite;
using Foundation;
using UIKit;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace dev.iOS
{
	public partial class UserViewController : UIViewController
	{
        string[] Name= new string[10];
        string[] EmployeeID=new string[10];
        string msg;
        int count;
        private List<Employee> employee;
        iosDatabase db = new iosDatabase();
        public UserViewController (IntPtr handle) : base (handle)
		{
            db.CreateDB();
            db.CreateTable();

            employee = new List<Employee>();
		}
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();//Notify.Text = "";
            AddData.TouchUpInside += delegate
            {
                if (TextName.Text.Length > 0 && TextEmployeeID.Text.Length > 0)
                {
                    msg = db.InsertData(TextName.Text, TextEmployeeID.Text);
                    Notify.Text = msg;
                }
                else
                {
                    Notify.Text = "Enter all the fields";
                }
                TextName.Text = "";TextEmployeeID.Text = "";

              };
            DisplayButton.TouchUpInside += delegate
            {
                Notify.Text = ""; DisplayLabel.Text = "";
                //display = "";
                using (var connection = new SQLite.SQLiteConnection(db.dbpath))
                {
                    var querry = connection.Table<Employee>();
                    count = querry.Count();
                }
                DisplayLabel.Text = count.ToString();
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.     
        }
	}
}
