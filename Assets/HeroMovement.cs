using System;
using TMPro;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    public float speed = 5f;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public Animator heroAnimator;
    public Rigidbody2D rigidbody2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime);

        if(horizontal > 0 || horizontal < 0)
        {
            heroAnimator.SetFloat("HorizontalSpeed", horizontal);
        }

        if(vertical > 0 || vertical < 0)
        {
            heroAnimator.SetFloat("VerticalSpeed", vertical);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.AddForceY(200);
            heroAnimator.SetFloat("VerticalSpeed", 200);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Coin"))
        {
            score++;
            scoreText.text = "Score: " + score; 
            other.GetComponent<AudioSource>().Play();
            // other.gameObject.SetActive(false);
        }

        if(other.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }
}