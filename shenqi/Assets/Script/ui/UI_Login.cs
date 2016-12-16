using UnityEngine;
using CG_Manage;
public class UI_Login : UI_Manage
{
    string ClassID = "UI_Login";
    User_Manage userdata;
    GameObject me;
    public UI_Login() {
        initUI();
    }
    protected override void initUI()
    {
        userdata = User_Manage.CreateInstance();
        me =  CloneUI(ClassID);
        AddUI(ClassID, me);
        initZCBtns();
    }
    //初始化注册按钮
    void initZCBtns()
    {
        GameObject btn = GameObject.Find("zhuce/kaishi");
        if (btn)
        {
            UIEventListener.Get(btn).onClick = BtnZC_zc;
        }
        GameObject remove = GameObject.Find("zhuce/guanbi");
        if (remove)
        {
            UIEventListener.Get(remove).onClick = Remove;
        }
    }
    protected override void Callback(GameObject Obj)
    {

    }
    //注册
    void BtnZC_zc(GameObject A)
    {
        UILabel name = GameObject.Find("zhuce/shurukuang/namobj/name").GetComponent<UILabel>();
        UILabel zh = GameObject.Find("zhuce/shurukuang/zh").GetComponent<UILabel>();
        UILabel mm = GameObject.Find("zhuce/shurukuang/mima").GetComponent<UILabel>();
        string state = userdata.GetZhuce(name.text, zh.text, mm.text);
        switch (state)
        {
            case "1":
                removeUI(me, ClassID);
                break;
            case "2":

                break;
            case "3":

                break;
            case "4":

                break;
            case "5":

                break;
        }
    }
    void Remove(GameObject A)
    {
        removeUI(me, ClassID);
    }

}
