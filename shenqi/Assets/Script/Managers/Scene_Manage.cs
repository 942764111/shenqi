using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CG_Public;
namespace CG_Manage
{
    public class Scene_Manage : MB_Manage
    {
        private static Scene_Manage _instance = null;
        protected Scene_Manage() { }
        public static Scene_Manage CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new Scene_Manage();
            }
            return _instance;
        }
        /// <summary>
        /// 切换场景
        /// </summary>
        /// <param name="SceneName">场景名字</param>
        public void LoadLevel(string SceneName)
        {
            UI_Manage.CreateInstance().emptyUI();
            Application.LoadLevel(SceneName);
            Debug.Log(CG_Windows.Format((string)CG_Config.LABEL["QHCJ"], SceneName));
        }
    }
}
