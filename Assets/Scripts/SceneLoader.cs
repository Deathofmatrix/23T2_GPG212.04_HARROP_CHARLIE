using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BallColourChange
{
    public class SceneLoader : MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void LoadSpecificScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }

}
