using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Animator anime;
    public List<GameObject> player = new List<GameObject>();

    public float speed;
    public float drift;
    public float gravity;

    public float rayRadius;
    public LayerMask layer; 
    public  LayerMask coinLayer;
    public bool isDead;


    private GameController  gameController;

    // Start is called before the first frame update
    void Start()
    {
        controller =  GetComponent<CharacterController>();
        anime = GetComponent<Animator>();
        gameController = FindObjectOfType<GameController>();
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.forward * speed;

        anime.SetBool("cima", false);
        anime.SetBool("baixo", false);
        anime.SetBool("direita", false);
        anime.SetBool("esquerda", false);

        if(Input.GetKey(KeyCode.DownArrow)){
            direction.y = (speed - gravity);
            anime.SetBool("cima", true);
            anime.SetBool("baixo", false);
            anime.SetBool("direita", false);
            anime.SetBool("esquerda", false);
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            direction.y = -(speed + gravity);
            anime.SetBool("cima", false);
            anime.SetBool("baixo", true);
            anime.SetBool("direita", false);
            anime.SetBool("esquerda", false);
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            direction.x = drift;
            anime.SetBool("cima", false);
            anime.SetBool("baixo", false);
            anime.SetBool("direita", true);
            anime.SetBool("esquerda", false);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            direction.x = -drift;
            anime.SetBool("cima", false);
            anime.SetBool("baixo", false);
            anime.SetBool("direita", false);
            anime.SetBool("esquerda", true);
        }
        
        controller.Move(direction * Time.deltaTime);

        OnCollision();
    }

    void OnCollision()
    {
        RaycastHit hit;

        if((Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayRadius, layer) || Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, rayRadius, layer)) && !isDead)
        {
            anime.SetTrigger("die");
            speed = 0;
            gravity = 0;
            drift = 0;
            if(player != null){
                player[0].SetActive(false);
            }
            Debug.Log("Hit");
            Invoke("GameOver", 1f);

            isDead = true;
        }

        RaycastHit hitCoin;

        if((Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(0,0,10f)), out hitCoin, rayRadius, coinLayer) || Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down + new Vector3(-4f,0,0)), out hit, rayRadius, coinLayer) || Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(0,0,-20f)), out hitCoin, rayRadius, coinLayer)))
        {
            gameController.AddCoin();
            Destroy(hitCoin.transform.gameObject);
        }
    }

    void GameOver()
    {
        gameController.ShowGameOver();
    }
}  
