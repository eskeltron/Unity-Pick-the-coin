using UnityEngine;

namespace Assets.Scripts
{
    class ActivePlayer : MonoBehaviour
    {
        public AudioClip JumpSound;
        public AudioClip DeadSound;
        public AudioClip WalkSound;
        public GameObject BulletPrefab;
        public float Speed;
        public float JumpForce;

        private Rigidbody2D Rigidbody2D;
        private Animator Animator;
        private float Horizontal;
        private bool Grounded;
        private float LastShoot;
        private float LastWalk;
        private int Health = 5;

        // Start is called before the first frame update
        void Start()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            Animator = GetComponent<Animator>();
        }
    }
}
