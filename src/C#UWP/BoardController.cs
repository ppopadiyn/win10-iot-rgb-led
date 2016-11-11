using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using Windows.System.Threading;

namespace BlinkRGBLed
{
    public sealed class BoardController
    {
        private PinController redPin_;
        private PinController bluePin_;
        private PinController greenPin_;
        private PinController next_;

        public void Start()
        {
            redPin_ = new PinController(5, "Red");
            greenPin_ = new PinController(13, "Green");
            bluePin_ = new PinController(6, "Blue");
            next_ = redPin_;

            ThreadPoolTimer.CreatePeriodicTimer(Timer_Tick, TimeSpan.FromMilliseconds(500));
        }

        private void Timer_Tick(ThreadPoolTimer timer)
        {
            if (next_ == redPin_)
            {
                redPin_.Value = GpioPinValue.High;
                bluePin_.Value = GpioPinValue.Low;
                greenPin_.Value = GpioPinValue.Low;
                next_ = greenPin_;
            }
            else if (next_ == greenPin_)
            {
                redPin_.Value = GpioPinValue.Low;
                bluePin_.Value = GpioPinValue.High;
                greenPin_.Value = GpioPinValue.Low;
                next_ = bluePin_;
            }
            else
            {
                redPin_.Value = GpioPinValue.Low;
                bluePin_.Value = GpioPinValue.Low;
                greenPin_.Value = GpioPinValue.High;
                next_ = redPin_;
            }
        }
    }
}
