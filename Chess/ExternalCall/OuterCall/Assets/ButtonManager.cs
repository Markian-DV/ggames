using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void ButtonPressed() 
    {
        Application.ExternalCall("ButtonPressed", "You`have pressed the button :]");
    }
}
