using Unity.VisualScripting;
using UnityEngine;

public class LevelCameraMove : MonoBehaviour
{
    bool isCameraMove = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (GameManager.instance.score % 10 != 0)
        {
            isCameraMove = false;
        }
        CameraLevel();
    }


    void CameraLevel()
    {
        if (GameManager.instance.score == 10 && !isCameraMove)
        {
            transform.Translate(0,0, -7f);
            isCameraMove = true;
        }
        else if (GameManager.instance.score == 20 && !isCameraMove)
        {
            transform.Translate(0, 0, -7f);
            isCameraMove = true;
        }
        else if (GameManager.instance.score == 30 && !isCameraMove)
        {
            transform.Translate(0, 0, -7f);
            isCameraMove = true;
        }
    }
}
