// Decompiled with JetBrains decompiler
// Type: Startup00014Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Startup00014Menu : NGMenuBase
{
  [SerializeField]
  protected UILabel TxtNavi;
  protected List<Transform> listIcons = new List<Transform>();
  public List<IconPosition> positionList = new List<IconPosition>();

  [DebuggerHidden]
  public virtual IEnumerator InitSceneAsync(PlayerLoginBonus lB)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Startup00014Menu.\u003CInitSceneAsync\u003Ec__Iterator17B asyncCIterator17B = new Startup00014Menu.\u003CInitSceneAsync\u003Ec__Iterator17B();
    return (IEnumerator) asyncCIterator17B;
  }

  public void Play(Transform trans)
  {
    foreach (Transform tran in trans)
      this.Play(tran);
    List<UITweener> uiTweenerList = new List<UITweener>();
    foreach (UITweener uiTweener in ((IEnumerable<UITweener>) ((Component) trans).gameObject.GetComponentsInChildren<UITweener>()).ToList<UITweener>())
      uiTweenerList.Add(uiTweener);
    uiTweenerList.ForEach((Action<UITweener>) (x => ((Behaviour) x).enabled = true));
    uiTweenerList.ForEach((Action<UITweener>) (x => x.ResetToBeginning()));
    uiTweenerList.ForEach((Action<UITweener>) (x => x.PlayForward()));
  }
}
