using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SanBlasVR
{
    public class Enemy : MonoBehaviour
    {
        public float speed;
        public float followDistance;
        public float attackDistance;
        private Transform target;
        private Animator animator;
        private AudioSource audioSource;

        void Start()
        {
            animator = GetComponentInChildren<Animator>();
            audioSource = GetComponentInChildren<AudioSource>();
            target = GameObject.FindGameObjectWithTag("MainCamera").transform;
        }

        // Update is called once per frame
        void Update()
        {
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
            Physics.Raycast(transform.position, target.position - transform.position, out RaycastHit hitInfo);
            if (hitInfo.transform.name != "Main Camera")
            {
                animator.SetBool("Attacking", false);
                animator.SetBool("Walking", false);
            }
            else
            {
                MoveEnemy();
            }
        }
        private void MoveEnemy()
        {
            if (Vector3.Distance(target.position, transform.position) < attackDistance)
            {
                Attack();
            }
            else if (Vector3.Distance(target.position, transform.position) < followDistance)
            {
                Move();
            }
            else
            {
                Stop();
            }
        }
        private void Attack()
        {
            animator.SetBool("Attacking", true);
            animator.SetBool("Walking", false);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        private void Move()
        {
            audioSource.Stop();
            animator.SetBool("Attacking", false);
            animator.SetBool("Walking", true);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        private void Stop()
        {
            audioSource.Stop();
            animator.SetBool("Attacking", false);
            animator.SetBool("Walking", false);
        }
    }
}
