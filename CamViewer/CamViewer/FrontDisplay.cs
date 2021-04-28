using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CamViewer
{
    public class FrontDisplay : IObserver
    {
        FrontImageSensor observable;
        static Form1 form;
        public FrontDisplay(FrontImageSensor observable)
        {
            this.observable = observable;
        }

        public void update()
        {
            Image image = this.observable.getImage();

            if (image != null)
            {
                form = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                form.pictureBoxFront.Image = image;
                form.pictureBoxFront.Refresh();
                image.Dispose();
            }
        }
    }
}
