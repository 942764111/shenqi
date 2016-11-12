using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Login_Script : MonoBehaviour
{
    #region 对序列化的理解
    //[HideInInspector]表示将原本显示在面板上的序列化值隐藏起来。
    //[SerializeField]表示将原本不会被序列化的私有变量和保护变量可以序列化，
    //这么他们在下次读取时，就是你上次赋值的值。
    //序列化就是由一个对象转换成二进制，在转成字符串
    //就是私有变量想要在面板上显示，读取并保存，就选用[SerializeField]
    #endregion
    #region 登陆面板部分
    [SerializeField]
    //账户
    private InputField accountInput;
    [SerializeField]
    //密码   InputField//输入区
    private InputField passwordInput;
    #endregion


    //进人游戏
    [SerializeField]
    private Button LoginBtn;
    //注册面板
    [SerializeField]
    private GameObject regPanel;



    #region 注册面板部分
    [SerializeField]
    //账号
    public InputField regAccountInput;
    [SerializeField]
    //密码
    public InputField regpwInput;
    [SerializeField]
    //确认密码
    public InputField regpw1Input;
    #endregion



    public void loginOnClick()
    {//鼠标单击 点击
        //账号输入的长度不能超过6或者等于0
        if (accountInput.text.Length == 0 || accountInput.text.Length > 6)
        {
            Debug.Log("账号不合法");
            return;
        }
        if (passwordInput.text.Length == 0 || passwordInput.text.Length > 6)
        {
            Debug.Log("密码不合法");
            return;
        }
        //验证通过，申请登陆
        LoginBtn.interactable = false; 
    }//--------------------loginOnClick()


    public void regClick()
    {//注册账号点击函数  就会出现账号注册界面
 
        //点击注册按钮之后可以看见，之前是隐藏的
        //注册面板.设置状态（隐藏还是显示）在这的话就是显示
        regPanel.SetActive/*啊可吃符*/(true);
    }//---------------------------regClick()

    public void regCloseClick()
    { //注册账号点击关闭函数  关闭账号注册界面

        //关闭账号注册界面
        regPanel.SetActive/*啊可吃符*/(false);
    }//----------------------------- regCloseClick()


    public void regpanelregClick()
    { //点击注册账号的注册面板
        //自己理解  用注册账号按钮回调这个函数
        if (regAccountInput.text.Length == 0 || regAccountInput  .text.Length > 6)
        {
            Debug.Log("账号不合法");
            return;
        }
        if (regpwInput.text.Length == 0 || regpwInput.text.Length > 6)
        {
            Debug.Log("密码不合法");
            return;
        }
        //相等Equals
        //判断两次输入密码是否一致
        if (!regpw1Input.text.Equals(regpwInput.text))
        {
            Debug.Log("两次输入密码不一致");
            return;
        }
        //验证通过 申请注册 并关闭注册面板

    }//--------------------------- regpanelregClick()
} 
