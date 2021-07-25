using UnityEngine;

namespace Assets.Scripts
{
    class SettingsManager : MonoBehaviour
    {

        private void Start()
        {
            GetComponent<AudioSource>().volume = Settings.Volume;
        }
    }
}
