using UnityEngine;
using System.Collections.Generic;
using CG_Public;
namespace CG_Manage
{
    public class UI_Manage
    {
        private static UI_Manage _instance = null;
        protected UI_Manage() { }
        public static UI_Manage CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new UI_Manage();
            }
            return _instance;
        }
        //删除UI
        MB_Manage MB = MB_Manage.CreateInstance();
        public void removeUI(GameObject Obj, string ClassName)
        {
            MB.MB_Destroy(Obj);
            Debug.Log(CG_Windows.Format((string)CG_Config.LABEL["REMOVE"], ClassName));
        }
        //克隆ui;
        public GameObject CloneUI(string ClassName)
        {
            GameObject res = (GameObject)Resources.Load((string)CG_Config.RESPath["UI"]+ ClassName);
            Vector2 size = new Vector2(1f, 1f);
            GameObject obj = MB.MB_Instantiate(res);
            obj.transform.parent = GameObject.Find("UI Root").transform;
            obj.transform.localScale = size;
            resetZOrder(obj);
            return obj;
        }
        //重置层级
        public void resetZOrder(GameObject obj)
        {
            UIPanel Panel;
            Panel = obj.GetComponent<UIPanel>();
            Panel.depth = GetMaxZOrder() + 1;
        }
        //获取当前场景最大层级
        public int GetMaxZOrder() {
            List<int> list = new List<int>();
            UIPanel Panel;
            foreach (KeyValuePair<string, GameObject> index in CG_variable.GetUIID)
            {
                Panel = index.Value.GetComponent<UIPanel>();
                list.Add(Panel.depth);
              
            }
            return CG_Windows.GetMax(list);
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
