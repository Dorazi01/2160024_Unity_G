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

    int normalDropCount = 0; // �Ϲ� ������ ��� ī��Ʈ
    int specialDropInterval = 0; // ���� Ư�� �����۱��� ���� ��� Ƚ��

    void Start()
    {
        // 6~7 ������ ���������� ù Ư�� ������ ���� ���� ����
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

            // Ư�� ������ ��� Ÿ�̹�
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
                specialDropInterval = Random.Range(10,13); // ���� Ư�� �����۱��� ���� �缳��
            }
            else
            {
                // �Ϲ� ������ ��� Ǯ: ��� 60%, ��ź 40%
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