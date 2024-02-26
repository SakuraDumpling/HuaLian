using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToNextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //触发开始
    private void OnTriggerEnter2D(Collider2D orther)
    {
        if (orther.gameObject.CompareTag("Player") && orther.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            AudioManager.Instance.musicSource.Stop();   //停止播放音乐
            //切换场景
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            AudioManager.Instance.PlayMusic("Start");   //重新播放
        }
    }
}
