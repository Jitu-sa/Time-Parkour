using UnityEngine;

public class FreezableObject : MonoBehaviour
{
    Animator anim;
    float savedAnimSpeed = 1f;
    bool isFrozen = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        if (anim != null)
        {
            savedAnimSpeed = anim.speed;
        }
    }

    public void Freeze()
    {
        if (isFrozen || anim == null) return;

        isFrozen = true;
        savedAnimSpeed = anim.speed; // Save current speed
        anim.speed = 0f; // Stop animation
    }

    public void Unfreeze()
    {
        if (!isFrozen || anim == null) return;

        isFrozen = false;
        anim.speed = savedAnimSpeed; // Restore animation speed
    }
}
