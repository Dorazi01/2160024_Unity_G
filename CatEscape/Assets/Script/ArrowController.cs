using UnityEngine;

public class ArrowController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameObject player;
    


    void Start()
    {
        this.player = GameObject.Find("player");
        //gPlayer = GetObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,-0.1f*(GameDirector.Instance.GameLevel+2),0);



        
        if (transform.position.y < -5.0f)
        {
            Destroy(this.gameObject);
        }
        
        Vector2 p1 = transform.position;
        Vector2 p2 = this.player.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;
        float r2 = 1.0f;

        if (d < r1 + r2)
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();

            Destroy(this.gameObject);
        }
        else if (GameDirector.Instance._isDead == true)
        {
            Destroy(this.gameObject);
        }

        



    }
}
