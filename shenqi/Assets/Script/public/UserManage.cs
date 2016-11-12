using UnityEngine;
using System.Collections;
using System.IO;
namespace usermanage
{
    public class UserManage : UserData
    {
      /*
        注册：
        name:名字
        account：账号
        password：密码
      */
        public string Zhuce(string name, string account, string password)
        {
            string filepath = Application.dataPath + @"/Resources/UserData.xml";
            string on_off = "1";
            Debug.LogError("【name】：" + name + "【account】：" + account + "【password】：" + password);
            if (account == "")
            {
                Debug.LogError("账号输入有误！！！");
                on_off = "2";
            }
            else if (password == "")
            {
                Debug.LogError("密码输入有误！！！");
                on_off = "3";
            }
            else if (name == "")
            {
                Debug.LogError("名字输入有误！！！");
                on_off = "4";
            }
            if (on_off == "1")
            {
                if (!File.Exists(filepath))
                {
                    createXml(name, account, password);
                }
                else if (File.Exists(filepath))
                {
                    on_off = AddXml(name, account, password);
                    if (on_off == "5")
                    {
                        Debug.LogError("账户已存在！！！");
                    }
                }
                else if (on_off == "1")
                {
                    Debug.Log("登录成功！！！");
                }
            }
            return on_off;
        }
        /*
         登录：
         account：账号
         password：密码
        */
        //public bool Login(string account, string password)
        //{
        //    bool on_off=false;


        //}

    }
}
