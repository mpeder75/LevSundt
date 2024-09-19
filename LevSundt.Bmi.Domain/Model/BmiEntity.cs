﻿namespace LevSundt.Bmi.Domain.Model;

public class BmiEntity
{
    public BmiEntity(double height, double weight)
    {
        // Check pre-conditions
        Height = height;
        Weight = weight;

        if (!IsValid()) throw new ArgumentException("Pre-conditions er ikke overholdt");

        CalculateBmi();
    }

    /// <summary>
    ///     Vi er IKKE interesseret i at man kan ændre i vores model, derfor er set private
    /// </summary>
    public double Height { get; }
    public double Weight { get; }
    public double Bmi { get; private set; }


    /// <summary>
    ///     Acceptabel højde er (100; 250)
    ///     Acceptabel vægt er (40,0; 250,0)
    /// </summary>
    protected bool IsValid()
    {
        // Break fast princip
        if (Height < 100) return false;
        if (Height > 250) return false;
        if (Weight < 40.0) return false;
        if (Weight > 250.0) return false;

        return true;
    }

    protected void CalculateBmi()
    {
        Bmi = Weight / (Height/100 * Height/100);
    }
}


