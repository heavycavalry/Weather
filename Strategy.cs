﻿namespace Weather
{
    interface Strategy
    {
        public string Name();
        public bool IsOk(Weather weather);
    }


}