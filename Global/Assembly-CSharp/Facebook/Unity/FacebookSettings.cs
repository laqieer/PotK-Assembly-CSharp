// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.FacebookSettings
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Facebook.Unity
{
  public class FacebookSettings : ScriptableObject
  {
    private const string FacebookSettingsAssetName = "FacebookSettings";
    private const string FacebookSettingsPath = "FacebookSDK/SDK/Resources";
    private const string FacebookSettingsAssetExtension = ".asset";
    private static FacebookSettings instance;
    [SerializeField]
    private int selectedAppIndex;
    [SerializeField]
    private List<string> appIds = new List<string>() { "0" };
    [SerializeField]
    private List<string> appLabels = new List<string>()
    {
      "App Name"
    };
    [SerializeField]
    private bool cookie = true;
    [SerializeField]
    private bool logging = true;
    [SerializeField]
    private bool status = true;
    [SerializeField]
    private bool xfbml;
    [SerializeField]
    private bool frictionlessRequests = true;
    [SerializeField]
    private string iosURLSuffix = string.Empty;
    [SerializeField]
    private List<FacebookSettings.UrlSchemes> appLinkSchemes = new List<FacebookSettings.UrlSchemes>()
    {
      new FacebookSettings.UrlSchemes()
    };

    public static int SelectedAppIndex
    {
      get => FacebookSettings.Instance.selectedAppIndex;
      set
      {
        if (FacebookSettings.Instance.selectedAppIndex == value)
          return;
        FacebookSettings.Instance.selectedAppIndex = value;
        FacebookSettings.DirtyEditor();
      }
    }

    public static List<string> AppIds
    {
      get => FacebookSettings.Instance.appIds;
      set
      {
        if (FacebookSettings.Instance.appIds == value)
          return;
        FacebookSettings.Instance.appIds = value;
        FacebookSettings.DirtyEditor();
      }
    }

    public static List<string> AppLabels
    {
      get => FacebookSettings.Instance.appLabels;
      set
      {
        if (FacebookSettings.Instance.appLabels == value)
          return;
        FacebookSettings.Instance.appLabels = value;
        FacebookSettings.DirtyEditor();
      }
    }

    public static string AppId => FacebookSettings.AppIds[FacebookSettings.SelectedAppIndex];

    public static bool IsValidAppId
    {
      get
      {
        return FacebookSettings.AppId != null && FacebookSettings.AppId.Length > 0 && !FacebookSettings.AppId.Equals("0");
      }
    }

    public static bool Cookie
    {
      get => FacebookSettings.Instance.cookie;
      set
      {
        if (FacebookSettings.Instance.cookie == value)
          return;
        FacebookSettings.Instance.cookie = value;
        FacebookSettings.DirtyEditor();
      }
    }

    public static bool Logging
    {
      get => FacebookSettings.Instance.logging;
      set
      {
        if (FacebookSettings.Instance.logging == value)
          return;
        FacebookSettings.Instance.logging = value;
        FacebookSettings.DirtyEditor();
      }
    }

    public static bool Status
    {
      get => FacebookSettings.Instance.status;
      set
      {
        if (FacebookSettings.Instance.status == value)
          return;
        FacebookSettings.Instance.status = value;
        FacebookSettings.DirtyEditor();
      }
    }

    public static bool Xfbml
    {
      get => FacebookSettings.Instance.xfbml;
      set
      {
        if (FacebookSettings.Instance.xfbml == value)
          return;
        FacebookSettings.Instance.xfbml = value;
        FacebookSettings.DirtyEditor();
      }
    }

    public static string IosURLSuffix
    {
      get => FacebookSettings.Instance.iosURLSuffix;
      set
      {
        if (!(FacebookSettings.Instance.iosURLSuffix != value))
          return;
        FacebookSettings.Instance.iosURLSuffix = value;
        FacebookSettings.DirtyEditor();
      }
    }

    public static string ChannelUrl => "/channel.html";

    public static bool FrictionlessRequests
    {
      get => FacebookSettings.Instance.frictionlessRequests;
      set
      {
        if (FacebookSettings.Instance.frictionlessRequests == value)
          return;
        FacebookSettings.Instance.frictionlessRequests = value;
        FacebookSettings.DirtyEditor();
      }
    }

    public static List<FacebookSettings.UrlSchemes> AppLinkSchemes
    {
      get => FacebookSettings.Instance.appLinkSchemes;
      set
      {
        if (FacebookSettings.Instance.appLinkSchemes == value)
          return;
        FacebookSettings.Instance.appLinkSchemes = value;
        FacebookSettings.DirtyEditor();
      }
    }

    private static FacebookSettings Instance
    {
      get
      {
        if (Object.op_Equality((Object) FacebookSettings.instance, (Object) null))
        {
          FacebookSettings.instance = Resources.Load(nameof (FacebookSettings)) as FacebookSettings;
          if (Object.op_Equality((Object) FacebookSettings.instance, (Object) null))
            FacebookSettings.instance = ScriptableObject.CreateInstance<FacebookSettings>();
        }
        return FacebookSettings.instance;
      }
    }

    public static void SettingsChanged() => FacebookSettings.DirtyEditor();

    private static void DirtyEditor()
    {
    }

    [Serializable]
    public class UrlSchemes
    {
      [SerializeField]
      private List<string> list;

      public UrlSchemes(List<string> schemes = null)
      {
        this.list = schemes != null ? schemes : new List<string>();
      }

      public List<string> Schemes
      {
        get => this.list;
        set => this.list = value;
      }
    }
  }
}
