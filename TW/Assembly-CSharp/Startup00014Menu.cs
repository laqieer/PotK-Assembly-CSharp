// Decompiled with JetBrains decompiler
// Type: Startup00014Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    Startup00014Menu.\u003CInitSceneAsync\u003Ec__Iterator1A6 asyncCIterator1A6 = new Startup00014Menu.\u003CInitSceneAsync\u003Ec__Iterator1A6();
    return (IEnumerator) asyncCIterator1A6;
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
