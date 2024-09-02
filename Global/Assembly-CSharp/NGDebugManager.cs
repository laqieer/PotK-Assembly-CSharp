// Decompiled with JetBrains decompiler
// Type: NGDebugManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class NGDebugManager : Singleton<NGDebugManager>
{
  public static string httpProxy;
  public static string apiUrl;
  public float timeScale = 1f;
  public NGDebugManager.APIType apiType;

  public bool isViewLayoutDebug
  {
    get
    {
      LayoutDebug[] componentsInChildren = ((Component) this).GetComponentsInChildren<LayoutDebug>(true);
      return componentsInChildren.Length != 0 && ((Behaviour) componentsInChildren[0]).enabled;
    }
    set
    {
      LayoutDebug[] componentsInChildren = ((Component) this).GetComponentsInChildren<LayoutDebug>(true);
      if (componentsInChildren.Length == 0)
        return;
      ((Behaviour) componentsInChildren[0]).enabled = value;
    }
  }

  protected override void Initialize()
  {
  }

  public enum APIType
  {
    Dummy,
    Production,
    Develop,
    Feature1,
    Feature2,
    Feature3,
    Feature4,
    Feature5,
    Staging,
    Master,
    Release,
  }
}
