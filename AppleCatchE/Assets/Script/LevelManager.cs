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
            Destroy(gameObject); // 중복 방지
        }
    }


    public void LoadTitleScene()
    {
        SceneManager.LoadScene(0); // 타이틀 씬 이름에 맞게 수정
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1); // 게임 씬 이름에 맞게 수정
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
