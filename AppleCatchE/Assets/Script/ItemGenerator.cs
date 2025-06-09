using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEditor.Progress;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;
    public GameObject clockPrefab;
    public GameObject goldenApplePrefab;

    float span = 1.0f;
    float delta = 0;
    float speed = -0.03f;

    int normalDropCount = 0; // 일반 아이템 드랍 카운트
    int specialDropInterval = 0; // 다음 특별 아이템까지 남은 드랍 횟수

    void Start()
    {
        // 6~7 사이의 랜덤값으로 첫 특별 아이템 등장 간격 설정
        specialDropInterval = Random.Range(6, 8);
    }

    public void SetParameter(float span, float speed)
    {
        this.span = span;
        this.speed = speed;
    }

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject item = null;

            // 특별 아이템 드랍 타이밍
            if (normalDropCount >= specialDropInterval)
            {
                if (Random.value < 0.5f)
                {
                    item = Instantiate(goldenApplePrefab);
                    
                }
                else
                {
                    item = Instantiate(clockPrefab);
                    
                }
                normalDropCount = 0;
                specialDropInterval = Random.Range(10,13); // 다음 특별 아이템까지 간격 재설정
            }
            else
            {
                // 일반 아이템 드랍 풀: 사과 60%, 폭탄 40%
                int dice = Random.Range(1, 101); // 1~100
                if (dice <= 60)
                    item = Instantiate(applePrefab);
                else
                    item = Instantiate(bombPrefab);

                normalDropCount++;
            }

            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);
            item.GetComponent<ItemController>().dropSpeed = this.speed;
        }
    }
}