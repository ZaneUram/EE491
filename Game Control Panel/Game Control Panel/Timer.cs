﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Control_Panel
{
    class Timer
    {
        private int hours = 0; //hours remaining
        private int minutes = 0; //minutes remaining
        private int seconds = 0; //seconds remaining
        private int milliseconds = 0; //milliseconds remaining
        public string getHours() //outputs the two digit string format for the hours column
        {
            if (hours > 9)
            {
                return hours.ToString();
            }
            else
            {
                return "0" + hours.ToString();
            }
        }
        public string getMinutes() //outputs the two digit string format for the minutes column
        {
            if (minutes > 9)
            {
                return minutes.ToString();
            }
            else
            {
                return "0" + minutes.ToString();
            }
        }
        public void setMinutes(int minutesParameter) //the only way to set the timer is by providing a time in minutes. Valid inputs 0-60
        {
            if (minutesParameter >= 0 && minutesParameter <= 59)
            {
                this.ClearTimer(); //This is the only funciton setting the timer, so the current value will be cleared
                minutes = minutesParameter;
            }
            else
            {
                if (minutesParameter == 60)
                {
                    this.ClearTimer(); //This is the only funciton setting the timer, so the current value will be cleared
                    hours++;
                }
                else
                {
                    //ClearTimer() is not called in this branch because if the value is invalid it will be ignored and keep current values 
                    Console.WriteLine("Minutes value invalid because it is greater than 60");
                }
            }
        }
        public string getSeconds() //outputs the two digit string format for the seconds column
        {
            if (seconds > 9)
            {
                return seconds.ToString();
            }
            else
            {
                return "0" + seconds.ToString();
            }
        }
        public string getMilliseconds() //outputs the two digit string format for the milliseconds column
        {
            if (milliseconds > 9)
            {
                return milliseconds.ToString();
            }
            else
            {
                return "0" + milliseconds.ToString();
            }
        }
        public void ClearTimer()
        {
            hours = 0;
            minutes = 0;
            seconds = 0;
            milliseconds = 0;
        }
        public override string ToString()
        {
            return getHours() + ":" + getMinutes() + ":" + getSeconds() + "." + getMilliseconds();
        }
    }
}