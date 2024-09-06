using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] string[] _scenesToLoadAtStart;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var sceneName in _scenesToLoadAtStart)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
    }
}
