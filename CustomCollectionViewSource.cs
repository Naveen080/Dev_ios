// collection view data source file.
//collection view file will contain three file collectionviewsource ,collectionviewcontroller,customcollectionview
using System;
using UIKit;
using Foundation;
using CoreGraphics;
using System.Collections.Generic;

namespace dev.iOS
{
    public class CustomCollectionSource : UICollectionViewSource 
    {
        //string[] rowname = new string[10];
        //string[] rowdescription = new string[10];
        List<string> rowname;List<string> rowdescription;
        public CustomCollectionSource(List<string> _rowname ,List<string> _rowdescription)
        {
            rowname = _rowname;rowdescription = _rowdescription;
        }

        [Export("numberOfSectionsInCollectionView:")]
        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        } 

        [Export("collectionView:numberOfItemsInSection:")]
        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return rowname.Count;
        }
        [Export("collectionView:shouldHighlightItemAtIndexPath:")]
        public override bool ShouldHighlightItem(UICollectionView collectionView, NSIndexPath indexPath)
        {
            return true;
        }
		public override void ItemHighlighted(UICollectionView collectionView, NSIndexPath indexPath)
		{
            var cell = (CustomCollectionViewCell)collectionView.CellForItem(indexPath);
            cell.projectName.Alpha = 0.5f;
		}
		//[Export("collectionView:didDeselectItemAtIndexPath:")]
		public override void ItemUnhighlighted(UICollectionView collectionView, NSIndexPath indexPath)
		{
            var cell = (CustomCollectionViewCell)collectionView.CellForItem(indexPath);
            cell.projectName.Alpha = 1.0f;
		}

		public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
		{
            var cell = (CustomCollectionViewCell)collectionView.DequeueReusableCell(CustomCollectionViewCell.CellID,indexPath);
            cell.updatecell(rowname[indexPath.Row],rowdescription[indexPath.Row]);
            return cell;
		}
	}
}
