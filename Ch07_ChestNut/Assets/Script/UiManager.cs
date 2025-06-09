using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class UiManager : MonoBehaviour
{
    public enum InfoType { Score, Count, Power, GameOver }
    public InfoType type;

    Text myText;
    Slider mySlider;



    void Awake()
    {

        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Score:

                myText.text = string.Format("Score : {0:F0}", GameManager.instance.score * 10);

                if (!GameManager.instance.isLive)
                {
                    gameObject.SetActive(false);
                }
                break;
            case InfoType.Count:
                myText.text = string.Format("Count : {0:F0}", GameManager.instance.throwChestNutNum);
                if (!GameManager.instance.isLive)
                {
                    gameObject.SetActive(false);
                }

                break;
            case InfoType.Power:

                break;
            case InfoType.GameOver:

                myText.text = string.Format("Final Score : {0:F0}", GameManager.instance.score * 10);

                break;
        }

    }
}
