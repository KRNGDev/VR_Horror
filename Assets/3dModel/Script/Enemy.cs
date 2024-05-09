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
        public AudioClip ataque;
        public AudioClip normal;
        private Transform target;
        private Animator animator;
        private AudioSource audioSource;
        public GameObject prefabfuego;

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
                print("Ataca");
                Attack();
            }
            else if (Vector3.Distance(target.position, transform.position) < followDistance)
            {
                print("Moviendose");
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
            //audioSource.PlayOneShot(ataque);
        }
        private void Move()
        {

            animator.SetBool("Attacking", false);
            animator.SetBool("Walking", true);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        private void Stop()
        {

            animator.SetBool("Attacking", false);
            animator.SetBool("Walking", false);
        }
        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Fuego"))
            {
                GameObject ardiendo = Instantiate(prefabfuego, transform.position, transform.rotation);
                ardiendo.transform.parent = transform;
                animator.SetBool("Muerto", true);

            }
        }
        public void Destruir()
        {
            Destroy(gameObject);
        }
    }
}
