using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    private Animator animator;
    private float vertical, horizontal;
    private Rigidbody myRigidbody;
    private Transform sword_;
    private Transform shield_;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        sword_ = transform.Find("Sword");
        shield_ = transform.Find("Shield");
    }

    // Update is called once per frame
    void Update()
    {
        MoveHero();
        Attack();
    }

    void MoveHero() {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        if (vertical != 0 || horizontal != 0) {
            animator.SetBool("HeroWalk", true);
        } else {
            animator.SetBool("HeroWalk", false);
        }
        myRigidbody.velocity = new Vector3(horizontal * speed, 0, vertical * speed);
    }

    void Attack() {
        if (Input.GetMouseButtonDown(0)) {
            animator.Play("NormalAttack01_SwordShield");
        }
    }
}
