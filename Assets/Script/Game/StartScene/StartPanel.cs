using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPanel : BasePanel<StartPanel>
{
    public Button btnStart;
    public Button btnSetting;
    public Button btnEnd;
    public Button btnRank;
    
    // Start is called before the first frame update
    void Start()
    {
        btnStart.ClickEvent += () =>
        {
            SceneManager.LoadScene("GameScene");
        };
        btnSetting.ClickEvent += () =>
        {
            SettingPanel.Instance.Show();
            this.Hide();
        };
        btnEnd.ClickEvent += () =>
        {
            Application.Quit(0);
        };
        btnRank.ClickEvent += () =>
        {
            RankPanel.Instance.Show();
            Hide();
        };
    }
    
}
