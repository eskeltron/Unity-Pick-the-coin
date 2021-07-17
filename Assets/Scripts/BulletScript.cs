using Assets.Scripts;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public AudioClip Sound;
    public float Speed;

    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    } 

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ISoldier soldier = collider.GetComponent<ISoldier>();
        if (soldier != null)
        {
            soldier.HitManage();
        }
        DestroyBullet();
    }
}
