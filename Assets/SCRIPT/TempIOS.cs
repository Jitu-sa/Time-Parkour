using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempIOS : MonoBehaviour
{
    PlayerMovement PlayerMovement;
    TimeStopAbility TimeStopAbility;

    void Start()
    {
        PlayerMovement = FindObjectOfType<PlayerMovement>();
        TimeStopAbility = FindObjectOfType<TimeStopAbility>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            PlayerMovement.Left_Movement();
        }

        if (Input.GetKey(KeyCode.D))
        {
            PlayerMovement.Right_Movement();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            PlayerMovement.Jump();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            TimeStopAbility.Time_stop_ability();
        }
    }
}
