using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Car_Lock_System;

namespace LibraryTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Launcher launcher = new Launcher();
            launcher.KeyPress += CarLock.OnKeyUp;
            launcher.launch();
            Console.WriteLine("Launched Event");
        }
    }

    class Launcher
    {
        public event KeyEventHandler KeyPress;
        public KeyEventArgs e;

        protected virtual void OnKeyPress(KeyEventArgs e)
        {
            KeyEventHandler handler = KeyPress;
            handler(this, e);
        }

        public Launcher()
        {
            e = new KeyEventArgs(Keys.K);
        }

        public void launch()
        {
            OnKeyPress(e);
        }
    }
}
