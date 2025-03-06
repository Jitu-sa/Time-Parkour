using System.Collections;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] GameObject ingameui;
    [SerializeField] GameObject inputsystem;
    [SerializeField] GameObject levelcomplete;
    [SerializeField] GameObject player;
    [SerializeField] float teleportDuration = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ingameui.SetActive(false);
            inputsystem.SetActive(false);
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            StartCoroutine(TeleportPlayer());
        }
    }

    private IEnumerator TeleportPlayer()
    {
        Vector3 startPosition = player.transform.position;
        Vector3 endPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < teleportDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / teleportDuration;
            player.transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }

        player.transform.position = endPosition;
        levelcomplete.SetActive(true);
    }
}
