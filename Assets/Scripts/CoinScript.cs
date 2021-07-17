using Assets.Scripts;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "John")
        {
            CoinManager.Pick(collision.GetComponent<JohnScript>());
            Destroy(gameObject);
        }
    }
}
