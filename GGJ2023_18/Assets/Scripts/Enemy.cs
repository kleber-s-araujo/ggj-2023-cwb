using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //Variables
    public float maxHealth;
    public float health;
    public int pointsToGive;
    public float movementSpeed;
    public float damage;

    private GameObject tree;
    private GameObject player;
    private GameObject game;

    private bool moveBackwards = false;
    private float countBackwards = 0;

    private float multiLevel;

    public HealthBar healthBar;
    private NavMeshAgent navMeshAgent;
    
    //Methods
    private void Awake()
    {
        //navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void Start()
    {
        tree = GameObject.FindWithTag("Tree");
        player = GameObject.FindWithTag("Player");
        game = GameObject.FindWithTag("GameController");

        health = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        healthBar.setHealth(health);

        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    public void Update()
    {
        if(health <= 0)
        {
            Die();
        }

        navMeshAgent.destination = tree.transform.position;

        healthBar.setHealth(health);

        //outra formula maluca pra ficar mais rapido por level

        /*
        float movementSpeedLevel = movementSpeed + game.GetComponent<Game>().level / 100;

        //print(movementSpeedLevel);
        Vector3 alvo = tree.transform.position;
        alvo.y = this.transform.position.y;

        this.transform.LookAt(alvo);
        if (moveBackwards)
        {
            this.transform.Translate(Vector3.back * movementSpeedLevel * Time.deltaTime);
            countBackwards += 1 * Time.deltaTime;
            if (countBackwards > 0.6)
            {
                countBackwards = 0;
                moveBackwards = false;
            }
        } else
        {
            this.transform.Translate(Vector3.forward * movementSpeedLevel * Time.deltaTime);
        }
        */
    }

    public void Die()
    {
        game.GetComponent<Game>().score += pointsToGive;
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
            //moveBackwards = true;
            //Destroy(this.gameObject);
        }

        if (other.tag == "Player")
        {
            player.GetComponent<Player>().health -= damageLevel;
            Destroy(this.gameObject);
        }

    }
}
