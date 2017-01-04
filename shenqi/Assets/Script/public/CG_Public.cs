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
            //Animator a;
            //AnimatorStateInfo cur = a.GetCurrentAnimatorStateInfo(0);
            //bool b = cur.IsName("攻击")
            //if(b)
            //{

            //}

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
        /// <summary>
        /// 加载Json表
        /// </summary>
        public static JsonData LoadJson(string jsonName)
        {
            //异步加载场景
//            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync();
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
    }

    public static class CG_Windows
    {
        /// <summary>
        /// 占位符
        /// </summary>
        public static string Format(string format, params object[] args)
        {
            return String.Format(format, args);
        }

        /// <summary>
        /// 随机（int）
        /// </summary>
        public static int Random(int min, int max)
        {
            return UnityEngine.Random.Range(min, max);
        }

        /// <summary>
        /// 随机 （float）
        /// </summary>
        public static float Random(float min, float max)
        {
            return UnityEngine.Random.Range(min, max);
        }
        
        /// <summary>
        /// 最大值 （int[]）
        /// </summary>
        public static int GetMax(int[] array)
        {
            if (array.Length != 0)
            {
                return array.Max();
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// 最大值 List<int>
        /// </summary>
        public static int GetMax(List<int> array)
        {
            if (array.Count != 0)
            {
                return array.Max();
            }
            else {
                return 1;
            }
        }
    }
}
