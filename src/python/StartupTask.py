from board import BoardController
import _wingpio as gpio

boardController = BoardController()
boardController.start()
gpio.cleanup()