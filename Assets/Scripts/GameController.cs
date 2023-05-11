using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{

    public GameObject gameOver;
    
    public float score;
    public float coinScore;

    public TextMeshProUGUI scoreText;

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player =  GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.isDead)
        {
            score += Time.deltaTime * 5f;
            scoreText.text = Mathf.Round(score + coinScore).ToString();
        }
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void AddCoin()
    {
        coinScore += 100;
    }
}
