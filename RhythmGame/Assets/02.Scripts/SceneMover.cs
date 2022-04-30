using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneMover : MonoBehaviour
{
    public void MoveTo(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void MoveTo(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }


}
