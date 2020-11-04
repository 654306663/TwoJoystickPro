using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameJoysticks : MonoBehaviour
{
    [SerializeField] private JoystickComponentCtrl leftJoystick;
    [SerializeField] private JoystickComponentCtrl rightJoystick;
    [SerializeField] private Text leftJoystickText;
    [SerializeField] private Text rightJoystickText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        leftJoystickText.text = "Left Joystick: " + new Vector2(leftJoystick.Horizontal, leftJoystick.Vertical).ToString();
        rightJoystickText.text = "Right Joystick: " + new Vector2(rightJoystick.Horizontal, rightJoystick.Vertical).ToString();
    }
}
