using System.Collections;
using UnityEngine;

public class TimeStopAbility : MonoBehaviour
{
    [SerializeField] float timeStopDuration = 5f;
    [SerializeField] float cooldownDuration = 30f;
    bool isOnCooldown = false;

    FreezableObject[] freezableObjects;

    void Start()
    {
        freezableObjects = FindObjectsOfType<FreezableObject>();
    }

    public void Time_stop_ability()
    {
        if (!isOnCooldown)
        {
            StartCoroutine(ActivateTimeStop());
        }
    }

    IEnumerator ActivateTimeStop()
    {
        isOnCooldown = true;

        // Pause all animated objects
        foreach (var obj in freezableObjects)
        {
            obj.Freeze();
        }

        yield return new WaitForSeconds(timeStopDuration);

        // Resume all animations
        foreach (var obj in freezableObjects)
        {
            obj.Unfreeze();
        }

        yield return new WaitForSeconds(cooldownDuration);
        isOnCooldown = false;
    }
}
