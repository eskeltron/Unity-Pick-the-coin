using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class JohnScript : ActivePlayer, IMovements
{
    public AudioClip PickCoinSound;
    public GameObject coinUI;
    public GameObject livesUI;

    [HideInInspector] public int coins;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health > 0)
        {
            WalkManage();

            JumpManage();

            if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f)
            {
                ShootManage();
                LastShoot = Time.time;

            }
        }
    }

    public override void HitManage()
    {
        if(Health > 0)
        {
            base.HitManage();
            livesUI.GetComponent<Text>().text = Health + " lives";
        }
    }
    public override void DeathPlayer()
    {
        base.DeathPlayer();
        OwnSceneManager.GoToScene(OwnSceneManager.SCENES.LOSE);
    }

    public void PickCoin()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(PickCoinSound);
        coins += 1;
        coinUI.GetComponent<CoinUIScript>().UpdatePickedCoins(coins);
    }
    private void FixedUpdate() 
    { 
    
        if (Health > 0) {
            Rigidbody2D.velocity = new Vector2(Horizontal* Speed, Rigidbody2D.velocity.y);
        }
    }
    public void WalkManage()
    {

        Horizontal = Input.GetAxisRaw("Horizontal");

        bool isWalking = Horizontal != 0.0f;

        Animator.SetBool("Running", isWalking);

        if (isWalking)
        {
            if (Time.time > LastWalk + 0.10f)
            {
                if (IsTouchingFloor())
                {
                    Camera.main.GetComponent<AudioSource>().PlayOneShot(WalkSound);
                }
                LastWalk = Time.time;
            }
            spriteRenderer.flipX = Horizontal < 0.0f;
            direction = spriteRenderer.flipX ? Vector2.left : Vector2.right;
        }
    }

    public void JumpManage()
    {
        if (Input.GetKeyDown(KeyCode.W) && IsTouchingFloor()) 
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(JumpSound);
            Rigidbody2D.AddForce(Vector2.up * JumpForce);
        }
    }
    private bool IsTouchingFloor()
    {
        Collider2D[] colliders = new Collider2D[] { new Collider2D(), new Collider2D() };
        int contacts = Rigidbody2D.GetContacts(colliders);
        if (contacts > 0) {
            return (colliders[0] != null && colliders[0].CompareTag("Floor")) || (colliders[1] != null && colliders[1].CompareTag("Floor"));
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "DeadLine")
        {
            DeathPlayer();
        }
    }
}
