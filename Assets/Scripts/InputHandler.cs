using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField _yearInput;
    [SerializeField] private TMP_InputField _makeInput;

    private Car newCar;

    private void Start()
    {
        newCar = new Car(1922, "Mustang");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            newCar.Accelerate(10);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            newCar.Decelerate(10);
        }

        Debug.Log(newCar);
    }
}
