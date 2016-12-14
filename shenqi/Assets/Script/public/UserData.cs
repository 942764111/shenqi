using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;
using System;

public  class UserData
{
    protected enum SetUserKey
    {
        id,
        account,
        password
    }

    protected enum SetUserInfoKey
    {
        HP,
        MP,
        Attack,
        Magic,
        Role,
        Sex,
        Armor,
        Name,
        MAC,
        Model
    }
    //-------------SetUserKey
    int id = 1;//id
    string account = "adsdasasd";//账号
    string password = "asd151154";//密码
    //-------------SetUserInfoKey
    string Name = "乔彬";//name
    string HP = "0";//HP
    string MP = "0";//MP
    string Attack = "0";//攻击
    string Magic = "0";//魔法
    string Armor = "0";//护甲
    string MAC = "0";//魔法防御
    string Role = "0";//角色  0 为没有角色
    string Sex = "1";// 1为男    2为女
    string Model = "1";// Model iD    参考Model.json  配置

    protected void  createXml(string name, string account, string password)
    {
            string filepath = Application.dataPath + @"/Resources/UserData.xml";
            if (!File.Exists(filepath)){
                XmlDocument xmlDoc = new XmlDocument();
                XmlElement root = xmlDoc.CreateElement("transforms");
                XmlElement elmNew = xmlDoc.CreateElement("rotation");
                elmNew.SetAttribute(SetUserKey.id.ToString(), id.ToString());
                elmNew.SetAttribute(SetUserKey.account.ToString(), account.ToString());
                elmNew.SetAttribute(SetUserKey.password.ToString(), password.ToString());

                XmlElement rotation_Name = xmlDoc.CreateElement(SetUserInfoKey.Name.ToString());
                rotation_Name.InnerText = name.ToString();

                XmlElement rotation_HP = xmlDoc.CreateElement(SetUserInfoKey.HP.ToString());
                rotation_HP.InnerText = HP.ToString();

                XmlElement rotation_MP = xmlDoc.CreateElement(SetUserInfoKey.MP.ToString());
                rotation_MP.InnerText = MP.ToString();

                XmlElement rotation_ATTACK = xmlDoc.CreateElement(SetUserInfoKey.Attack.ToString());
                rotation_ATTACK.InnerText = Attack.ToString();

                XmlElement rotation_MAGIC = xmlDoc.CreateElement(SetUserInfoKey.Magic.ToString());
                rotation_MAGIC.InnerText = Magic.ToString();

                XmlElement rotation_Role = xmlDoc.CreateElement(SetUserInfoKey.Role.ToString());
                rotation_Role.InnerText = Role.ToString();

                XmlElement rotation_Sex = xmlDoc.CreateElement(SetUserInfoKey.Sex.ToString());
                rotation_Sex.InnerText = Sex.ToString();

                XmlElement rotation_Armor = xmlDoc.CreateElement(SetUserInfoKey.Armor.ToString());
                rotation_Armor.InnerText = Armor.ToString();

                XmlElement rotation_MAC = xmlDoc.CreateElement(SetUserInfoKey.MAC.ToString());
                rotation_MAC.InnerText = MAC.ToString();

                XmlElement rotation_Model = xmlDoc.CreateElement(SetUserInfoKey.Model.ToString());
                rotation_Model.InnerText = Model.ToString();

                elmNew.AppendChild(rotation_Name);
                elmNew.AppendChild(rotation_HP);
                elmNew.AppendChild(rotation_MP);
                elmNew.AppendChild(rotation_ATTACK);
                elmNew.AppendChild(rotation_MAGIC);
                elmNew.AppendChild(rotation_Role);
                elmNew.AppendChild(rotation_Sex);
                elmNew.AppendChild(rotation_Armor);
                elmNew.AppendChild(rotation_MAC);
                elmNew.AppendChild(rotation_Model);
                root.AppendChild(elmNew);
                xmlDoc.AppendChild(root);
                xmlDoc.Save(filepath);
                Debug.Log("createXml OK!");
            }
    }
    protected string AddXml(string name, string account, string password)
    {
        string on_off = "1";
        int Maxid = GetMaxID();
        string filepath = Application.dataPath + @"/Resources/UserData.xml";
        if (File.Exists(filepath))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);

            XmlNodeList nodeList = xmlDoc.SelectSingleNode("transforms").ChildNodes;
            foreach (XmlElement xe in nodeList)
            {
                if (xe.GetAttribute("account") == account)
                {
                    on_off = "5";
                    break;
                }
            }
            if (on_off=="1")
            {
                XmlNode root = xmlDoc.SelectSingleNode("transforms");
                XmlElement elmNew = xmlDoc.CreateElement("rotation");
                elmNew.SetAttribute(SetUserKey.id.ToString(), id.ToString());
                elmNew.SetAttribute(SetUserKey.account.ToString(), account.ToString());
                elmNew.SetAttribute(SetUserKey.password.ToString(), password.ToString());

                XmlElement rotation_Name = xmlDoc.CreateElement(SetUserInfoKey.Name.ToString());
                rotation_Name.InnerText = name.ToString();

                XmlElement rotation_HP = xmlDoc.CreateElement(SetUserInfoKey.HP.ToString());
                rotation_HP.InnerText = HP.ToString();

                XmlElement rotation_MP = xmlDoc.CreateElement(SetUserInfoKey.MP.ToString());
                rotation_MP.InnerText = MP.ToString();

                XmlElement rotation_ATTACK = xmlDoc.CreateElement(SetUserInfoKey.Attack.ToString());
                rotation_ATTACK.InnerText = Attack.ToString();

                XmlElement rotation_MAGIC = xmlDoc.CreateElement(SetUserInfoKey.Magic.ToString());
                rotation_MAGIC.InnerText = Magic.ToString();

                XmlElement rotation_Role = xmlDoc.CreateElement(SetUserInfoKey.Role.ToString());
                rotation_Role.InnerText = Role.ToString();

                XmlElement rotation_Sex = xmlDoc.CreateElement(SetUserInfoKey.Sex.ToString());
                rotation_Sex.InnerText = Sex.ToString();

                XmlElement rotation_Armor = xmlDoc.CreateElement(SetUserInfoKey.Armor.ToString());
                rotation_Armor.InnerText = Armor.ToString();

                XmlElement rotation_MAC = xmlDoc.CreateElement(SetUserInfoKey.MAC.ToString());
                rotation_MAC.InnerText = MAC.ToString();

                XmlElement rotation_Model = xmlDoc.CreateElement(SetUserInfoKey.Model.ToString());
                rotation_Model.InnerText = Model.ToString();

                elmNew.AppendChild(rotation_Name);
                elmNew.AppendChild(rotation_HP);
                elmNew.AppendChild(rotation_MP);
                elmNew.AppendChild(rotation_ATTACK);
                elmNew.AppendChild(rotation_MAGIC);
                elmNew.AppendChild(rotation_Role);
                elmNew.AppendChild(rotation_Sex);
                elmNew.AppendChild(rotation_Armor);
                elmNew.AppendChild(rotation_MAC);
                elmNew.AppendChild(rotation_Model);
                root.AppendChild(elmNew);
                xmlDoc.AppendChild(root);
                xmlDoc.Save(filepath);
                Debug.Log("AddXml OK!");
            }
        }
        return on_off;
    }

    protected bool login(string account, string password)
    {
        bool on_off = false;
        string filepath = Application.dataPath + @"/Resources/UserData.xml";
        if (File.Exists(filepath))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("transforms").ChildNodes;

            foreach (XmlElement xe in nodeList)
            {
                if (account == xe.GetAttribute("account"))
                {
                    if (password == xe.GetAttribute("password"))
                    {
                        on_off = true;
                        break;
                    }

                }
            }

        }
        return on_off;
    }

    protected bool UpdateInfoXml(string id, string key, string Value)
    {
        bool on_off = false;
        string filepath = Application.dataPath + @"/Resources/UserData.xml";
        if (File.Exists(filepath))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("transforms").ChildNodes;

            foreach (XmlElement xe in nodeList)
            {
                if (xe.GetAttribute("id") == id)
                {
                    foreach (XmlElement x1 in xe.ChildNodes)
                    {
                        if (x1.Name == key)
                        {
                            x1.InnerText = Value;
                            on_off = true;
                        }

                    }
                    break;
                }
            }
            xmlDoc.Save(filepath);
        }
        return on_off;
    }
    protected Dictionary<string, string> FindAllInfo(string account)
    {
        Dictionary<string, string> Object = new Dictionary<string, string>();
        string filepath = Application.dataPath + @"/Resources/UserData.xml";
        if (File.Exists(filepath))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("transforms").ChildNodes;

            foreach (XmlElement xe in nodeList)
            {
                if (xe.GetAttribute("account") == account)
                {
                    Object.Add("account", xe.GetAttribute("account"));
                    Object.Add("id", xe.GetAttribute("id"));
                    foreach (XmlElement x1 in xe.ChildNodes)
                    {
                        Object.Add(x1.Name, x1.InnerText);
                    }
                    break;
                }
            }

        }
        return Object;
    }

    protected bool FindSame(string Key, string Value)
    {
        bool on_off = false;
        string filepath = Application.dataPath + @"/Resources/UserData.xml";
        if (File.Exists(filepath))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("transforms").ChildNodes;

            foreach (XmlElement xe in nodeList)
            {
                foreach (XmlElement x1 in xe.ChildNodes)
                {
                    if (x1.InnerText.ToString() == Value)
                    {
                        on_off = true;
                    }
                }
            }

        }
        return on_off;
    }

    int GetMaxID()
    {
        int id = 1;
        int count = 0;
        string filepath = Application.dataPath + @"/Resources/UserData.xml";
        if (File.Exists(filepath))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("transforms").ChildNodes;
            foreach (XmlElement xe in nodeList)
            {
                if (count == nodeList.Count - 1)
                {
                    id = int.Parse(xe.GetAttribute("id"));
                    break;
                }
                count++;
            }
        }
        return id;
    }

    //暂时没用
    void deleteXml(string id)
    {
        string filepath = Application.dataPath + @"/Resources/UserData.xml";
        if (File.Exists(filepath))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("transforms").ChildNodes;
            foreach (XmlElement xe in nodeList)
            {
                if (xe.GetAttribute("id") == id)
                {
                    xe.RemoveAll();
                }
            }
            xmlDoc.Save(filepath);
            Debug.Log("deleteXml OK!");
        }

    }
    //暂时没用
    string FindXml(string id,string key, string Type)
    {
        string Value = null;
        string filepath = Application.dataPath + @"/Resources/UserData.xml";
        if (File.Exists(filepath))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("transforms").ChildNodes;

            foreach (XmlElement xe in nodeList)
            {
                if (xe.GetAttribute("id") == id)
                {
                    if (Type == "user")
                    {
                        Debug.Log(key + "：" + xe.GetAttribute(key));
                        Value = xe.GetAttribute(key);
                    }
                    else if (Type == "info")
                    {
                        foreach (XmlElement x1 in xe.ChildNodes)
                        {
                            if (x1.Name == key)
                            {
                                Debug.Log(key + "：" + x1.InnerText);
                                Value = x1.InnerText;
                            }
                        }
                    }

                    break;
                }
            }

        }
        return Value;
    }
}
