using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using LitJson;
public static class Games
{
    public static void AddClips(Animation obj,ArrayList Actions, string RoleRoot, string GenderRoot)
    {
        AnimationClip Clip;
        foreach (var index in Actions)
        {
            Clip = Resources.Load<AnimationClip>("Role/Model/" + RoleRoot + "/" + GenderRoot + "/Animation/" + index.ToString());
            obj.AddClip(Clip, index.ToString());
        }
    }
    public static GameObject LoadObject(string Path) {
        GameObject obj=null;
        bool on_off = Resources.Load<GameObject>(Path) is GameObject;
        if (on_off)
        {
            Debug.Log(Windows.Format((string)Config.LABEL["JZDXCG"], Path));
            obj = Resources.Load<GameObject>(Path);
        }
        else { Debug.LogError(Windows.Format((string)Config.LABEL["JZDXSB"], obj)); }
        return obj;
        
    }
    public static JsonData LoadJson(string jsonName)
    {
        bool on_off = Resources.Load("Json/" + jsonName).ToString() is string;
        string file = null;
        JsonData json = null;
        if (jsonName == "Label") { file = Resources.Load("Json/" + jsonName).ToString(); json = JsonMapper.ToObject(file); Config.LABEL = json; }
        if (on_off)
        {
            file = Resources.Load("Json/" + jsonName).ToString();
            json = JsonMapper.ToObject(file);
            Debug.Log(Windows.Format((string)Config.LABEL["JZJSONCG"], jsonName));
            return json;
        }
        else
        {
            Debug.LogError(Windows.Format((string)Config.LABEL["JZJSONSB"], file));
        }
        return json;
    }
    public static void LoadLevel(string SceneName)
    {
        Application.LoadLevel(SceneName);
        Debug.Log(Windows.Format((string)Config.LABEL["QHCJ"], SceneName));
    }
}

public static class Windows
{
    public static string Format(string format, params object[] args)
    {
        return String.Format(format, args);
    }
    public static int Random(int min, int max)
    {
        return UnityEngine.Random.Range(min,max);
    }
    public static float Random(float min, float max)
    {
        return UnityEngine.Random.Range(min, max);
    }
}
