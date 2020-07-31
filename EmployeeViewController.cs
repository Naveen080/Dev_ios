using System;
using SQLite;
using System.Linq;
using System.Collections.Generic;
using UIKit;
using System.IO;

namespace dev.iOS
{
    
    public partial class EmployeeViewController : UIViewController
    {
        iosDatabase db = new iosDatabase();
        public List<Employee> employee;
        //Employee emp;
        List<string> ename;
        List<string> eid;
        List<int> dbid;
        public static int index1;
        private string dbpath;
        //UserViewController table = new UserViewController();
        public EmployeeViewController(IntPtr handle) : base (handle)
        /*: base("EmployeeViewController", null)*/
        {
            ename = new List<string> ();
            eid = new List<string>();
            dbid = new List<int>();
            employee = new List<Employee>();
            dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                                  "devios.db3");
            Console.WriteLine("Database created with path {0}", dbpath);
            /*for (int i = 0; i < 20;i++)
            {
                tableitem.Add("item number" + i.ToString());
            }*/
        }

        public override void ViewDidLoad()
        {
            
            base.ViewDidLoad();
            using (var connection = new SQLite.SQLiteConnection(dbpath))
            {
                //connection.CreateTable<Employee>();
                var querry = connection.Table<Employee>();
                Console.WriteLine("{0}\n", querry.Count());
                //emp = querry;
                //EmployeeTable.Source = new Tableviewsource();
                foreach (Employee s in querry) 
                {
                    ename.Add(s.name);
                    //" :" + 
                    eid.Add (s.employeeid );
                    dbid.Add(s.id);
                    Console.WriteLine("{0}:{1}:{2}\n", s.id, s.name, s.employeeid);
                }

            }
            EmployeeTable.Source = new Tableviewsource(ename,eid,dbid,this);
            // Perform any additional setup after loading the view, typically from a nib.
        }
        public void navigate(int index)
        {
            EditViewController  editviewController = this.Storyboard.InstantiateViewController("EditViewController") as EditViewController;
            if (editviewController != null)
            {
                //NavigationController.PushViewController(editViewController , true);
                //NavigationController.PresentViewController(editviewController , true);
                Console.WriteLine(index);
                index1 = index;
                PresentViewController(editviewController , true,null);
            }


        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

