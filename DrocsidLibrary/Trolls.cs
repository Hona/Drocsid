using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace DrocsidLibrary
{
    public class Trolls
    {
        private bool _mouseSpaz;
        private BackgroundWorker _mouseSpazWorker;
        private Form _parentForm;

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
                Thread.Sleep(10);
        }
    }
}