using UnityEngine;
using System.Collections;
using LitJson;
namespace CG_Public
{
    public interface interface_User
    {
        string GetKey_HP {get; }
        string GetKey_MP { get; }
        string GetKey_Attack { get; }
        string GetKey_Magic { get; }//魔法
        string GetKey_Role { get; }//角色  0 为没有角色
        string GetKey_Sex { get; }// 1为男    2为女
        string GetKey_Armor { get; }//护甲
        string GetKey_Name { get; }
        string GetKey_MAC { get; }//魔法防御
        string GetKey_Model { get; }//角色模型
        string[] GetModelKeys { get; }//获取所有Key
    }
}
