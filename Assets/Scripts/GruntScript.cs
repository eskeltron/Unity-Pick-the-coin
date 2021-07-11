using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject John;
    public GameObject BulletPrefab;
    public AudioClip DeadSound;

    private Animator Animator;
    private float LastShoot;
    private int Health = 3;
    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (John == null) return;

        Vector3 direction = John.transform.position - transform.position;
        transform.localScale = new Vector3(direction.x > 0 ? 1.0f : -1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(John.transform.position.x - transform.position.x);
        if (distance < 1.0f && Time.time > LastShoot + 0.45f && Health > 0)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction = transform.localScale.x == 1.0f ? Vector2.right : Vector2.left;
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }
    public void Hit()
    {
        if (--Health == 0)
        {
            Animator.SetBool("isDead", true);
            Camera.main.GetComponent<AudioSource>().PlayOneShot(DeadSound);
        }
    }

    public void DestroyGrunt()
    {
        Destroy(gameObject);
    }
}
