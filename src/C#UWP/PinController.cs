using Windows.Devices.Gpio;

namespace BlinkRGBLed
{
    public sealed class PinController
    {
        private readonly GpioPin pin_;

        public PinController(int gpio, string name)
        {
            Gpio = gpio;
            Name = name;
            pin_ = GpioController.GetDefault().OpenPin(gpio);
            Value = GpioPinValue.High;
            pin_.SetDriveMode(GpioPinDriveMode.Output);
        }

        public int Gpio { get; }

        public string Name { get; }

        public GpioPinValue Value
        {
            get
            {
                return pin_.Read();
            }
            set
            {
                pin_.Write(value);
            }
        }
    }
}
