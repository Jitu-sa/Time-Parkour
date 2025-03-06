using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] string levelname;
    [SerializeField] bool unlocked;

    public void Select_Level()
    {
        if (unlocked)
        {
            SceneManager.LoadScene(levelname);
        }
    }
}
