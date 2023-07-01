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
    public Texture quasiStar; // 准星
    public Control.Label lbTime;
    public Control.Label lbScore;
    public Control.Label lbFPS;
    public Control.Label lbCd;
    public Control.Label lbSuspend;
    public Control.Label lbHp;
    public int hpWidth;

    int frameCount = 0;
    float deltaTime = 0.0f;
    float updateRate = 0.5f; // 更新帧率的时间间隔
    public bool Suspend = false;

    [HideInInspector] public int score;

    [HideInInspector] public float time;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        // 初始化暂停标识
        Suspend = false;

        btnClose.ClickEvent += () =>
        {
            Suspend = true;
            QuitPanel.Instance.Show();
        };
        btnSetting.ClickEvent += () =>
        {
            Suspend = true;
            SettingPanel.Instance.Show();
            Time.timeScale = 0;
        };

        // 隐藏暂停标识
        lbSuspend.Content.text = "";
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

        // 判断按下BackQuote
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            lbSuspend.Content.text = lbSuspend.Content.text == "" ? "已暂停" : "";
            Suspend = !Suspend;
            Time.timeScale = Suspend ? 0 : 1;
            Cursor.visible = !Cursor.visible;
            Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
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
        lbHp.Content.text = currHp + "/" + maxHp;
    }
}