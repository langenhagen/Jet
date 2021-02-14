using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

public static class Util
{

    /// <summary>
    /// Interpolates (adds a delta) to the current value within the given range.
    /// </summary>
    /// <param name="delta">The delta.</param>
    /// <param name="currentValue">The current value.</param>
    /// <param name="targetValue">The target value, should lie within the min/max range.</param>
    /// <param name="minValue">The minimum value.</param>
    /// <param name="maxValue">The maximum value.</param>
    /// <returns>The interpolated value.</returns>
    public static float Interpolate(float delta, float currentValue, float targetValue, float minValue, float maxValue)
    {
        if (currentValue != targetValue)
        {
            if (targetValue > currentValue && maxValue > currentValue)
            {
                if (delta < targetValue - currentValue)
                    currentValue += delta;
                else
                    currentValue = targetValue;
            }
            else if (targetValue < currentValue && minValue < currentValue)
            {
                if (delta < currentValue - targetValue)
                    currentValue -= delta;
                else
                    currentValue = targetValue;
            }

        }

        return currentValue;
    }


    /// <summary>
    /// Given a DateTime object, generates a string of format YYYY-MM-DD hh:mm:ss.
    /// </summary>
    /// <param name="dateTime">A DateTime object.</param>
    /// <returns>A string of format YYYY-MM-DD hh:mm:ss.</returns>
    public static string ToSQLiteString(this DateTime dateTime)
    {
        string month = (dateTime.Month < 10 ? "0" : "") + dateTime.Month;
        string day = (dateTime.Day < 10 ? "0" : "") + dateTime.Day;
        string hour = (dateTime.Hour < 10 ? "0" : "") + dateTime.Hour;
        string minute = (dateTime.Minute < 10 ? "0" : "") + dateTime.Minute;
        string second = (dateTime.Second < 10 ? "0" : "") + dateTime.Second;

        return dateTime.Year + "-" + month + "-" + day + " " + hour + ":" + minute + ":" + second;
    }

}