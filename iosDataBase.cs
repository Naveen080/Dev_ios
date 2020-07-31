using System;
using System.IO;
using SQLite;
using Foundation;
using System.Collections.Generic;

namespace dev.iOS
{
    public class iosDatabase
    {
        string Insertmsg;
        string Deletemsg;
        bool InsertFlag,DeleteFlag;
        public string dbpath = "";
        //public List<Employee> employee;
        public iosDatabase()
        {
        }

        public void CreateDB()
        {
            dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                                  "devios.db3");
            Console.WriteLine("Database created with path {0}", dbpath);

            /*using (var connection = new SQLite.SQLiteConnection(dbpath))
            {
                connection.CreateTable<Employee>();

            }*/
        }

        public void CreateTable()
        {
            Employee employee = new Employee();
            using (var connection = new SQLite.SQLiteConnection(dbpath))
            {
                connection.CreateTable<Employee>();

            }
        }

        public string InsertData(string employeename ,string employeeid)
        {
            InsertFlag = false ;
            var employee = new List<Employee>();
            using (var connection = new SQLite.SQLiteConnection(dbpath))
            {
                var querry = connection.Table<Employee>();
                foreach (Employee s in querry)
                {
                    if (employeename == s.name || employeeid == s.employeeid)
                    {

                        InsertFlag = true; break;

                    }
                }
                if (InsertFlag == true)
                {
                    Insertmsg  = "user already exists";

                    //InsertFlag  = false;
                }
                else
                {
                    connection.Insert(new Employee() { name = employeename , employeeid = employeeid  });
                    Insertmsg  = "user added succesfully";
                }

            }
            return Insertmsg;
        }

        public string DeleteData(string employeename , string employeeid)
        {
            DeleteFlag = false ;
            var employee = new List<Employee>();
            using (var connection = new SQLite.SQLiteConnection(dbpath))
            {
                
                var querry = connection.Table<Employee>();
                foreach (Employee s in querry)
                {
                    if (employeename  == s.name && employeeid  == s.employeeid)
                    {
                        connection.Delete<Employee>(s.id);
                        Deletemsg  = "employee deleted successfully";
                        DeleteFlag  = true;
                    }
                }
                if (DeleteFlag  == false)
                {
                    Deletemsg = "employee not found";
                }
            }
            return Deletemsg;
        }

        //public Employee FetchEmployee()


    }
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int id
        {
            get; set;
        }
        public string name
        {
            get; set;
        }
        public string employeeid
        {
            get; set;
        }
    }
}
