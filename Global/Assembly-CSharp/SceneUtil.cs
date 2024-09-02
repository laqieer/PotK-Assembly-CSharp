// Decompiled with JetBrains decompiler
// Type: SceneUtil
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public static class SceneUtil
{
  public static void SetScroll<T1, T2>(
    NGxScroll ngxScroll,
    GameObject prefab,
    Action<T1, T2> callback)
    where T2 : Component
  {
    GameObject parent = ((Component) ngxScroll.grid).gameObject;
    Modified<T1[]> modify = SMManager.Observe<T1[]>();
    parent.AddComponent<SceneUtilScrollView>().UpdateCallback = (System.Action) (() =>
    {
      if (!modify.IsChangedOnce())
        return;
      ngxScroll.Clear();
      foreach (T1 obj in modify.Value)
      {
        T2 component = prefab.CloneAndGetComponent<T2>(parent);
        if (Object.op_Implicit((Object) (object) component))
          callback(obj, component);
        else
          Debug.LogError((object) ("Instanciate but not found component " + (object) typeof (T1) + " on SetScroll"));
      }
      ngxScroll.ResolvePosition();
    });
  }
}
