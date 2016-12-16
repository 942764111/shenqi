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
        userdata = new User_Manage();
        me =  CloneUI(ClassID);
        AddUI(ClassID, me);
        initBtns();
    }

    protected override void initBtns()
    {
        string[] arr = { "kaishi", "guanbi" };
        for (int i = 0; i < arr.Length; i++)
        {
            GameObject obj = GameObject.Find("zhuce/" + arr[i]);
            UIEventListener.Get(obj).onClick = Callback;
        }
    }
    protected override void Callback(GameObject Obj)
    {
        switch (Obj.name)
        {
            case "kaishi":
                BtnZC_zc(Obj);
                break;
            case "guanbi":
                Remove(Obj);
                break;
            default:
                break;
        }
    }
    //注册
    void BtnZC_zc(GameObject A)
    {
        string state = "";
        string[] str = { "namobj/name", "zh", "mima" };
        for (int i = 0; i < str.Length; i++)
        {
            UILabel label = GameObject.Find("zhuce/shurukuang/" + str[i]).GetComponent<UILabel>();
            state = userdata.GetZhuce(label.text, label.text, label.text);
        }
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
