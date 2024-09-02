// Decompiled with JetBrains decompiler
// Type: CommonBackground
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class CommonBackground : NGMenuBase
{
  public UIWidget bgContainer;
  private GameObject current;

  public GameObject Current => this.current;

  [DebuggerHidden]
  private IEnumerator LateRemoveAll(GameObject[] objs)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CommonBackground.\u003CLateRemoveAll\u003Ec__Iterator8C9()
    {
      objs = objs,
      \u003C\u0024\u003Eobjs = objs
    };
  }

  public void releaseBackground()
  {
    this.StartCoroutine(this.LateRemoveAll(((Component) this.bgContainer).transform.GetChildren().Select<Transform, GameObject>((Func<Transform, GameObject>) (x => ((Component) x).gameObject)).ToArray<GameObject>()));
    this.current = (GameObject) null;
  }

  public void setBackground(GameObject prefab)
  {
    this.StartCoroutine(this.LateRemoveAll(((Component) this.bgContainer).transform.GetChildren().Select<Transform, GameObject>((Func<Transform, GameObject>) (x => ((Component) x).gameObject)).ToArray<GameObject>()));
    this.current = NGUITools.AddChild(((Component) this.bgContainer).gameObject, prefab);
  }

  public bool ComparisonBackground(GameObject prefab)
  {
    return this.hasBackground() || ((Component) this.bgContainer).transform.childCount <= 0 || !(this.current.GetComponent<QuestBG>().namePrefab == prefab.GetComponent<QuestBG>().namePrefab);
  }

  public bool hasBackground()
  {
    return Object.op_Equality((Object) this.current, (Object) null) || Object.op_Equality((Object) this.current.GetComponent<QuestBG>(), (Object) null);
  }
}
