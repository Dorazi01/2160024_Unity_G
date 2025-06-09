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

    int highScoreValue = 0; // 하이스코어 값

    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
        this.generator = GameObject.Find("ItemGenerator");
        this.comboText = GameObject.Find("Combo");
        this.comboTimerBar = GameObject.Find("ComboTimerUi").GetComponent<Scrollbar>();
        this.multicomboText = GameObject.Find("MultiComboStack");
        this.gameoverText = GameObject.Find("GameOverText");
        gameoverText.SetActive(false); // 게임 오버 텍스트 비활성화
        this.highScore = GameObject.Find("HighScore");
        highScore.SetActive(false);
        this.gameOverButton = GameObject.Find("GameOverButton");
        gameOverButton.SetActive(false); // 게임 오버 버튼 비활성화
    }

    void Update()
    {
        if (highScoreValue < point)
        {
            highScoreValue = point; // 새로운 하이스코어 갱신
        }

        this.time -= Time.deltaTime;

        if (combo > 0)
        {
            comboTimer -= Time.deltaTime;
            if (comboTimer <= 0)
            {
                combo = 0; // 콤보 시간 초과 시 초기화
            }
        }
        
        if (combo >= 45)
        {
            multiPoint = 3; // 멀티포인트 증가
        }
        else if (combo >= 25)
        {
            multiPoint = 2; // 멀티포인트 증가
        }
        else
        {
            multiPoint = 1; // 멀티포인트 초기화
        }





        if (this.time < 0)
        {
            this.time = 0;
            this.generator.GetComponent<ItemGenerator>().SetParameter(10000.0f, 0);
            this.highScore.GetComponent<TextMeshProUGUI>().text = "Your High Score : " + highScoreValue.ToString(); // 하이스코어 텍스트 업데이트
            gameoverText.SetActive(true); // 게임 오버 텍스트 활성화
            highScore.SetActive(true); // 하이스코어 텍스트 활성화
            gameOverButton.SetActive(true); // 게임 오버 버튼 활성화
                                          //게임오버시 환경설정
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
            Time.timeScale = 0.5f; // 게임 전체 속도 절반
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
    // GameDirector.cs에 메서드 추가
    public void GetClock()
    {
        slowTime = 1.5f; // 3초간 슬로우
    }


    //사과 연속 획득시 콤보 추가
    public void GetApple()
    {
        appleLevel++;
        this.point += 100;
        combo++;
        comboTimer = 3.0f; // 3초 내 연속 사과 시 콤보 유지
        comboTimerMax = 3.0f;
        if (combo > 1)
        {
            this.point += (combo * 10) * multiPoint; // 콤보 보너스
        }
        if (combo >= 7)
        {
            this.time += 3.0f;
        }
    }

    
    //폭탄 획득시 콤보 초기화 및 점수 감소
    public void GetBomb()
    {
        this.point /= 2;
        combo = 0; // 폭탄 맞으면 콤보 초기화
        time -= 10.0f; // 폭탄 맞으면 시간 감소    
    }

    public void GetGoldenApple()
    {
        appleLevel++;
        this.point += 500; // 골든 애플 점수
                           // 필요하다면 이펙트나 사운드 추가
        combo++;
        comboTimer = 3.0f; // 3초 내 연속 사과 시 콤보 유지
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
