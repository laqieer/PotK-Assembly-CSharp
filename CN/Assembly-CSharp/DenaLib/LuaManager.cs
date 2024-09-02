// Decompiled with JetBrains decompiler
// Type: DenaLib.LuaManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

#nullable disable
namespace DenaLib
{
  public class LuaManager
  {
    private List<HotfixLua> m_Luas = new List<HotfixLua>();
    public List<HotfixLua> m_LuasClickBtn = new List<HotfixLua>();
    private LuaScriptMgr m_ShareState;

    public LuaManager(HFResourceManager resourceManager)
    {
      this.m_ShareState = new LuaScriptMgr();
      this.m_ShareState.ResourceManagerRef = resourceManager;
      this.m_ShareState.Start();
    }

    private HotfixLua CreateHotfixLua(string filehead)
    {
      string[] strArray = filehead.Split('-');
      HotfixLua hotfixLua = new HotfixLua();
      if (strArray.Length > 0)
        hotfixLua.Alias = strArray[0];
      if (strArray.Length > 1)
        hotfixLua.Time = strArray[1];
      if (strArray.Length > 2)
        hotfixLua.Point = strArray[2];
      if (strArray.Length > 3)
        hotfixLua.Param = strArray[3];
      if (strArray.Length > 4)
        hotfixLua.BtnName = strArray[4];
      if (strArray.Length > 5)
        hotfixLua.DirPath = strArray[5];
      return hotfixLua;
    }

    public void LoadLua(string luaFile)
    {
      try
      {
        FileInfo fileInfo = new FileInfo(luaFile);
        if (!fileInfo.Exists)
          return;
        string filehead = fileInfo.Name;
        if (fileInfo.Extension.Length > 0)
          filehead = fileInfo.Name.Replace(fileInfo.Extension, string.Empty);
        HotfixLua hotfixLua = this.CreateHotfixLua(filehead);
        using (StreamReader streamReader = new StreamReader((Stream) File.Open(luaFile, FileMode.Open)))
          hotfixLua.Content = streamReader.ReadToEnd();
        this.m_Luas.Add(hotfixLua);
      }
      catch (Exception ex)
      {
        Debuger.LogWarning((object) ex.Message);
      }
    }

    public void LoadPackLua(string packLuaFile)
    {
      try
      {
        if (File.Exists(packLuaFile))
        {
          string str1 = string.Empty;
          using (StreamReader streamReader = new StreamReader((Stream) File.Open(packLuaFile, FileMode.Open)))
            str1 = streamReader.ReadToEnd();
          string[] strArray1 = str1.Split('@');
          if (strArray1.Length == 2)
          {
            Singleton<GameLogic>.Instance.strLuaVersion = strArray1[0];
            str1 = strArray1[1];
          }
          string str2 = str1;
          char[] chArray = new char[1]{ '`' };
          foreach (string str3 in str2.Split(chArray))
          {
            if (!string.IsNullOrEmpty(str3))
            {
              string[] strArray2 = str3.Split('$');
              if (strArray2.Length == 2)
              {
                HotfixLua hotfixLua = this.CreateHotfixLua(strArray2[0]);
                hotfixLua.Content = strArray2[1];
                this.m_Luas.Add(hotfixLua);
              }
            }
          }
        }
        else
          Debug.LogError((object) (packLuaFile + "  Not Exist---"));
      }
      catch (Exception ex)
      {
        Debuger.LogError((object) ex.Message);
      }
    }

    public void Clear() => this.m_Luas.Clear();

    private HotfixLua FindHotfix(
      string alias,
      string time,
      string point,
      string strTag,
      string strBtnName)
    {
      for (int index = 0; index < this.m_Luas.Count; ++index)
      {
        HotfixLua lua = this.m_Luas[index];
        if (lua.Alias == alias && lua.Time == time && lua.Point == point && lua.BtnName == strBtnName)
        {
          if (lua.LuaFunc == null)
          {
            this.m_ShareState.DoString(lua.Content);
            if (lua.BtnName != "None")
              lua.LuaFunc = this.m_ShareState.GetLuaFunction(alias + "." + lua.Time + lua.Point + lua.BtnName);
            else
              lua.LuaFunc = this.m_ShareState.GetLuaFunction(alias + "." + lua.Time + lua.Point);
          }
          return lua;
        }
      }
      return (HotfixLua) null;
    }

    public bool FindHotFixClickBtn(string sceneName, string point, bool bIsHaveTag = false)
    {
      this.m_LuasClickBtn.Clear();
      bool hotFixClickBtn = false;
      for (int index = 0; index < this.m_Luas.Count; ++index)
      {
        HotfixLua lua = this.m_Luas[index];
        if (lua.Alias == sceneName && lua.Point == point)
        {
          this.m_LuasClickBtn.Add(lua);
          hotFixClickBtn = true;
        }
      }
      return hotFixClickBtn;
    }

    public int GetAmontLuasBtn() => this.m_LuasClickBtn.Count;

    public HotfixLua GetLuasBtnByIdx(int nIdx)
    {
      return nIdx >= 0 && nIdx < this.m_LuasClickBtn.Count ? this.m_LuasClickBtn[nIdx] : (HotfixLua) null;
    }

    public bool DoHotfix(
      string alias,
      EHotfixTime time,
      EHotFixFuncPoint point,
      LuaManager.HotfixReplaceCallback replaceCb,
      string strTag,
      string strBtnName,
      params object[] args)
    {
      bool flag = false;
      HotfixLua hotfix = this.FindHotfix(alias, time.ToString(), point.ToString(), strTag, strBtnName);
      if (hotfix != null)
      {
        if (hotfix.LuaFunc != null)
        {
          hotfix.LuaFunc.Call(args);
          flag = true;
        }
      }
      else if (time == EHotfixTime.Replace && replaceCb != null)
        replaceCb();
      return flag;
    }

    public delegate void HotfixReplaceCallback();
  }
}
