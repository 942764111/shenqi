using UnityEngine;
using System.Collections;
using CG_Public;
namespace CG_Manage
{
    public class Hero_Manage
    {
        private static Hero_Manage _instance = null;
        protected Hero_Manage() { }
        public static Hero_Manage CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new Hero_Manage();
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
    }
}
