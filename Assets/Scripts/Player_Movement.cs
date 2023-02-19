using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float Gravity = -9.8f;
    [SerializeField] float Speed = 5f;
    private Vector3 direction;
    SpriteRenderer spriteRenderer;

     GameObject background;

     AudioSource backGroundSound;
    
    [SerializeField] Sprite[] sprites;
    
    int spriteIndex;
    [SerializeField] float tiltAngle = 5f;

    Game_Manager gameManager;
    
    AudioSource flappingSounds;
    private void Awake()
    {
        background = GameObject.Find("BackGround");
        backGroundSound = background.GetComponent<AudioSource>();
    }
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating(nameof(SpriteAnimation),0.2f,0.2f);
        gameManager = FindObjectOfType<Game_Manager>();
        flappingSounds = GetComponent<AudioSource>();
        
    }
    private void OnEnable() {
        Vector3 positon = transform.position;
        positon.y = 0f;
        transform.position = positon;
        direction = Vector3.zero;
    }
    private void SpriteAnimation()
    {
        spriteIndex++;
        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * Speed;
            flappingSounds.Play();
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
            this.transform.position += direction * Time.deltaTime;
        }

        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tiltAngle;
        transform.eulerAngles = rotation;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            gameManager.GameOver();
            flappingSounds.Stop();
            backGroundSound.Stop();
          
        }

        else if(other.gameObject.tag == "Score")
        {
            gameManager.IncreaseScore();
            gameManager.GameStartTextFade();
        }
    }

    
}
