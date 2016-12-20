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
        private static Dictionary<string, GameObject> getuiid = new Dictionary<string, GameObject>();
        /// <summary>
        /// 获取UI字典
        /// </summary>
        public static Dictionary<string, GameObject> GetUIID
        {
            get
            {
                return getuiid;
            }
        }

        MB_Manage MB = MB_Manage.CreateInstance();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Obj">UI对象</param>
        /// <param name="ClassName">UI类名</param>
        public void removeUI(GameObject Obj, string ClassName)
        {
            MB.MB_Destroy(Obj);
            Debug.Log(CG_Windows.Format((string)CG_Config.LABEL["REMOVE"], ClassName));
        }
        /// <summary>
        /// 初始化UI预制体
        /// </summary>
        /// <param name="ClassName">UI类名</param>
        /// <returns></returns>
        public GameObject initUI(string ClassName)
        {
            GameObject obj = CloneUI((string)CG_Config.RESPath["UI"] + ClassName);
            Vector2 size = new Vector2(1f, 1f);
            obj.transform.parent = GameObject.Find("UI Root").transform;
            obj.transform.localScale = size;
            AddUI(ClassName, obj);
            resetZOrder(obj);
            return obj;
        }

        /// <summary>
        /// 克隆对象
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public GameObject CloneUI(string path)
        {
            GameObject res = (GameObject)Resources.Load(path);
            GameObject obj = MB.MB_Instantiate(res);
            return obj;
        }

        /// <summary>
        /// 添加UI到  GetUIID字典中
        /// </summary>
        /// <param name="ClassName">UI类名</param>
        /// <param name="obj">UI对象</param>

        public void AddUI(string ClassName, GameObject obj)
        {
            Dictionary<string, GameObject> uiid = new Dictionary<string, GameObject>(getuiid);
            if (uiid.Count <= 0)
            {
                getuiid.Add(ClassName, obj);
            }
            else
            {
                foreach (KeyValuePair<string, GameObject> index in uiid)
                {
                    if (index.Key != ClassName)
                    {
                        getuiid.Add(ClassName, obj);
                    }
                }
            }
        }

        /// <summary>
        /// 重置UI层级 
        /// </summary>
        /// <param name="obj"></param>
        public void resetZOrder(GameObject obj)
        {
            UIPanel Panel;
            Panel = obj.GetComponent<UIPanel>();
            Panel.depth = GetMaxZOrder() + 1;
        }

        /// <summary>
        /// 获取UI最大层级
        /// </summary>
        /// <returns></returns>
        public int GetMaxZOrder()
        {
            List<int> list = new List<int>();
            UIPanel Panel;
            foreach (KeyValuePair<string, GameObject> index in getuiid)
            {
                Panel = index.Value.GetComponent<UIPanel>();
                list.Add(Panel.depth);

            }
            return CG_Windows.GetMax(list);
        }

        /// <summary>
        /// 清空UI字典
        /// </summary>
        public void emptyUI()
        {
            Dictionary<string, GameObject> uiid = new Dictionary<string, GameObject>(getuiid);
            foreach (KeyValuePair<string, GameObject> index in uiid)
            {
                getuiid.Remove(index.Key);
            }
        }
    }
}
