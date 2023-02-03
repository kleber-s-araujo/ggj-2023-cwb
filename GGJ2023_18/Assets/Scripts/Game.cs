using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject Enemy;
    private float timeToSpawn;
    private float count;
    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = Random.Range(1, 10);
        count = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        count += 1 * Time.deltaTime;

        if (count >= timeToSpawn)
        {
            float randAux = Random.Range(-49, 49);

            float y = 7;
            float z = 49;

            Instantiate(Enemy.transform, new Vector3(randAux, y, z), Enemy.transform.rotation);

            count = 0;
            timeToSpawn = Random.Range(1, 10);
        }

        


    }
}
