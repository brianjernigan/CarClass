using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        var userInput = ValidateUserInput();
        _newCar = new Car(userInput.year, userInput.make);
        UpdateGameText();
    }

    private (int year, string make) ValidateUserInput()
    {
        return (ValidateYearInput(), ValidateMakeInput());
    }

    private int ValidateYearInput()
    {
        var yearInputInt = int.Parse(_yearInput.text);
        if (yearInputInt < 1886 || yearInputInt > 2024)
        {
            _gameText.text = "Invalid Year";
            return 0;
        } else
        {
            return yearInputInt;
        }
    }

    private string ValidateMakeInput()
    {
        var makeInputString = _makeInput.text;
        if (makeInputString == null)
        {
            _gameText.text = "Invalid Make";
            return null;
        } else
        {
            return makeInputString;
        }
    }

    private void UpdateGameText()
    {
        _gameText.text = _newCar.ToString();
    }
}
