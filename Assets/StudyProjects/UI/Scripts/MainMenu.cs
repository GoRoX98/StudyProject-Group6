using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private List<UnityEvent> _events;

    private void Awake()
    {
        //DontDestroyOnLoad(this);
    }

    private void OnEnable()
    {
        SceneManager.activeSceneChanged += SceneChanged;
        
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= SceneChanged;
    }

    private void SceneChanged(Scene arg0, Scene arg1)
    {
        print($"Scene was changed from {arg0.name} to {arg1.name}");
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void ChangeScene(string sceneName)
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(sceneName);
        loading.allowSceneActivation = true;
    }
}
