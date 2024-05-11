using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class canvasUi : MonoBehaviour
{
    public TMP_Text playerText;
    public TMP_Text enemyText;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>(); //finds the game manager object and gets the GameManagerScript component
    }

    // Update is called once per frame
    void Update()
    {
        playerText.text = "Players Score" + gameManager.playerScore; //sets the text of the scoreText to the score value from the GameManagerScript
        enemyText.text = "Enemys Score: " + gameManager.enemyScore; //sets the text of the healthText to the health value from the GameManagerScript
    }
}