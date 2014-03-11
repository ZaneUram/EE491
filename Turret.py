#14 21 22 used PWM pins


import Adafruit_BBIO.PWM as PWMT
import time


PWMR.start("P9_22", 5, 50)
time.sleep(1)
dutyT = 5
frequencyT = 50


while frequency > 0:

	while T1 == 1 | T2 == 1
		while T1 == 1 & T2 == 0
			dutyT += 0.25
		while T1 == 0 & T2 == 1
			dutyT -=  0.25
	PWM.set_duty_cycle("P9_22", dutyT)
	PWM.set_frequency("P9_22", frequencyT)
	print("    Turret Running")
	time.sleep(.5)
