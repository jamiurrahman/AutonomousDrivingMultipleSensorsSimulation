using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CamViewer
{
    public class FrontLeftDisplay : IObserver
    {
        FrontLeftImageSensor observable;
        static Form1 form;
        public FrontLeftDisplay(FrontLeftImageSensor observable)
        {
            this.observable = observable;
        }

        public void update()
        {
            Image image = this.observable.getImage();

            if (image != null)
            {
                form = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                form.pictureBoxFrontLeft.Image = image;
                form.pictureBoxFrontLeft.Refresh();
                image.Dispose();
            }
        }
    }
}
