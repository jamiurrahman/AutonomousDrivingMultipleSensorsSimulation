using CamViewer.Properties;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamViewer
{
    public partial class Form1 : Form
    {
        Image imagePrev = Resources.previous;
        Image imagePlay = Resources.play;
        Image imagePause = Resources.pause;
        Image imageNext = Resources.next;

        CancellationTokenSource _cancelTokenFrontLeft = new CancellationTokenSource();
        CancellationTokenSource _cancelTokenFrontRight = new CancellationTokenSource();
        CancellationTokenSource _cancelTokenFront = new CancellationTokenSource();
        CancellationTokenSource _cancelTokenBackLeft = new CancellationTokenSource();
        CancellationTokenSource _cancelTokenBackRight = new CancellationTokenSource();
        CancellationTokenSource _cancelTokenBack = new CancellationTokenSource();

        FrontLeftImageSensor frontLeftImageSensor;
        FrontLeftDisplay frontLeftDisplay;
        FrontRightImageSensor frontRightImageSensor;
        FrontRightDisplay frontRightDisplay;
        FrontImageSensor frontImageSensor;
        FrontDisplay frontDisplay;
        BackLeftImageSensor backLeftImageSensor;
        BackLeftDisplay backLeftDisplay;
        BackRightImageSensor backRightImageSensor;
        BackRightDisplay backRightDisplay;
        BackImageSensor backImageSensor;
        BackDisplay backDisplay;

        public Form1()
        {
            InitializeComponent();

            this.frontLeftImageSensor = new FrontLeftImageSensor();
            this.frontLeftDisplay = new FrontLeftDisplay(this.frontLeftImageSensor);
            frontLeftImageSensor.add(frontLeftDisplay);

            this.frontRightImageSensor = new FrontRightImageSensor();
            this.frontRightDisplay = new FrontRightDisplay(this.frontRightImageSensor);
            frontRightImageSensor.add(frontRightDisplay);

            this.frontImageSensor = new FrontImageSensor();
            this.frontDisplay = new FrontDisplay(frontImageSensor);
            frontImageSensor.add(frontDisplay);

            this.backLeftImageSensor = new BackLeftImageSensor();
            this.backLeftDisplay = new BackLeftDisplay(backLeftImageSensor);
            backLeftImageSensor.add(backLeftDisplay);

            this.backRightImageSensor = new BackRightImageSensor();
            this.backRightDisplay = new BackRightDisplay(backRightImageSensor);
            backRightImageSensor.add(backRightDisplay);

            this.backImageSensor = new BackImageSensor();
            this.backDisplay = new BackDisplay(backImageSensor);
            backImageSensor.add(backDisplay);
        }

        private void btnFrontLeftPlay_Click(object sender, EventArgs e)
        {
            if (btnFrontLeftPlay.Image.Equals(imagePlay))
            {
                btnFrontLeftPlay.Image = imagePause;
                btnFrontLeftPlay.Refresh();

                notifyFrontLeftImageSensor();
            }
            else
            {
                btnFrontLeftPlay.Image = imagePlay;
                btnFrontLeftPlay.Refresh();

                _cancelTokenFrontLeft.Cancel();
            }

        }

        
        private void btnFrontPlay_Click(object sender, EventArgs e)
        {
            if (btnFrontPlay.Image.Equals(imagePlay))
            {
                btnFrontPlay.Image = imagePause;
                btnFrontPlay.Refresh();

                notifyFrontImageSensor();
            }
            else
            {
                btnFrontPlay.Image = imagePlay;
                btnFrontPlay.Refresh();

                _cancelTokenFront.Cancel();
            }
        }

        private void btnFrontRightPlay_Click(object sender, EventArgs e)
        {
            if (btnFrontRightPlay.Image.Equals(imagePlay))
            {
                btnFrontRightPlay.Image = imagePause;
                btnFrontRightPlay.Refresh();

                notifyFrontRightImageSensor();
            }
            else
            {
                btnFrontRightPlay.Image = imagePlay;
                btnFrontRightPlay.Refresh();

                _cancelTokenFrontRight.Cancel();
            }
        }

        private void btnBackLeftPlay_Click(object sender, EventArgs e)
        {
            if (btnBackLeftPlay.Image.Equals(imagePlay))
            {
                btnBackLeftPlay.Image = imagePause;
                btnBackLeftPlay.Refresh();

                notifyBackLeftImageSensor();
            }
            else
            {
                btnBackLeftPlay.Image = imagePlay;
                btnBackLeftPlay.Refresh();

                _cancelTokenBackLeft.Cancel();
            }
        }

        private void btnBackPlay_Click(object sender, EventArgs e)
        {
            if (btnBackPlay.Image.Equals(imagePlay))
            {
                btnBackPlay.Image = imagePause;
                btnBackPlay.Refresh();

                notifyBackImageSensor();
            }
            else
            {
                btnBackPlay.Image = imagePlay;
                btnBackPlay.Refresh();

                _cancelTokenBack.Cancel();
            }
        }

        private void btnBackRightPlay_Click(object sender, EventArgs e)
        {
            if (btnBackRightPlay.Image.Equals(imagePlay))
            {
                btnBackRightPlay.Image = imagePause;
                btnBackRightPlay.Refresh();

                notifyBackRightImageSensor();
            }
            else
            {
                btnBackRightPlay.Image = imagePlay;
                btnBackRightPlay.Refresh();

                _cancelTokenBackRight.Cancel();
            }
        }

        private void btnCenterPlay_Click(object sender, EventArgs e)
        {
            if (btnCenterPlay.Image.Equals(imagePlay))
            {
                btnCenterPlay.Image = imagePause;
                btnCenterPlay.Refresh();

                btnFrontLeftPlay.Image = imagePause;
                btnFrontLeftPlay.Refresh();
                btnFrontRightPlay.Image = imagePause;
                btnFrontRightPlay.Refresh();
                btnFrontPlay.Image = imagePause;
                btnFrontPlay.Refresh();
                btnBackLeftPlay.Image = imagePause;
                btnBackLeftPlay.Refresh();
                btnBackRightPlay.Image = imagePause;
                btnBackRightPlay.Refresh();
                btnBackPlay.Image = imagePause;
                btnBackPlay.Refresh();
                

                notifyFrontLeftImageSensor();
                notifyFrontRightImageSensor();
                notifyFrontImageSensor();
                notifyBackLeftImageSensor();
                notifyBackRightImageSensor();
                notifyBackImageSensor();
            }
            else
            {
                btnCenterPlay.Image = imagePlay;
                btnCenterPlay.Refresh();

                btnFrontLeftPlay.Image = imagePlay;
                btnFrontLeftPlay.Refresh();
                btnFrontRightPlay.Image = imagePlay;
                btnFrontRightPlay.Refresh();
                btnFrontPlay.Image = imagePlay;
                btnFrontPlay.Refresh();
                btnBackLeftPlay.Image = imagePlay;
                btnBackLeftPlay.Refresh();
                btnBackRightPlay.Image = imagePlay;
                btnBackRightPlay.Refresh();
                btnBackPlay.Image = imagePlay;
                btnBackPlay.Refresh();

                _cancelTokenFrontLeft.Cancel();
                _cancelTokenFrontRight.Cancel();
                _cancelTokenFront.Cancel();
                _cancelTokenBackLeft.Cancel();
                _cancelTokenBackRight.Cancel();
                _cancelTokenBack.Cancel();
            }

            /*
            btnFrontLeftPlay_Click(sender, e);
            btnFrontRightPlay_Click(sender, e);
            btnFrontPlay_Click(sender, e);
            btnBackLeftPlay_Click(sender, e);
            btnBackRightPlay_Click(sender, e);
            btnBackPlay_Click(sender, e);*/

        }

        private async void notifyFrontLeftImageSensor()
        {
            _cancelTokenFrontLeft.Cancel();
            var token = new CancellationTokenSource();
            _cancelTokenFrontLeft = token;

            while (!token.Token.IsCancellationRequested)
            {
                this.frontLeftImageSensor.notify();
                await Task.Delay(100);
            }

        }

        private async void notifyFrontRightImageSensor()
        {
            _cancelTokenFrontRight.Cancel();
            var token = new CancellationTokenSource();
            _cancelTokenFrontRight = token;

            while (!token.Token.IsCancellationRequested)
            {
                this.frontRightImageSensor.notify();
                await Task.Delay(100);
            }

        }

        private async void notifyFrontImageSensor()
        {
            _cancelTokenFront.Cancel();
            var token = new CancellationTokenSource();
            _cancelTokenFront = token;

            while (!token.Token.IsCancellationRequested)
            {
                this.frontImageSensor.notify();
                await Task.Delay(100);
            }

        }

        private async void notifyBackLeftImageSensor()
        {
            _cancelTokenBackLeft.Cancel();
            var token = new CancellationTokenSource();
            _cancelTokenBackLeft = token;

            while (!token.Token.IsCancellationRequested)
            {
                this.backLeftImageSensor.notify();
                await Task.Delay(100);
            }

        }

        private async void notifyBackRightImageSensor()
        {
            _cancelTokenBackRight.Cancel();
            var token = new CancellationTokenSource();
            _cancelTokenBackRight = token;

            while (!token.Token.IsCancellationRequested)
            {
                this.backRightImageSensor.notify();
                await Task.Delay(100);
            }

        }

        private async void notifyBackImageSensor()
        {
            _cancelTokenBack.Cancel();
            var token = new CancellationTokenSource();
            _cancelTokenBack = token;

            while (!token.Token.IsCancellationRequested)
            {
                this.backImageSensor.notify();
                await Task.Delay(100);
            }

        }
    }

    
}
