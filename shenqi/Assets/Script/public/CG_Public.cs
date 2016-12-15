using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using LitJson;
namespace CG_Public
{
    public static class CG_Games
    {
        public static void AddClips(Animation obj, ArrayList Actions, string RoleRoot, string GenderRoot)
        {
            AnimationClip Clip;
            foreach (var index in Actions)
            {
                Clip = Resources.Load<AnimationClip>("Role/Model/" + RoleRoot + "/" + GenderRoot + "/Animation/" + index.ToString());
                obj.AddClip(Clip, index.ToString());
            }
        }
        public static GameObject LoadObject(string Path)
        {
            GameObject obj = null;
            bool on_off = Resources.Load<GameObject>(Path) is GameObject;
            if (on_off)
            {
                Debug.Log(CG_Windows.Format((string)CG_Config.LABEL["JZDXCG"], Path));
                obj = Resources.Load<GameObject>(Path);
            }
            else { Debug.LogError(CG_Windows.Format((string)CG_Config.LABEL["JZDXSB"], obj)); }
            return obj;

        }
        public static JsonData LoadJson(string jsonName)
        {
            bool on_off = Resources.Load("Json/" + jsonName).ToString() is string;
            string file = null;
            JsonData json = null;
            if (jsonName == "Label") { file = Resources.Load("Json/" + jsonName).ToString(); json = JsonMapper.ToObject(file); CG_Config.label = json; }
            if (on_off)
            {
                file = Resources.Load("Json/" + jsonName).ToString();
                json = JsonMapper.ToObject(file);
                Debug.Log(CG_Windows.Format((string)CG_Config.LABEL["JZJSONCG"], jsonName));
                return json;
            }
            else
            {
                Debug.LogError(CG_Windows.Format((string)CG_Config.LABEL["JZJSONSB"], file));
            }
            return json;
        }
        public static void LoadLevel(string SceneName)
        {
            //每次转换场景清空UI字典里
            foreach (KeyValuePair<string, GameObject> index in CG_variable.GetUIID)
            {
                CG_variable.GetUIID.Remove(index.Key);
            }
            Application.LoadLevel(SceneName);

            Debug.Log(CG_Windows.Format((string)CG_Config.LABEL["QHCJ"], SceneName));
        }

        public static void AddUI(string ClassName, GameObject obj) {
            
            foreach (KeyValuePair<string, GameObject> index in CG_variable.GetUIID)
            {
                if (index.Key != ClassName)
                {
                    CG_variable.GetUIID.Add(ClassName,obj);
                }
            }
        }
    }

    public static class CG_Windows
    {
        public static string Format(string format, params object[] args)
        {
            return String.Format(format, args);
        }
        public static int Random(int min, int max)
        {
            return UnityEngine.Random.Range(min, max);
        }
        public static float Random(float min, float max)
        {
            return UnityEngine.Random.Range(min, max);
        }
        public static int GetMax(int[] array)
        {
            if (array.Length != 0)
            {
                return array.Max();
            }
            else
            {
                return 0;
            }
        }
        public static int GetMax(List<int> array)
        {
            if (array.Count != 0)
            {
                return array.Max();
            }
            else {
                return 0;
            }
        }
    }
}
