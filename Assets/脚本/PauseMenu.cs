using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;    //游戏状态是否是暂停状态
    public GameObject pauseMenuUI;    //存放暂停ui自己

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //当玩家按下了esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused) { Resume(); }
            else { Pause(); }
        }
    }

    //返回游戏
    public void Resume()
    {
        pauseMenuUI.SetActive(false);   //让菜单隐藏
        //UIManager.Instance.PaneIFadeIn();   //调用退出的函数
        //Time.timeScale = 1.0f;          //
        GameIsPaused = false;           //将变量设为false
    }

    //暂停
    public void Pause()
    {
        pauseMenuUI.SetActive(true);    //让菜单显示
        UIManager.Instance.PaneIFadeIn();   //调用ui出现的动效
        //Time.timeScale = 0.1f;          //
        GameIsPaused = true;           //将变量设为true
    }

    //回到主菜单
    public void MainMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    //退出游戏
    public void QuitGame()
    {
        Application.Quit();
    }

}
