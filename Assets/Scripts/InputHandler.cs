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
        _newCar = new Car(1999, "Mustang");
        UpdateGameText();
    }

    private void UpdateGameText()
    {
        _gameText.text = _newCar.ToString();
    }
}
