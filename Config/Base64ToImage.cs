using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM022024RestApi.Config
{
    public class Base64ToImage : IValueConverter
    {
        public object Convert(Object value, Type targetType, object parameter, CultureInfo culture)
        {
            ImageSource image = null;

            if (value == null)
            {
                String Base64Image = (String)value;
                byte[] fotobyte = System.Convert.FromBase64String(Base64Image);
                var stream = new MemoryStream(fotobyte);
                image = ImageSource.FromStream(() => stream);
            }
            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
