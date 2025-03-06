using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    [SerializeField] TextMeshProUGUI ScoreText;

    void Start()
    {
        score=0;
    }
    void Update()
    {
        ScoreText.text = score.ToString();
    }
}
