using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CamViewer
{
    public class BackRightDisplay : IObserver
    {
        BackRightImageSensor observable;
        static Form1 form;
        public BackRightDisplay(BackRightImageSensor observable)
        {
            this.observable = observable;
        }

        public void update()
        {
            Image image = this.observable.getImage();

            if (image != null)
            {
                form = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                form.pictureBoxBackRight.Image = image;
                form.pictureBoxBackRight.Refresh();
                image.Dispose();
            }
        }
    }
}
