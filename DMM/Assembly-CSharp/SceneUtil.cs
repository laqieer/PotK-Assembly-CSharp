// Decompiled with JetBrains decompiler
// Type: SceneUtil
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public static class SceneUtil
{
  public static void SetScroll<T1, T2>(
    NGxScroll ngxScroll,
    GameObject prefab,
    System.Action<T1, T2> callback)
    where T2 : Component
  {
    GameObject parent = ngxScroll.grid.gameObject;
    Modified<T1[]> modify = SMManager.Observe<T1[]>();
    parent.AddComponent<SceneUtilScrollView>().UpdateCallback = (System.Action) (() =>
    {
      if (!modify.IsChangedOnce())
        return;
      ngxScroll.Clear();
      foreach (T1 obj in modify.Value)
      {
        T2 component = prefab.CloneAndGetComponent<T2>(parent);
        if ((bool) (UnityEngine.Object) component)
          callback(obj, component);
        else
          Debug.LogError((object) ("Instanciate but not found component " + (object) typeof (T1) + " on SetScroll"));
      }
      ngxScroll.ResolvePosition();
    });
  }
}
