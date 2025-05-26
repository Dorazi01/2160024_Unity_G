using UnityEngine;

public class WallMove : MonoBehaviour
{
    public float speed = 1.0f;  // 벽이 움직이는 속도

    private int direction = 1;  // 1이면 오른쪽 -1이면 왼쪽



    void Update()
    {
        //게임 태그가 움직이는 벽만 움직이게 설정
        if (this.gameObject.tag == "MovingWall")
        {
            Move();
        }

        if (transform.position.y > 20f)
        {
            speed = 1.0f;
        }
        else if (transform.position.y > 40f)
        {
            speed = 50.0f;
        }


    }


    void Move()
    {
        {
            // 벽 움직임
            transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

            // 일정 범위를 넘어가면 방향전환
            if (transform.position.x >= 2)
            {
                direction = -1;

            }
            else if (transform.position.x <= -2)
            {
                direction = 1;

            }

            if (transform.position.y >= 9)
            {
                direction = -1;

            }
            else if (transform.position.y <= 5)
            {
                direction = 1;

            }
        }
    }



}

