using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float dropSpeed = -0.03f;

    void Update()
    {

        if (gameObject.CompareTag("Clock"))
        {
            transform.Rotate(0, 180 * Time.deltaTime, 0); // 초당 180도 회전 (원하는 속도로 조절)
        }


        transform.Translate(0, this.dropSpeed, 0);
        if (transform.position.y < -1.0f)
        {
            Destroy(gameObject);
        }
    }





}

