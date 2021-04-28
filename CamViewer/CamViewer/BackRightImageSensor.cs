using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CamViewer
{
    public class BackRightImageSensor : IObservable
    {

        List<IObserver> observers;
        string[] images;
        int index;

        public BackRightImageSensor()
        {
            observers = new List<IObserver>();
            images = System.IO.Directory.GetFiles(@"C:\DB\v1.0-mini\sweeps\CAM_BACK_RIGHT", "*.jpg");
        }
        public void add(IObserver observer)
        {
            this.observers.Add(observer);
        }
        public void remove(IObserver observer)
        {
            this.observers.Remove(observer);
        }
        public void notify()
        {
            foreach (IObserver observer in observers)
            {
                observer.update();
            }
        }

        public Image getImage()
        {
            if (index < images.Length)
            {
                return Image.FromFile(images[index++]);
            }

            return null;
        }
    }
}
