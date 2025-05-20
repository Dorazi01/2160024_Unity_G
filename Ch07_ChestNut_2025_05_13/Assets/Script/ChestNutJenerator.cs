using JetBrains.Annotations;
using UnityEngine;

public class ChestNutJenerator : MonoBehaviour
{

    public GameObject bamsongiPrefab;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bamsongi = Instantiate(bamsongiPrefab);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;
            

            bamsongi.GetComponent<ChestNutBehavior>().Shoot(worldDir.normalized * 2000);
        }
    }
}
