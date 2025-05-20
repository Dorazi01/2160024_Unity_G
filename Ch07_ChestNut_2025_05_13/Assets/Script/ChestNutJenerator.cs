using JetBrains.Annotations;
using UnityEngine;

public class ChestNutJenerator : MonoBehaviour
{

    public GameObject bamsongiPrefab;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Camera cam = Camera.main;
            Vector3 spawnPos = cam.transform.position + cam.transform.forward * 1.0f; // 카메라 앞 1만큼

            GameObject bamsongi = Instantiate(bamsongiPrefab, spawnPos, Quaternion.identity);

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;

            bamsongi.GetComponent<ChestNutBehavior>().Shoot(worldDir.normalized * 2000);
        }

    }
    
}
