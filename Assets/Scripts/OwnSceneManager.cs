using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class OwnSceneManager
    {
        public enum SCENES
        {
            MENU,
            GAME,
            LOSE,
            WIN
        }

        public static void GoToScene(SCENES scene)
        {
            SceneManager.LoadScene((int)scene);
        }
    }
}
