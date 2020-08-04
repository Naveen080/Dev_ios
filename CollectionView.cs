//code in collection viewcontroller.
using System;
using System.Collections.Generic;
using UIKit;
using System.IO;

namespace dev.iOS
{
    public partial class CollectionView : UIViewController
    {
        //string[] itemname = new string[] { "Project A", "Project B", "Project C" };
        //string[] itemdescription = new string[] { "Deals with technology abc", "This project Involves in improving \n xyz technology", "Development of bla bla rover" };
        List<string> itemname;
        List<string> itemdescription;
        int count = 0;
        public CollectionView(IntPtr handle) : base(handle)
        {
            itemname = new List<string>();
            itemdescription = new List<string>();

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            count = 0;
            var document = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filename = Path.Combine(document, "projects.txt");
            //File.WriteAllText(filename, "Project ABC" + System.Environment.NewLine);
            //File.AppendAllText(filename,"Developing abc app" + System.Environment.NewLine);
            
            var lines = File.ReadAllLines(filename);
            //Console.WriteLine(lines);
            //string[] items = lines.Split(';');
            //Console.WriteLine(items.Length);


            foreach (var text in lines )
            {
                Console.WriteLine(text);
                if (count % 2 == 0)
                {
                    itemname.Add(text);

                }
                else
                {
                    itemdescription.Add(text);
                }
                count++;
            }
            collectionView.RegisterClassForCell(typeof(CustomCollectionViewCell),CustomCollectionViewCell.CellID);
            collectionView.Source = new CustomCollectionSource(itemname,itemdescription);
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

