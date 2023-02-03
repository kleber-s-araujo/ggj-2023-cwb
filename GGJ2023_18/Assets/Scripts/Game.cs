using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject Enemy;
    private float timeToSpawn;
    private float count;
    private float countLevel;
    public float level;
    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = Random.Range(1, 20);
        count = countLevel = 0f;
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        count += 1 * Time.deltaTime;
        countLevel += 1 * Time.deltaTime;

        if (count >= timeToSpawn)
        {
            float randAux = Random.Range(-49, 49);

            float y = 7;
            float z = 49;

            Instantiate(Enemy.transform, new Vector3(randAux, y, z), Enemy.transform.rotation);

            count = 0;
            //regra maluca pra gerar cada vez mais rapido os inimigos...
            timeToSpawn = Random.Range(1f, 20f - level*0.1f);
        }

        //Passa o nivel
        if (countLevel >= 60 )
        {
            level++;
            countLevel = 0;
        }

        


    }
}
