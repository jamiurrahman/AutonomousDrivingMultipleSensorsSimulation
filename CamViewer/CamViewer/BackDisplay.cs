using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace CamViewer
{
    public class BackDisplay : IObserver
    {
        BackImageSensor observable;
        static Form1 form;
        public BackDisplay(BackImageSensor observable)
        {
            this.observable = observable;
        }

        public void update()
        {
            Image image = this.observable.getImage();

            if (image != null)
            {
                form = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                form.pictureBoxBack.Image = image;
                form.pictureBoxBack.Refresh();
                image.Dispose();
            }
        }
    }
}
