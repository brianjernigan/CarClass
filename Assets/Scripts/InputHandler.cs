//////////////////////////////////////////////
//Assignment/Lab/Project: Car Class
//Name: Brian Jernigan
//Section: SGD.213.2172
//Instructor: Brian Sowers
//Date: 02/19/2024
/////////////////////////////////////////////

using UnityEngine;
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
        if (!UserInputIsValidated())
        {
            _gameText.text = "Invalid Input. Please enter a Year between 1886 and 2024, and a non-empty Make.";
            return;
        }

        var carYear = int.Parse(_yearInput.text);
        var carMake = _makeInput.text;

        _newCar = new Car(carYear, carMake);
        UpdateGameText();
    }

    private bool UserInputIsValidated()
    {
        return YearInputIsValidated() && MakeInputIsValidated();
    }

    // Ensure make has a non-empty value
    private bool MakeInputIsValidated()
    {
        var makeInputString = _makeInput.text;
        // Return true if string is not null or whitespace
        return !string.IsNullOrWhiteSpace(makeInputString);
    }

    // Ensure year is not less than 1886 or greater than current year
    private bool YearInputIsValidated()
    {
        // TMP Input Field already handles integer input so we know this can be parsed
        var yearInputInt = int.Parse(_yearInput.text);
        // C# patterns!!
        return yearInputInt is >= 1886 and <= 2024;
    }

    // Sets on-screen text to car's current status
    private void UpdateGameText()
    {
        _gameText.text = $"The {_newCar.Year} {_newCar.Make} is currently going {_newCar.CurrentSpeed} mph.";
    }
}
