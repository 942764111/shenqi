using UnityEngine;
using System.Collections.Generic;
namespace CG_Public
{
    //游戏中的静态变量
    /// <summary>
    /// 游戏中的静态变量
    /// </summary>
    public static class CG_variable
    {
        public static Dictionary<string, string> GetUserInfo = new Dictionary<string, string>();
        public static Dictionary<string, GameObject> GetUIID = new Dictionary<string, GameObject>();
    }
}
