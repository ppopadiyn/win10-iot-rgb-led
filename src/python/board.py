import _wingpio as gpio
import time
from pin import PinController

class BoardController(object):

    def __init__(self):
        self._redPin = PinController(5, "Red")
        self._greenPin = PinController(13, "Green")
        self._bluePin = PinController(6, "Blue")
        self._next = "Red"

    def start(self):
        while True:
            if(self._next == "Red"):
                self._redPin.value = gpio.HIGH
                self._bluePin.value = gpio.LOW
                self._greenPin.value = gpio.LOW
                self._next = "Green";
            elif(self._next == "Green"):
                self._redPin.value = gpio.LOW
                self._bluePin.value = gpio.HIGH
                self._greenPin.value = gpio.LOW
                self._next = "Blue";
            else:
                self._redPin.value = gpio.LOW
                self._bluePin.value = gpio.LOW
                self._greenPin.value = gpio.HIGH
                self._next = "Red";

            time.sleep(0.5)


