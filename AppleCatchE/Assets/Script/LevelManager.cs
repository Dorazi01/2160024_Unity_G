using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // �ߺ� ����
        }
    }


    public void LoadTitleScene()
    {
        SceneManager.LoadScene(0); // Ÿ��Ʋ �� �̸��� �°� ����
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1); // ���� �� �̸��� �°� ����
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
