using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    public Button btnClose;
    public Button btnQuit;
    public Button btnCancel;
    
    // Start is called before the first frame update
    void Start()
    {
        btnClose.ClickEvent += () =>
        {
            Hide();
        };
        btnCancel.ClickEvent += () =>
        {
            Hide();
        };
        btnQuit.ClickEvent += () => SceneManager.LoadScene("StartScene");
        
        Hide();
    }
}
