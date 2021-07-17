using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class CoinUIScript : MonoBehaviour
{
    public GameObject Coins;
    private int totalCoins;
    // Start is called before the first frame update
    void Start()
    {
        totalCoins = Coins.transform.childCount;
        CoinManager.TotalCoins = totalCoins;
        GetComponent<Text>().text = "0/" + totalCoins + " coins";
    }

    public void UpdatePickedCoins(int coins)
    {
        GetComponent<Text>().text = coins + "/" + totalCoins + " coins";
    }
}
