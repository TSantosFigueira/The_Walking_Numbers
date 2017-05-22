using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Operation
{
    plus = 1,
    minus = 2,
    division = 3,
    multiplication = 4
}

public class MathOperationsManager : MonoBehaviour
{
    public Text operationText;

    [HideInInspector]
    public int answer;
    [HideInInspector]
    public int firstNumber;
    [HideInInspector]
    public int secondNumber;
    [HideInInspector]
    public Operation operation;

    void Start()
    {
        SetNewOperation();
    }

    void SetNewOperation()
    {
        NewOperationValues();
        operation = RandomOperation(Random.Range(1, 4));

        switch (operation)
        {
            case Operation.plus:
                answer = firstNumber + secondNumber;
                operationText.text = firstNumber + " + " + secondNumber;
                break;

            case Operation.minus:
                // Providing negative numbers is not expected
                if (IsDiminishable(firstNumber, secondNumber))
                {
                    answer = firstNumber - secondNumber;
                    operationText.text = firstNumber + " - " + secondNumber;
                }
                else
                {
                    answer = secondNumber - firstNumber;
                    operationText.text = secondNumber + " - " + firstNumber;
                }
                break;

            case Operation.multiplication:
                answer = firstNumber * secondNumber;
                operationText.text = firstNumber + " * " + secondNumber;
                break;

            case Operation.division:
                // Checks if the first one can be divided by the second
                if (IsDivisible(firstNumber, secondNumber))
                {
                    answer = firstNumber / secondNumber;
                    operationText.text = firstNumber + " / " + secondNumber;
                }
                // Checks if the second one can be divided by the first
                else if (IsDivisible(secondNumber, firstNumber))
                {
                    answer = secondNumber / firstNumber;
                    operationText.text = secondNumber + " / " + firstNumber;
                }
                // New operation in case none can divide the other
                else
                    SetNewOperation();
                break;
        }
    }

    //! Checks if the first number minus the second one is not a negative
    bool IsDiminishable(int number1, int number2)
    {
        if (number2 > number1) return false;
        return true;
    }

    //! Sets random values for the first and second numbers
    void NewOperationValues()
    {
        firstNumber = Random.Range(1, 10);
        secondNumber = Random.Range(1, 10);
    }

    /// <summary>
    /// Assures the first number can be divided by the second, returns false if it cannot
    /// </summary>
    /// <param name="number1">Divident number</param>
    /// <param name="number2">Divisor number</param>
    /// <returns>True if number1 can be divided by number2, false otherwise</returns>
    bool IsDivisible(int number1, int number2)
    {
        if (number1 % number2 == 0) return true;
        return false;
    }

    /// <summary>
    /// Converts the input value to one operation defined by the Operation Enum
    /// </summary>
    /// <param name="value">Number that corresponds directly to one Operations Enum values</param>
    /// <returns>Returns a random operation based on input number</returns>
    Operation RandomOperation(int value)
    {
        switch (value)
        {
            case 1: return Operation.plus;
            case 2: return Operation.minus;
            case 3: return Operation.division;
            default: return Operation.multiplication;
        }
    }
}
