using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CG_Public;
namespace CG_Manage
{
    public abstract class Scene_Manage : MonoBehaviour
    {
        protected abstract void initUI();
        protected abstract void initBtns();
        protected abstract void Callback(GameObject Obj);

        public void LoadLevel(string SceneName)
        {
            //每次转换场景清空UI字典里
            foreach (KeyValuePair<string, GameObject> index in CG_variable.GetUIID)
            {
                CG_variable.GetUIID.Remove(index.Key);
            }
            Application.LoadLevel(SceneName);

            Debug.Log(CG_Windows.Format((string)CG_Config.LABEL["QHCJ"], SceneName));
        }

        //添加UI界面到字典   
        public void AddUI(string ClassName, GameObject obj)
        {

            foreach (KeyValuePair<string, GameObject> index in CG_variable.GetUIID)
            {
                if (index.Key != ClassName)
                {
                    CG_variable.GetUIID.Add(ClassName, obj);
                }
            }
        }
    }
}
