using UnityEngine;

public class RemoveChestNut : MonoBehaviour
{
    SphereCollider Sc;

    void Start()
    {
        Sc = GetComponent<SphereCollider>();
    }

    void Update()
    {
       
    }


     private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor") //충돌한 오브젝트가 바닥일 경우
        {
            Destroy(gameObject,1); //밤송이를 삭제
        }

        if (collision.gameObject.tag == "MovingWall") //충돌한 오브젝트가 바닥일 경우
        {
            
            Sc.enabled = false;
        }
    }
        

    }
   

