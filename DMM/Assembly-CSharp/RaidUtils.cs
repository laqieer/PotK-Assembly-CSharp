// Decompiled with JetBrains decompiler
// Type: RaidUtils
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public static class RaidUtils
{
  public static GameObject CreateTouchObject(
    EventDelegate.Callback callback,
    Transform parent)
  {
    Resolution currentResolution = Screen.currentResolution;
    GameObject gameObject = new GameObject("touch object");
    gameObject.transform.parent = parent;
    UIWidget uiWidget = gameObject.AddComponent<UIWidget>();
    uiWidget.depth = 10000;
    uiWidget.width = currentResolution.height;
    uiWidget.height = currentResolution.width;
    BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
    boxCollider.isTrigger = true;
    boxCollider.size = new Vector3()
    {
      x = (float) currentResolution.height,
      y = (float) currentResolution.width,
      z = 1f
    };
    UIButton uiButton = gameObject.AddComponent<UIButton>();
    uiButton.tweenTarget = (GameObject) null;
    EventDelegate.Add(uiButton.onClick, callback);
    return gameObject;
  }
}
