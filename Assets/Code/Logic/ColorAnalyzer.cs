using System;
using System.Linq;
using UnityEngine;

namespace Code.Logic
{
    public class ColorAnalyzer
    {   
        public float CalculateDifference(Color a, Color b)
        {
            float[] TargetRGB = {a.r, a.g, a.b};
            float[] CurrentRGB = {b.r, b.g, b.b};
            float TargetProcent = TargetRGB.Sum()/3*100;
            float CurrentProcent = CurrentRGB.Sum()/3*100;
            return Math.Abs(TargetProcent - CurrentProcent);
        }
    }
}