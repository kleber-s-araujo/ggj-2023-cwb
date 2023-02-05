using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Variables
    public float speed = 20f;
    public float maxDistance;

    private GameObject triggeringEnemy;
    public float damage = 5f;

    //Methods
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        maxDistance += 1 * Time.deltaTime;

        if (maxDistance >= 10)
        {
            Destroy(this.gameObject);
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            triggeringEnemy = other.gameObject;
            triggeringEnemy.GetComponent<Enemy>().health -= damage;
        }

        if(other.tag != "Player")
            Destroy(this.gameObject);
    }
}
