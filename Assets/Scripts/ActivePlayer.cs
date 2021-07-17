using UnityEngine;

namespace Assets.Scripts
{
    public abstract class ActivePlayer : MonoBehaviour, ISoldier
    {
        public AudioClip JumpSound;
        public AudioClip DeadSound;
        public AudioClip WalkSound;
        public GameObject BulletPrefab;
        public float Speed;
        public float JumpForce;

        protected Rigidbody2D Rigidbody2D;
        protected Animator Animator;
        protected SpriteRenderer spriteRenderer;
        protected float Horizontal;
        protected bool Grounded;
        protected float LastShoot;
        protected float LastWalk;
        protected int Health;
        protected Vector2 direction;
        public virtual void ShootManage()
        {
            GameObject bullet = Instantiate(BulletPrefab, transform.position + new Vector3(direction.x, direction.y, 0) * 0.15f, Quaternion.identity);
            bullet.GetComponent<BulletScript>().SetDirection(direction);
        }

        public virtual void HitManage()
        {
            --Health;
            if (Health == 0)
            {
                DeathPlayer();
            }
        }

        public virtual void DeathPlayer()
        {
            Animator.SetBool("isDead", true);
            Camera.main.GetComponent<AudioSource>().PlayOneShot(DeadSound);
        }

        public virtual void DestroyPlayer()
        {
            Destroy(gameObject);
        }
    }
}
