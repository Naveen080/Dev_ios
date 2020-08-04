//Designing the collection view cell programatically.
using System;
using UIKit;
using Foundation;
using CoreGraphics;

namespace dev.iOS
{
    public class CustomCollectionViewCell : UICollectionViewCell
    {
        public UILabel projectName, description;
        public static NSString CellID = new NSString("customCollectionCell");

        [Export("initWithFrame:")]
        public CustomCollectionViewCell(CGRect frame) : base(frame)
        {
            BackgroundView = new UIView { BackgroundColor = UIColor.Orange};
            ContentView.Layer.BorderColor = UIColor.Blue.CGColor;
            ContentView.Layer.BorderWidth = 5.0f;
            ContentView.BackgroundColor = UIColor.White;
            projectName = new UILabel();
            projectName.TextColor = UIColor.Red; 
            projectName.TextAlignment = UITextAlignment.Center;
            description = new UILabel();
            description.TextAlignment = UITextAlignment.Center;
            description.LineBreakMode = UILineBreakMode.CharacterWrap;//UILineBreakMode.WordWrap;
            description.Lines = 0;

            ContentView.AddSubviews(new UIView[] { projectName, description});

        }
        public void updatecell(string itemname,string itemdescription)
        {
            projectName.Text = itemname; 
            description.Text = itemdescription;
            projectName.Frame = new CGRect(5,5,ContentView.Bounds.Width ,20);
            description.Frame = new CGRect(5, 35, ContentView.Bounds.Width, 50);
        }
    }
}
