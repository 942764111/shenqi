using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
namespace usermanage
{
    public class UserManage : UserData
    {
        
        public string GetKey_HP = SetUserInfoKey.HP.ToString();
        public string GetKey_MP = SetUserInfoKey.MP.ToString();
        public string GetKey_Attack = SetUserInfoKey.Attack.ToString();
        public string GetKey_Magic = SetUserInfoKey.Magic.ToString();//魔法
        
        public string GetKey_Role = SetUserInfoKey.Role.ToString();//角色  0 为没有角色
        public string GetKey_Sex = SetUserInfoKey.Sex.ToString();// 1为男    2为女
        public string GetKey_Armor = SetUserInfoKey.Armor.ToString();//护甲
        public string GetKey_Name = SetUserInfoKey.Name.ToString();
        public string GetKey_MAC = SetUserInfoKey.MAC.ToString();//魔法防御
        public string GetKey_Model = SetUserInfoKey.Model.ToString();//角色模型

        public string[] GetModelKeys = {
            SetUserInfoKey.HP.ToString(),
            SetUserInfoKey.MP.ToString(),
            SetUserInfoKey.Attack.ToString(),
            SetUserInfoKey.Magic.ToString(),
            SetUserInfoKey.Armor.ToString(),
            SetUserInfoKey.MAC.ToString()
        };

        /*
          注册：
          name:名字
          account：账号
          password：密码
        */
        public string GetZhuce(string name, string account, string password)
        {
            string filepath = Application.dataPath + @"/Resources/UserData.xml";
            string on_off = "1";
            Debug.Log(Windows.Format((string)Config.LABEL["ZC"],name, account, password));
            if (account == "")
            {
                Debug.LogError(Config.LABEL["ZHYW"]);
                on_off = "2";
            }
            else if (password == "")
            {
                Debug.LogError(Config.LABEL["MMYW"]);
                on_off = "3";
            }
            else if (name == "")
            {
                Debug.LogError(Config.LABEL["MZYW"]);
                on_off = "4";
            }
            if (on_off == "1")
            {
                if (!File.Exists(filepath))
                {
                    createXml(name, account, password);
                    Debug.Log(Config.LABEL["ZCCG"]);
                }
                else if (File.Exists(filepath))
                {
                    on_off = AddXml(name, account, password);
                    if (on_off == "5")
                    {
                        Debug.LogError(Config.LABEL["ZHCZ"]);
                    }
                }
                else if (on_off == "1")
                {
                    Debug.Log(Config.LABEL["ZCCG"]);
                }
            }
            return on_off;
        }
        /*
         登录：
         account：账号
         password：密码
        */
        public string GetLogin(string account, string password)
        {
            string value = "";
            bool on_off = login(account, password);
            if (on_off)
            {
                StaticGame.GetUserInfo = Getinfos(account);
                if (StaticGame.GetUserInfo["Role"] == "1")
                {
                    Debug.Log(Config.LABEL["DLCG"]);
                    value = "1";
                }
                else {
                    Debug.Log(Config.LABEL["MYJS"]);
                    value = "2";
                }
            }
            else {
                Debug.LogError(Config.LABEL["ZHMMYW"]);
                value = "0";
            }
            return value;
        }

        /*
        获取用户所有属性：
        account：用户账户
        */
        public Dictionary<string, string> Getinfos(string account)
        {
            Dictionary<string, string> Object = new Dictionary<string, string>();
            Object = FindAllInfo(account);
            Debug.Log(Windows.Format((string)Config.LABEL["BROKEN"],(string)Config.LABEL["Begin"]));
            foreach (KeyValuePair<string, string> index in Object)
            {
                Debug.Log(Windows.Format((string)Config.LABEL["YHSX"], index.Key, index.Value));
            }
            Debug.Log(Windows.Format((string)Config.LABEL["BROKEN"], (string)Config.LABEL["END"]));
            return Object;
        }

        /*
        获取用户所有属性Key值：
        */
        public ArrayList GetinfoKeys()
        {
            ArrayList list = new ArrayList();

            foreach (KeyValuePair<string, string> index in StaticGame.GetUserInfo)
            {
                list.Add(index.Key);
            }
            return list;
        }

        /*
        V值是否相同
        */
        public bool isSame(string key, string Value)
        {
            bool on_off = FindSame(key,Value);
            return on_off;
        }

        /*
        更改及更新用户属性V值：
        id：用户ID
        key：K值属性
        Value：V值属性
        */
        public void SetInfo(string id, string key, string Value)
        {
            bool on_off = UpdateInfoXml(id, key, Value);
            if (on_off) {
                StaticGame.GetUserInfo[key] = Value;
                Debug.Log(Windows.Format((string)Config.LABEL["GXCG"], key, StaticGame.GetUserInfo[key]));
                return;
            }
            Debug.LogError(Windows.Format((string)Config.LABEL["GXSB"], id, key));
        }
    }
}
