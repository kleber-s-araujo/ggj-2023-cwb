using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject Enemy;
    private float timeToSpawn;
    private float count;
    private float countLevel;
    public float level;

    public int score;
    public TextMeshProUGUI scoreText;
    public GameObject tree;
    public GameObject player;

    public GameObject gameOverUI;
    

    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = Random.Range(1, 2);
        count = countLevel = 0f;
        level = 1;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        count += 1 * Time.deltaTime;
        countLevel += 1 * Time.deltaTime;

        if (count >= timeToSpawn)
        {
            //float randAux = Random.Range(-49, 49);
            float randAuxX;
            float randAuxZ;

            int randomNumber = Random.Range(0,2);

            if (randomNumber == 0)
            {
                randAuxX = Random.Range(-49f, 49f);
                randAuxZ = Random.Range(0, 1) == 0 ? -49 : 49;
            }
            else
            {
                randAuxZ = Random.Range(-49f, 49f);
                randAuxX = Random.Range(0, 2) == 0 ? -49 : 49;
            }

            float y = 4;

            Instantiate(Enemy.transform, new Vector3(randAuxX, y, randAuxZ), Enemy.transform.rotation);

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

        if (tree.GetComponent<Tree>().health <= 0)
        {
            gameOver();
        }

        scoreText.text = score.ToString();
    }

    private void gameOver()
    {
        Debug.Log("dentro game over");
        gameOverUI.SetActive(true);
        player.SetActive(false);
    }

    public void restart()
    {
        SceneManager.LoadScene(0);
    }

    public void leave()
    {
        Application.Quit();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
