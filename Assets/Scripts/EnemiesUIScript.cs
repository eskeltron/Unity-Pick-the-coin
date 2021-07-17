using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesUIScript : MonoBehaviour
{
    public GameObject Enemies;
    int totalEnemies;
    // Start is called before the first frame update
    void Start()
    {
        totalEnemies = Enemies.transform.childCount;
        GetComponent<Text>().text = totalEnemies + " enemies left";
    }
    public void UpdateLeftEnemies()
    {
        GetComponent<Text>().text = --totalEnemies + " enemies left";
    }
}
