using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class AndroidJoystick : MonoBehaviour
{

    public FixedJoystick MoveJoyStick;
    public FixedJoystick CameraJoyStick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var fps = GetComponent<FirstPersonController>();
        //fps.RunAxis = MoveJoyStick.Direction;
        //fps.LookAxis = CameraJoyStick.Direction;
    }
}
