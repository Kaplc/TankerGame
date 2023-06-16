using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class GamePanel : BasePanel<GamePanel>
{
    public Button btnClose;
    public Button btnSetting;
    public Texture txHp;
    public Control.Label lbTime;
    public Control.Label lbScore;
    public Control.Label lbFPS;
    public int hpWidth;
    
    int frameCount = 0;
    float deltaTime = 0.0f;
    float updateRate = 0.5f; // 更新帧率的时间间隔

    [HideInInspector] public int score;

    [HideInInspector] public float time;
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        btnClose.ClickEvent += () => { QuitPanel.Instance.Show(); };
        btnSetting.ClickEvent += () =>
        {
            SettingPanel.Instance.Show();
            Time.timeScale = 0;
        };
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        lbTime.Content.text = (int)time + "秒";

        // 计算帧率
        frameCount++;
        deltaTime += Time.unscaledDeltaTime;

        if (deltaTime > updateRate)
        {
            lbFPS.Content.text = "FPS:" + (int)(frameCount / deltaTime);
            // 在文本组件中显示帧率或将其存储到变量中
            // 例如：fpsText.text = "FPS: " + fps.ToString("F2");

            frameCount = 0;
            deltaTime -= updateRate;
        }
        
        // 判断按下Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitPanel.Instance.Show();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
        }
    }

    public void AddScore(int add)
    {
        score += add;
        lbScore.Content.text = score.ToString();
    }

    public void UpdateHp(int maxHp, int currHp)
    {
        txHp.GUIPos.Width = (float)currHp / maxHp * hpWidth;
    }
}