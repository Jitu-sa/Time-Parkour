using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject CoinTarget;
    public float moveSpeed = 5f; // Speed of movement
    public Vector3 offset = new Vector3(0, 50, 0); // Small upset (adjust as needed)
    Collider2D Collider;

    void Start()
    {
        CoinTarget = GameObject.FindGameObjectWithTag("CoinTarget");
        Collider=GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collider.enabled = false;
            StartCoroutine(MoveToUI());
        }
    }

    IEnumerator MoveToUI()
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = CoinTarget.transform.position + offset; // Add offset to target position

        float duration = 0.5f; // Time to reach UI
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition; // Ensure final position is correct
        ScoreManager.score++;
        Destroy(gameObject); // Remove coin after reaching UI
    }
}
