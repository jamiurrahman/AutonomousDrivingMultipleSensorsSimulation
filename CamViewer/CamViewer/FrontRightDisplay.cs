using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CamViewer
{
    public class FrontRightDisplay : IObserver
    {
        FrontRightImageSensor observable;
        static Form1 form;
        public FrontRightDisplay(FrontRightImageSensor observable)
        {
            this.observable = observable;
        }

        public void update()
        {
            Image image = this.observable.getImage();

            if (image != null)
            {
                form = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                form.pictureBoxFrontRight.Image = image;
                form.pictureBoxFrontRight.Refresh();
                image.Dispose();
            }
        }
    }
}
