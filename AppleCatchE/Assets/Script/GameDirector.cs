using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Mono.Cecil.Cil;
using UnityEngine.SceneManagement;
public class GameDirector : MonoBehaviour
{
    GameObject generator;


    GameObject timerText;
    Scrollbar comboTimerBar;


    GameObject pointText;
    GameObject comboText;
    GameObject multicomboText;
    GameObject highScore;


    GameObject gameoverText;
    GameObject gameOverButton;


    public int appleLevel = 0;
    float time = 60.0f;
    int point = 0;
    

    public int combo = 0;
    float comboTimer = 0f;

    float slowTime = 0f;
    float originalTimeScale = 1f;

    public int multiPoint = 1;

    float comboTimerMax = 3.0f;

    int highScoreValue = 0; // ���̽��ھ� ��

    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
        this.generator = GameObject.Find("ItemGenerator");
        this.comboText = GameObject.Find("Combo");
        this.comboTimerBar = GameObject.Find("ComboTimerUi").GetComponent<Scrollbar>();
        this.multicomboText = GameObject.Find("MultiComboStack");
        this.gameoverText = GameObject.Find("GameOverText");
        gameoverText.SetActive(false); // ���� ���� �ؽ�Ʈ ��Ȱ��ȭ
        this.highScore = GameObject.Find("HighScore");
        highScore.SetActive(false);
        this.gameOverButton = GameObject.Find("GameOverButton");
        gameOverButton.SetActive(false); // ���� ���� ��ư ��Ȱ��ȭ
    }

    void Update()
    {
        if (highScoreValue < point)
        {
            highScoreValue = point; // ���ο� ���̽��ھ� ����
        }

        this.time -= Time.deltaTime;

        if (combo > 0)
        {
            comboTimer -= Time.deltaTime;
            if (comboTimer <= 0)
            {
                combo = 0; // �޺� �ð� �ʰ� �� �ʱ�ȭ
            }
        }
        
        if (combo >= 45)
        {
            multiPoint = 3; // ��Ƽ����Ʈ ����
        }
        else if (combo >= 25)
        {
            multiPoint = 2; // ��Ƽ����Ʈ ����
        }
        else
        {
            multiPoint = 1; // ��Ƽ����Ʈ �ʱ�ȭ
        }





        if (this.time < 0)
        {
            this.time = 0;
            this.generator.GetComponent<ItemGenerator>().SetParameter(10000.0f, 0);
            this.highScore.GetComponent<TextMeshProUGUI>().text = "Your High Score : " + highScoreValue.ToString(); // ���̽��ھ� �ؽ�Ʈ ������Ʈ
            gameoverText.SetActive(true); // ���� ���� �ؽ�Ʈ Ȱ��ȭ
            highScore.SetActive(true); // ���̽��ھ� �ؽ�Ʈ Ȱ��ȭ
            gameOverButton.SetActive(true); // ���� ���� ��ư Ȱ��ȭ
                                          //���ӿ����� ȯ�漳��
        }
        else if (appleLevel <= 10)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.7f, -0.06f);
        }
        else if (appleLevel <= 20)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.5f, -0.05f);
        }
        else if (appleLevel <= 35)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.4f, -0.05f);
        }
        else 
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.3f, -0.05f);
        }

        this.timerText.GetComponent<TextMeshProUGUI>().text = this.time.ToString("F1");
        this.pointText.GetComponent<TextMeshProUGUI>().text = this.point.ToString() + " point";

        this.comboText.GetComponent<TextMeshProUGUI>().text = "Combo = " +this.combo.ToString();
        this.multicomboText.GetComponent<TextMeshProUGUI>().text = this.multiPoint.ToString() + "X ";

        if (slowTime > 0)
        {
            slowTime -= Time.deltaTime;
            Time.timeScale = 0.5f; // ���� ��ü �ӵ� ����
        }
        else
        {
            Time.timeScale = originalTimeScale;
        }



        if (comboTimerBar != null)
        {
            comboTimerBar.size = Mathf.Clamp01(comboTimer / comboTimerMax);
        }

    }
    // GameDirector.cs�� �޼��� �߰�
    public void GetClock()
    {
        slowTime = 1.5f; // 3�ʰ� ���ο�
    }


    //��� ���� ȹ��� �޺� �߰�
    public void GetApple()
    {
        appleLevel++;
        this.point += 100;
        combo++;
        comboTimer = 3.0f; // 3�� �� ���� ��� �� �޺� ����
        comboTimerMax = 3.0f;
        if (combo > 1)
        {
            this.point += (combo * 10) * multiPoint; // �޺� ���ʽ�
        }
        if (combo >= 7)
        {
            this.time += 3.0f;
        }
    }

    
    //��ź ȹ��� �޺� �ʱ�ȭ �� ���� ����
    public void GetBomb()
    {
        this.point /= 2;
        combo = 0; // ��ź ������ �޺� �ʱ�ȭ
        time -= 10.0f; // ��ź ������ �ð� ����    
    }

    public void GetGoldenApple()
    {
        appleLevel++;
        this.point += 500; // ��� ���� ����
                           // �ʿ��ϴٸ� ����Ʈ�� ���� �߰�
        combo++;
        comboTimer = 3.0f; // 3�� �� ���� ��� �� �޺� ����
        comboTimerMax = 3.0f;
        if (combo > 1)
        {
            this.point += (combo * 10) * multiPoint;
        }
        if (combo >= 7)
        {
            this.time += 5.0f;
        }
    }
    /*
    void GoToTitle()
    {
        LevelManager lm = FindObjectOfType<LevelManager>();
        if (lm != null)
        {
            lm.LoadTitleScene();
        }
    }*/

}
