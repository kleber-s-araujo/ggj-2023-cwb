using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables
    public float movementSpeed;
    public GameObject camera;
    public GameObject playerObj;

    public GameObject bulletSpawnPoint;
    public float waitTime;

    public GameObject bullet;

    public float points;
    public float health;

    public Animator animator;
    private Vector2 movimento;
    private int inputXhash = Animator.StringToHash("InputX");
    private int inputYhash = Animator.StringToHash("InputY");

    private void Start() {
        //animator = GetComponent<Animator>();
        animator = GameObject.Find("Men_Rigged").GetComponent<Animator>();
    }

    //Methods
    private void Update()
    {
        //Player Facing Mouse
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;

        if(playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 7f * Time.deltaTime);
        }

        //Shooting
        /* Mudado para um script único
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        */

        //Player Animation
        movimento = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        animator.SetFloat(inputXhash, movimento.x);
        animator.SetFloat(inputYhash, movimento.y);

        //Player Movement
        if (movimento.y > 0)
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        else if (movimento.y < 0)
            transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);

        if (movimento.x < 0)
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        else if (movimento.x > 0)
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);

        /*
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isWalking", true);
            
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isBackWalking", true);
            transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isBackWalking", false);
        }
            
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        */

        if (health <= 0)
        {
            Die();
        }

    }

    void Shoot()
    {
        Instantiate(bullet.transform, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
    }

    public void Die()
    {
        print("Game Over");
    }
}
