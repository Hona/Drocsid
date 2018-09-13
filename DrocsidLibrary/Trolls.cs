using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrocsidLibrary
{
    public class Trolls
    {
        private bool _mouseSpaz;
        private Form _parentForm;
        private BackgroundWorker _mouseSpazWorker;
        public void MouseSpazOn(Form form)
        {
            if (form == null) return;
            _parentForm = form;

            _mouseSpaz = true;
            _mouseSpazWorker = new BackgroundWorker();
            _mouseSpazWorker.DoWork += MouseSpazLoop;
        }
        public void MouseSpazOff()
        {
            _mouseSpaz = false;
        }

        private void MouseSpazLoop(object sender, DoWorkEventArgs e)
        {
            while (_mouseSpaz)
            {

                Thread.Sleep(10);
            }
        }
    }
}
