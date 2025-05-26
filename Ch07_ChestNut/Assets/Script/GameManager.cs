using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject tutorialWall1;
    public GameObject tutorialWall2;

    public GameObject finalScoreText;
    public GameObject retryButton;
    public GameObject mainMenuButton;

    public int throwChestNutNum = 0;

    public int score = 0;
    public bool isShoot = false;
    public bool isHit = false;

    public bool isLive = true;


    int maxHealth = 3;
    int culHealth = 0;

    float curPower = 0f;
    float maxPower = 3f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {

    }

    void Update()
    {

        if (throwChestNutNum == 0)
        {
            Invoke("GameOver", 3f);
        }
    }

    void GameOver()
    {
        isLive = false;
        finalScoreText.SetActive(true);
        retryButton.SetActive(true);
        mainMenuButton.SetActive(true);
    }
    public void EnableWall1()
    {
        tutorialWall1.SetActive(true);
    }

    public void EnableWall2()
    {
        tutorialWall2.SetActive(true);
    }

    public void DisableWall1()
    {
        tutorialWall1.SetActive(false);
    }

    public void DisableWall2()
    {
        tutorialWall2.SetActive(false);
    }

    public void RetryFun()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenuFun()
    {
        SceneManager.LoadScene("LevelScene");
    }

}
