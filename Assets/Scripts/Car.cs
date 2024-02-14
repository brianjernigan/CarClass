using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car
{
    private int _year;
    private string _make;
    private const int MaxSpeed = 100;
    private int _currentSpeed;

    public int Year
    {
        get => _year;
        set => _year = value;
    }

    public string Make
    {
        get => _make;
        set => _make = value;
    }

    public Car(int year, string make)
    {
        _year = year;
        _make = make;
        _currentSpeed = 0;
    }

    public void Accelerate (int gain)
    {
        if (_currentSpeed + gain <= MaxSpeed)
        {
            _currentSpeed += gain;
        }
    }

    public void Decelerate (int loss)
    {
        if (_currentSpeed - loss >= 0)
        {
            _currentSpeed -= loss;
        }
    }

    public override string ToString()
    {
        return $"The {_year} {_make} is currently going {_currentSpeed} mph.";
    }
}
