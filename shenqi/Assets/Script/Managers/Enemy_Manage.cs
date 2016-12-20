using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CG_Public;
using LitJson;
namespace CG_Manage
{
    public class Enemy_Manage
    {
        private static Enemy_Manage _instance = null;
        protected Enemy_Manage() { }
        public static Enemy_Manage CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new Enemy_Manage();
            }
            return _instance;
        }
        MB_Manage MB = MB_Manage.CreateInstance();
        //必须在场景 Start中调用;

        protected GameObject CloneModel(string Path)
        {
            GameObject obj = null;
            GameObject Modelres = CG_Games.LoadObject(Path);
            obj = MB.MB_Instantiate(Modelres);
            Vector3 size = new Vector3(1f, 1f, 1f);
            Vector3 Position = new Vector3(0, 0, 0);
            Vector3 Rotation = new Vector3(0, 0, 0);
            obj.transform.localScale = size;
            obj.transform.localPosition = Position;
            obj.transform.localRotation = Quaternion.Euler(Rotation);
            return obj;
        }
        protected Dictionary<string, string> GetInfo(JsonData info)
        {
            Dictionary<string, string> container = new Dictionary<string, string>();
            IDictionary infoKays = info as IDictionary;
            Debug.Log(CG_Windows.Format((string)CG_Config.LABEL["BROKEN"], (string)CG_Config.LABEL["ZRDRSX"]));
            Debug.Log(CG_Windows.Format((string)CG_Config.LABEL["BROKEN"], (string)CG_Config.LABEL["Begin"]));
            foreach (var obj in infoKays.Keys)
            {
                container.Add((string)obj, (string)info[(string)obj]);
                Debug.Log(CG_Windows.Format((string)CG_Config.LABEL["DRSX"], (string)obj, (string)info[(string)obj]));
            }
            Debug.Log(CG_Windows.Format((string)CG_Config.LABEL["BROKEN"], (string)CG_Config.LABEL["END"]));
            return container;
        }
    }
}
