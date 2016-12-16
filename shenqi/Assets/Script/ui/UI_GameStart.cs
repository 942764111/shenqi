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
    //----------------初始化开始界面
    protected override void initUI() {
        AddUI(ClassID, this.gameObject);
        initBtns();
    }

    protected override void initBtns() {
        string[] arr = { "bgein","zc" };
        foreach (var obj in arr) {
            Transform button = transform.Find(obj);
            UIEventListener.Get(button.gameObject).onClick = Callback;
        }
    }
    protected override void Callback(GameObject Obj)
    {
        switch (Obj.name) {
            case "bgein":
                BtnStart_dl(Obj);
                break;
            case "zc":
                BtnStart_zc(Obj);
                break;

        }
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
    //注册按钮  初始化注册界面
    void BtnStart_zc(GameObject obj){
        UI_Manage login = new UI_Login();
    }
}
