using UnityEngine;

public class JohnMovement : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        bool isWalking = Horizontal != 0.0f;

        Animator.SetBool("Running", isWalking);

        if (isWalking)
        {
            Walk();
        }        

        Grounded = Physics2D.Raycast(transform.position, Vector3.down, 0.1f);

        Animator.SetBool("Jumping", !Grounded);

        if (Grounded && Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Walk()
    {
        if (Time.time > LastWalk + 0.10f)
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(WalkSound);
            LastWalk = Time.time;
        }
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.1f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }
    private void Shoot()
    {
        Vector3 direction = transform.localScale.x == 1.0f ? Vector2.right : Vector2.left;
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    private void Jump()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(JumpSound);
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

    public void Hit()
    {
        if (--Health == 0)
        {
            Animator.SetBool("isDead", true);
            Camera.main.GetComponent<AudioSource>().PlayOneShot(DeadSound);
        }
    }

    public void DestroyJohn()
    {
        Destroy(gameObject);
    }
}
