using UnityEngine;

public class Rotator : MonoBehaviour
{
    int rand;

    void Start()
    {
        rand = Random.Range(30, 50);
    }

    void Update()
    {
        transform.Rotate(new Vector3(15, 30, rand) * Time.deltaTime);        
    }
}
