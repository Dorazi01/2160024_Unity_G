using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class Level : MonoBehaviour

{
    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelScene");
    }

    public void GameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GameClear()
    {
        SceneManager.LoadScene("ClearScene");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("OverScene");
    }

   

}