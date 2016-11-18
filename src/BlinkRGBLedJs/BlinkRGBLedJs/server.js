var uwp = require('uwp');
uwp.projectNamespace('Windows');

class PinController {

    constructor(gpioNumber, name) {
        this.name_ = name;
        this.gpioNumber_ = gpioNumber;
        this.pin_ = Windows.Devices.Gpio.GpioController.getDefault().openPin(gpioNumber);
        this.value = Windows.Devices.Gpio.GpioPinValue.high;
        this.pin_.setDriveMode(Windows.Devices.Gpio.GpioPinDriveMode.output);
    }

    get name() { return this.name_; }

    get gpioNumber() { return this.gpioNumber_; }

    get value() { return this.pin_.read(); }

    set value(value) { this.pin_.write(value); }
}

class BoardController {
    constructor() {
        this.redPin_ = new PinController(5, "Red");
        this.greenPin_ = new PinController(13, "Green");
        this.bluePin_ = new PinController(6, "Blue");
        this.next_ = this.redPin_;
    }

    start() {
        setInterval(() => {
            if (this.next_.name === this.redPin_.name) {
                this.redPin_.value = Windows.Devices.Gpio.GpioPinValue.high;
                this.bluePin_.value = Windows.Devices.Gpio.GpioPinValue.low;
                this.greenPin_.value = Windows.Devices.Gpio.GpioPinValue.low;
                this.next_ = this.greenPin_;
            }
            else if (this.next_.name === this.greenPin_.name) {
                this.redPin_.value = Windows.Devices.Gpio.GpioPinValue.low;
                this.bluePin_.value = Windows.Devices.Gpio.GpioPinValue.high;
                this.greenPin_.value = Windows.Devices.Gpio.GpioPinValue.low;
                this.next_ = this.bluePin_;
            } else {
                this.redPin_.value = Windows.Devices.Gpio.GpioPinValue.low;
                this.bluePin_.value = Windows.Devices.Gpio.GpioPinValue.low;
                this.greenPin_.value = Windows.Devices.Gpio.GpioPinValue.high;
                this.next_ = this.redPin_;
            }
        }, 1000);
    }
}

var board = new BoardController();
board.start();