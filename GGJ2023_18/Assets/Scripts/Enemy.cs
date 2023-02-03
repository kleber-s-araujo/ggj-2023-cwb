using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Variables
    public float health;
    public float pointsToGive;
    public float movementSpeed;
    public float damage;

    private GameObject tree;
    private GameObject player;


    //Methods

    public void Start()
    {
        tree = GameObject.FindWithTag("Tree");
        player = GameObject.FindWithTag("Player");
    }
    public void Update()
    {
        if(health <= 0)
        {
            Die();
        }

        this.transform.LookAt(tree.transform);
        this.transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }

    public void Die()
    {
        print("Enemy " + this.gameObject.name + " has died");
        Destroy(this.gameObject);

        player.GetComponent<Player>().points += pointsToGive;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tree")
        {
            tree.GetComponent<Tree>().health -= damage;
            Destroy(this.gameObject);
        }

        if (other.tag == "Player")
        {
            player.GetComponent<Player>().health -= damage;
            Destroy(this.gameObject);
        }

    }
}
