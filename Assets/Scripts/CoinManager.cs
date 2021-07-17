using UnityEngine;

namespace Assets.Scripts
{
    public class CoinManager
    {
        public static int TotalCoins;
        public static void Pick(JohnScript johnScript)
        {
            johnScript.PickCoin();
            if (johnScript.coins == TotalCoins)
            {
                OwnSceneManager.GoToScene(OwnSceneManager.SCENES.WIN);
            }
        }
    }
}
