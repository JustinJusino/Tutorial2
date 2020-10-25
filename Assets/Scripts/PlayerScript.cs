using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rd2d; 
    public float speed;
    public Text score;
    public Text winText;
    private int scoreValue = 0;
    public Text livesText;
    private int livesValue = 3;
    public Text loseText;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioSource musicSource;
    Animator anim;
    Vector3 playerScale;
    float playerScaleX;
    private bool isOnGround;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        livesText.text = livesValue.ToString();
        anim = GetComponent<Animator>();
        playerScale = transform.localScale;
        playerScaleX = playerScale.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, verMovement * speed)); 
        isOnGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, allGround);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
        }
    
        if(scoreValue == 4)
        {
            scoreValue += 1;
            livesValue /= livesValue;
            livesValue += 2;
            livesText.text = livesValue.ToString();
            transform.position = new Vector2(58.8f, 0.7f);
        }
        if (collision.collider.tag == "Enemy")
        {
            livesValue -= 1;
            livesText.text = livesValue.ToString();
            Destroy(collision.collider.gameObject);
        }
        if (livesValue == 0)
        {
            loseText.text = ("You Lost! Exit the Game using 'Esc'");
            Destroy(GameObject.FindWithTag("Player"));
        }
        if (scoreValue == 9)
        {
            musicSource.clip = musicClipTwo;
            musicSource.PlayOneShot(musicClipTwo);
            musicSource.loop = false;
            winText.text = ("You Won ! Exit the Game using 'Esc'");
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground" && isOnGround)
        {
            if(Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
            if(Input.GetKey(KeyCode.UpArrow))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
            
        }
    }
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
            if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetInteger("State", 2);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
              anim.SetInteger("State", 0); 
        }
         if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetInteger("State", 2);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
              anim.SetInteger("State", 0); 
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            playerScale.x = -playerScaleX;
        }
        if(Input.GetAxis("Horizontal") > 0)
        {
            playerScale.x = playerScaleX;
        }
        transform.localScale = playerScale;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetInteger("State", 2);
        }
         if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
              anim.SetInteger("State", 0); 
        }
             if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetInteger("State", 2);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
              anim.SetInteger("State", 0); 
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetInteger("State", 3);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
             anim.SetInteger("State", 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetInteger("State", 3);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
             anim.SetInteger("State", 0);
        }
    }
}

