using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actualizer.BusinessLogic.HelperModels
{
    public class Product
    {
        public const Int32 IMAGE_SIZE = 16;
        public static List<Boolean> GetHash(Bitmap bmpSource)
        {
            List<bool> lResult = new List<bool>();
            //create new image with 16x16 pixel
            Bitmap bmpMin = new Bitmap(bmpSource, new Size(IMAGE_SIZE, IMAGE_SIZE));
            for (int j = 0; j < bmpMin.Height; j++)
            {
                for (int i = 0; i < bmpMin.Width; i++)
                {
                    //reduce colors to true / false                
                    lResult.Add(bmpMin.GetPixel(i, j).GetBrightness() < 0.5f);
                }
            }
            return lResult;
        }

        public static Int32 CompareImages(Bitmap firstImage, Bitmap secondImage)
        {
            List<Boolean> iHash1 = GetHash(firstImage);
            List<Boolean> iHash2 = GetHash(secondImage);
            
            Int32 equalElements = iHash1.Zip(iHash2, (i, j) => i == j).Count(eq => eq);
            return (IMAGE_SIZE * IMAGE_SIZE) - equalElements;
        }

        public static void TestCompareImages()
        {
            String imageBase = "/images/testImage.jpg";
            String imageChanged = "/images/testImageChanged.jpg";
            String imageDifferent = "/images/testIageDifferent.jpg";

            


        }
    }
}
