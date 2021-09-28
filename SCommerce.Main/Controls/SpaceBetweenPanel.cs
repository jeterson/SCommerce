using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace SCommerce.Main.Controls
{
    public class SpaceBetweenPanel : Panel
    {
        private double itemWidth = 0;
        protected override Size MeasureOverride(Size availableSize)
        {
            var remainingSize = availableSize;
            var size = new Size(); 
            foreach(var item in Children)
            {
                item.Measure(remainingSize);
                if (item.DesiredSize.Height > size.Height)
                {
                    size.Height = item.DesiredSize.Height;
                }
                size.Width += item.DesiredSize.Width;
                remainingSize.Width -= item.DesiredSize.Width;
            }

            itemWidth = size.Width;
            return size;
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
  
            var size = new Size();
            
            var spaceBetween = (finalSize.Width - itemWidth) / (Children.Count - 1);

            foreach(var item in Children)
            {
                if (item.DesiredSize.Height > size.Height)
                {
                    size.Height = item.DesiredSize.Height;
                }
              

                item.Arrange(new Rect(size.Width, 0, item.DesiredSize.Width, item.DesiredSize.Height));
                size.Width += item.DesiredSize.Width + spaceBetween;
               
            }
            return size;
        }
    }
}
