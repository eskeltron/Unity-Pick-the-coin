using Assets.Scripts;
using UnityEngine;

public class GruntScript : ActivePlayer
{
    public GameObject John;
    public GameObject EnemiesUI;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Animator = GetComponent<Animator>();
        Health = 3;
        EnemiesUI = GameObject.Find("EnemiesUI");
    }

    // Update is called once per frame
    void Update()
    {
        if (John == null || Health == 0) return;

        Vector3 johnDistance = John.transform.position - transform.position;

        direction = johnDistance.x > 0 ? Vector2.right : Vector2.left;
        spriteRenderer.flipX = direction == Vector2.right;

        float distanceToJohn = Mathf.Abs(johnDistance.x);

        if (distanceToJohn < 1.0f && Time.time > LastShoot + 0.45f && Health > 0)
        {
            ShootManage();
            LastShoot = Time.time;
        }
    }

    public override void HitManage()
    {
        base.HitManage();
        if (Health == 0)
        {
            EnemiesUI.GetComponent<EnemiesUIScript>().UpdateLeftEnemies();
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}
