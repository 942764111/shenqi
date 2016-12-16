using UnityEngine;
using CG_Manage;
using CG_Public;
public class UI_GameStart : UI_Manage {
    // Use this for initialization
    string ClassID = "UI_GameStart";
    User_Manage userdata;
    void Start() {
        userdata = new User_Manage();
        initUI();
    }
    protected override void initUI() {
        AddUI(ClassID, this.gameObject);
        initStartBtns();
    }
    //----------------初始化开始界面
    void initStartBtns() {
        Transform  begin = transform.Find("bgein");
        Transform  zc = transform.Find("zc");

        UIEventListener.Get(begin.gameObject).onClick = BtnStart_dl;
        UIEventListener.Get(zc.gameObject).onClick = BtnStart_zc;
    }
    protected override void Callback(GameObject Obj)
    {

    }
    //登录按钮
    void BtnStart_dl(GameObject obj) {
        UILabel zh = GameObject.Find("zh").GetComponent<UILabel>();
        UILabel mm = GameObject.Find("mima").GetComponent<UILabel>(); 
        string on_off = userdata.GetLogin(zh.text, mm.text);
        switch (on_off) {
            case "1":
                GameModel_role role = new GameModel_role();
                CG_Games.LoadLevel("Game");
                break;
            case "2":
                CG_Games.LoadLevel("Selectrole");
                break;
            default:
                break;
        }
    }
    //注册按钮
    void BtnStart_zc(GameObject obj){
        initZClayer();
        Debug.Log("注册界面");//待定
    }

    //----------------初始化注册界面
    void initZClayer() {
        UI_Manage login = new UI_Login();
    }
}
