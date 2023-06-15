using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GamePanel : MonoBehaviour
{
    public Button btnClose;
    public Button btnSetting;
    public Texture txHp;
    public Control.Label lbTime;
    public Control.Label lbScore;
    public int hpWidth;

    [HideInInspector] public int score;

    [HideInInspector] public float time;

    // Start is called before the first frame update
    void Start()
    {
        btnClose.ClickEvent += () =>
        {
            QuitPanel.Instance.Show();
        };
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