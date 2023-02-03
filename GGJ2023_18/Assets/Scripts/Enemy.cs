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
    private GameObject game;

    private float multiLevel;

    //Methods

    public void Start()
    {
        tree = GameObject.FindWithTag("Tree");
        player = GameObject.FindWithTag("Player");
        game = GameObject.FindWithTag("GameController");
    }
    public void Update()
    {
        if(health <= 0)
        {
            Die();
        }

        //outra formula maluca pra ficar mais rapido por level
        
        float movementSpeedLevel = movementSpeed + game.GetComponent<Game>().level / 100;

        print(movementSpeedLevel);

        this.transform.LookAt(tree.transform);
        this.transform.Translate(Vector3.forward * movementSpeedLevel * Time.deltaTime);
    }

    public void Die()
    {
        print("Enemy " + this.gameObject.name + " has died");
        Destroy(this.gameObject);

        player.GetComponent<Player>().points += pointsToGive;
    }

    public void OnTriggerEnter(Collider other)
    {

        float damageLevel = damage + game.GetComponent<Game>().level / 100;
        

        if (other.tag == "Tree")
        {
            tree.GetComponent<Tree>().health -= damageLevel;
            Destroy(this.gameObject);
        }

        if (other.tag == "Player")
        {
            player.GetComponent<Player>().health -= damageLevel;
            Destroy(this.gameObject);
        }

    }
}
