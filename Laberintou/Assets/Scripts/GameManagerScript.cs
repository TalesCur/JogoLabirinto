using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance;
    private int level = 3;
    void Awake(){

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        } 

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<AudioSource>().Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel(){

        level++;
        SceneManager.LoadScene($"Level{level}");
        if (level == 4){

        }
    }
}
