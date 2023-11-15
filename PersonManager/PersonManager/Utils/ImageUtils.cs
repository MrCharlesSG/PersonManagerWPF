using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PersonManager.Utils
{
    public static class ImageUtils
    {
        public static BitmapImage ByteArrayToBitmapImage(byte[] picture)
        {
            using var memoryStream = new MemoryStream(picture);
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = memoryStream;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
            bitmapImage.Freeze();
            return bitmapImage;
        }
        public static byte[] BitmapImageToByteArray(BitmapImage bitmapImage)
        {
            var jpegEncoder = new JpegBitmapEncoder();
            jpegEncoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using var memoryStream = new MemoryStream();
            jpegEncoder.Save(memoryStream);
            return memoryStream.ToArray();
        }

        public static byte[] ByteArrayFromReader(SqlDataReader dr, string column)
        {
            using var memoryStream = new MemoryStream();
            using var binaryWriter = new BinaryWriter(memoryStream);

            int bufferSize = 1024;
            byte[] buffer = new byte[bufferSize];
            int currentBytes = 0;


            int readBytes;
            do
            {
                readBytes = (int)dr.GetBytes(dr.GetOrdinal(column), 
                    currentBytes,
                    buffer,
                    0, 
                    bufferSize
                    );
                binaryWriter.Write(buffer, 0, readBytes);
                currentBytes += readBytes;

            } while (readBytes == bufferSize);


            return memoryStream.ToArray();
            
        }
    }
}
