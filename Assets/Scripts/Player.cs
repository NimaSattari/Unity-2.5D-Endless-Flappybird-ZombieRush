using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody rigidbody;
    bool jump = false;
    [SerializeField] float ForceY;
    [SerializeField] AudioClip sfxJump;
    [SerializeField] AudioClip sfxDeath;
    AudioSource audioSource;

    private void Awake()
    {
        Assert.IsNotNull(sfxJump);
        Assert.IsNotNull(sfxDeath);
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!GameManager.instance.GameOver && GameManager.instance.GameStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.instance.PlayerStartGame();
                animator.Play("Jump");
                audioSource.PlayOneShot(sfxJump);
                rigidbody.useGravity = true;
                jump = true;
            }
        }
    }
    private void FixedUpdate()
    {
        if(jump == true)
        {
            jump = false;
            rigidbody.velocity = new Vector2(0, 0);
            rigidbody.AddForce(new Vector2(0, ForceY), ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            rigidbody.AddForce(new Vector2(-10, 10), ForceMode.Impulse);
            rigidbody.detectCollisions = false;
            audioSource.PlayOneShot(sfxDeath);
            GameManager.instance.PlayerCollide();
        }
    }
}
