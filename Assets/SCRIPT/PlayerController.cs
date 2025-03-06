using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerMovement PlayerMovement;
    TimeStopAbility TimeStopAbility;

    public bool isleft = false, isright = false;

    void Start()
    {
        PlayerMovement = FindObjectOfType<PlayerMovement>();
        TimeStopAbility = FindObjectOfType<TimeStopAbility>();
    }

    public void Left_Down()
    {
        isleft = true;
    }
    public void Left_Up()
    {
        isleft = false;
    }

    public void Right_Down()
    {
        isright = true;
    }
    public void Right_Up()
    {
        isright = false;
    }

    void Update()
    {
        if (isleft)
        {
            PlayerMovement.Left_Movement();
        }

        if (isright)
        {
            PlayerMovement.Right_Movement();
        }
    }
}
