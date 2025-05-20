using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;

    float maxGameTime = 30f;
    float curGameTime = 0f;

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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    


    
}
