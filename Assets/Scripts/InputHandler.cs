using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField _yearInput;
    [SerializeField] private TMP_InputField _makeInput;

    [SerializeField] private TMP_Text _gameText;

    private Car _newCar;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            _newCar.Accelerate(1);
            UpdateGameText();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _newCar.Decelerate(1);
            UpdateGameText();
        }
    }

    public void OnClickDriveButton()
    {
        if (!UserInputIsValidated())
        {
            _gameText.text = "Invalid Input. Please enter a Year between 1886 and 2024, and a non-empty Make.";
            return;
        }

        _newCar = new Car(int.Parse(_yearInput.text), _makeInput.text);
        UpdateGameText();
    }

    private bool UserInputIsValidated()
    {
        if (!YearInputIsValidated() || !MakeInputIsValidated()) return false;

        return true;
    }

    private bool MakeInputIsValidated()
    {
        var makeInputString = _makeInput.text;
        if (string.IsNullOrWhiteSpace(makeInputString)) return false;

        return true;
    }

    private bool YearInputIsValidated()
    {
        var yearInputInt = int.Parse(_yearInput.text);
        if (yearInputInt < 1886 || yearInputInt > 2024) return false;

        return true;
    }

    private void UpdateGameText()
    {
        _gameText.text = _newCar.ToString();
    }
}
