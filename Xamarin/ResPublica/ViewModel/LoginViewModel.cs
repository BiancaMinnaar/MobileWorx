using System;
using System.IO;
using System.Reflection;
using System.Windows.Input;
using ResPublica.Base;

namespace ResPublica.Implementation.ViewModel
{
    public class LoginViewModel : ProjectBaseViewModel
    {
        public byte[] BackGround
        {
            get
            {
                var assembly = typeof(App).GetTypeInfo().Assembly;
                byte[] buffer;
                using (Stream s = assembly.GetManifestResourceStream("ResPublica.Images.Login_Background.jpg"))
                {
                    long length = s.Length;
                    buffer = new byte[length];
                    s.Read(buffer, 0, (int)length);

                    return buffer;
                }
            }
        }

        public string SvgFileName{ get { return "CallStartTime.svg"; }}

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}