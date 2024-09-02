// Decompiled with JetBrains decompiler
// Type: DenaLib.WindowStackManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

#nullable disable
namespace DenaLib
{
  public class WindowStackManager
  {
    private GameObject m_UIRoot;
    private IGameLogic m_GameLogic;
    private WindowNode m_RootNode;
    private WindowNode m_TopNode;
    private Dictionary<int, WindowNode> m_WindowCache;
    private Dictionary<int, WindowNode> m_WindowTypeCache;

    public WindowStackManager()
    {
      this.m_WindowCache = new Dictionary<int, WindowNode>();
      this.m_WindowTypeCache = new Dictionary<int, WindowNode>();
    }

    public void Init(GameObject root, IGameLogic gameLogic)
    {
      this.m_UIRoot = root;
      this.m_GameLogic = gameLogic;
      this.m_WindowCache.Clear();
      this.m_WindowTypeCache.Clear();
      this.m_RootNode = this.CreateWindow(string.Empty, "dummy", -1, -1);
      this.m_WindowCache.Add(this.m_RootNode.id, this.m_RootNode);
      if (this.m_RootNode.windowProxy != null)
      {
        this.m_RootNode.windowProxy.Reset();
        this.m_RootNode.windowProxy.Show(true);
      }
      this.m_TopNode = this.m_RootNode;
    }

    private void ButtonClickRespone(GameObject button)
    {
      Debug.LogError((object) ("NguiBtn Clicked." + ((Object) button).name));
      LuaGOParam component = button.GetComponent<LuaGOParam>();
      string alias = string.Empty;
      string strTag = "None";
      string str = string.Empty;
      EHotfixTime time = EHotfixTime.After;
      if (Object.op_Implicit((Object) component))
      {
        alias = component.sceneName;
        str = component.strBeforAfter;
        if (component.strBeforAfter == "Before")
          time = EHotfixTime.Before;
      }
      LuaManager luaManager = this.m_GameLogic.GetLuaManager();
      if (button.tag.Length > 2 && button.tag != "Untagged")
        strTag = button.tag;
      luaManager.DoHotfix(alias, time, EHotFixFuncPoint.ClickButton, (LuaManager.HotfixReplaceCallback) null, strTag, ((Object) button).name, (object) button);
    }

    public void Show(string path, string name, int type, bool hideParent, params object[] param)
    {
      GameObject gameObject1 = (GameObject) null;
      LuaManager luaManager = this.m_GameLogic.GetLuaManager();
      luaManager.DoHotfix(name, EHotfixTime.After, EHotFixFuncPoint.ShowUI, (LuaManager.HotfixReplaceCallback) null, "None", "None", (object) gameObject1);
      if (!luaManager.FindHotFixClickBtn(name, EHotFixFuncPoint.ClickButton.ToString()))
        return;
      int amontLuasBtn = luaManager.GetAmontLuasBtn();
      for (int nIdx = 0; nIdx < amontLuasBtn; ++nIdx)
      {
        HotfixLua luasBtnByIdx = luaManager.GetLuasBtnByIdx(nIdx);
        if (luasBtnByIdx == null)
          break;
        if (luasBtnByIdx.Param == "None")
        {
          GameObject go = GameObject.Find(luasBtnByIdx.BtnName);
          if (Object.op_Implicit((Object) go))
          {
            go.AddComponent<UIEventListener>();
            UIButton component = go.GetComponent<UIButton>();
            if (Object.op_Implicit((Object) component))
            {
              if (luasBtnByIdx.Time == "After")
                component.onClick.Clear();
              UIEventListener.Get(go).onClick = new UIEventListener.VoidDelegate(this.ButtonClickRespone);
              LuaGOParam luaGoParam = go.AddComponent<LuaGOParam>();
              if (Object.op_Implicit((Object) luaGoParam))
              {
                luaGoParam.sceneName = name;
                luaGoParam.strBeforAfter = luasBtnByIdx.Time;
              }
            }
          }
        }
        else
        {
          foreach (GameObject gameObject2 in GameObject.FindGameObjectsWithTag(luasBtnByIdx.Param))
          {
            Transform child = gameObject2.transform.FindChild(luasBtnByIdx.DirPath + luasBtnByIdx.BtnName);
            if (Object.op_Implicit((Object) child))
            {
              GameObject gameObject3 = ((Component) child).gameObject;
              if (Object.op_Implicit((Object) gameObject3))
              {
                gameObject3.AddComponent<UIEventListener>();
                UIButton component = gameObject3.GetComponent<UIButton>();
                if (Object.op_Implicit((Object) component))
                {
                  if (luasBtnByIdx.Time == "After")
                    component.onClick.Clear();
                  UIEventListener.Get(gameObject3).onClick = new UIEventListener.VoidDelegate(this.ButtonClickRespone);
                  LuaGOParam luaGoParam = gameObject3.AddComponent<LuaGOParam>();
                  if (Object.op_Implicit((Object) luaGoParam))
                  {
                    luaGoParam.sceneName = name;
                    luaGoParam.strBeforAfter = luasBtnByIdx.Time;
                  }
                }
              }
            }
          }
        }
      }
    }

    public void Back()
    {
      if (this.m_TopNode == this.m_RootNode)
        return;
      WindowNode windowNode = this.m_TopNode;
      this.m_TopNode = this.m_TopNode.parent;
      windowNode.parent = (WindowNode) null;
      for (; windowNode != null; windowNode = windowNode.child)
      {
        if (windowNode.windowProxy != null)
          windowNode.windowProxy.Show(false);
      }
    }

    private WindowNode CreateWindow(string path, string name, int id, int type)
    {
      WindowNode window = new WindowNode();
      window.name = name;
      window.id = id;
      window.type = type;
      if (type != -1)
      {
        HFResourceManager resourceManager = this.m_GameLogic.GetResourceManager();
        Object instance = (Object) null;
        int num = (int) resourceManager.Load(path, EResType.EResPrefab, true, out instance, (OnLoadFinished) null);
        if (Object.op_Inequality(instance, (Object) null))
        {
          GameObject gameObject = resourceManager.DoInstantiate(EResType.EResPrefab, instance) as GameObject;
          if (Object.op_Inequality((Object) gameObject, (Object) null))
          {
            window.pageGameObject = gameObject;
            gameObject.transform.SetParent(this.m_UIRoot.transform);
            RectTransform component = gameObject.GetComponent<RectTransform>();
            ((Transform) component).localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            component.sizeDelta = new Vector2(0.0f, 0.0f);
            window.windowProxy = (IWindow) gameObject.GetComponent<UIWindow>();
          }
        }
      }
      return window;
    }

    private void PushTop(WindowNode windowNode, bool hideParent)
    {
      windowNode.parent = this.m_TopNode;
      windowNode.child = (WindowNode) null;
      if (this.m_TopNode != null)
      {
        this.m_TopNode.child = windowNode;
        if (hideParent && this.m_TopNode.windowProxy != null)
          this.m_TopNode.windowProxy.Show(false);
      }
      this.m_TopNode = windowNode;
    }

    public static void SetTransform(GameObject go, Vector3 pos)
    {
      ((Transform) go.GetComponent<RectTransform>()).localPosition = pos;
    }

    public ButtonEventDelegate BindButtonAction(string uiName, Button button, UnityAction action)
    {
      return new ButtonEventDelegate(this.m_GameLogic.GetLuaManager(), uiName, button, action);
    }
  }
}
