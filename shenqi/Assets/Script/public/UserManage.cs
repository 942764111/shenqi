using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
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
            Debug.Log("【name】：" + name + "【account】：" + account + "【password】：" + password);
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
                    Debug.Log("注册成功请登录游戏！！！");
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
                    Debug.Log("注册成功请登录游戏！！！");
                }
            }
            return on_off;
        }
        /*
         登录：
         account：账号
         password：密码
        */
        public bool Login(string account, string password)
        {
            bool on_off = login(account, password);
            if (on_off)
            {
                Debug.Log("登录成功！！！");
            }
            else {
                Debug.LogError("账号或密码有误！！！");
            }
            return on_off;
        }

        /*
        查找用户所有属性：
        id：用户ID
        */
        public Dictionary<string, string> FindIDinfos(string id)
        {
            Dictionary<string, string> Object = new Dictionary<string, string>();
            Object = FindAllInfo(id);
            Debug.Log("=======================================Begin=====================================");
            foreach (KeyValuePair<string, string> index in Object)
            {
               Debug.Log("【用户属性】：" + "【"+index.Key+"】:"+ index.Value);
            }
            Debug.Log("=======================================End=====================================");
            return Object;
        }

        /*
        更改及更新用户属性V值：
        id：用户ID
        key：K值属性
        Value：V值属性
        */
        public void UpdateInfo(string id, string key, int Value)
        {
            bool on_off = UpdateInfoXml(id, key, Value);
            if (on_off) {
                Debug.Log("更新成功！！！"+ "【用户属性】：【" + key + "】更新为【"+ Value + "】");
                return;
            }
            Debug.LogError("更新失败！！"+ "【用户属性】：【ID】:" + id+"或【Key】:"+ key + "不存在！！！");
        }
    }
}
