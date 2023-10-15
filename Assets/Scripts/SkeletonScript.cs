using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonScript : MonoBehaviour
{
    private GameObject hero;
    private float rotationSpeed_;
    private float movementSpeed_;
    private Animator animator;
    private Collider collider_;
    //public Transform gun;

    [SerializeField] private int max_hp_ = 10; 
    [SerializeField] private int current_hp_;
    [SerializeField] private HealthBarScript health_bar_;

    void Start()
    {
        animator = GetComponent<Animator>();
        collider_ = GetComponent<Collider>();
        hero = GameObject.FindGameObjectWithTag("Player");
        current_hp_ = max_hp_;
        health_bar_.SetMaxHealth(current_hp_);
    }

    void Update()
    {
        MoveToHero();
    }

    private void MoveToHero() {
        rotationSpeed_ = 1.5f * Time.deltaTime;
        Vector3 targetDirection = hero.transform.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed_, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);

        movementSpeed_ = 3f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, hero.transform.position, movementSpeed_);
    }

    private void TakeDamage(int dmg) {
        current_hp_ -= dmg;
        health_bar_.SetHealth(current_hp_);

        if (current_hp_ <= 0) {
            animator.SetBool("Skeleton_dead", true);
        }
    }

    private void OnTriggerEnter(Collider other) {
        TakeDamage(5);
    }
}
