// Decompiled with JetBrains decompiler
// Type: Quest00214ReleaseCondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00214ReleaseCondition : MonoBehaviour
{
  public NGxScroll scroll;

  [DebuggerHidden]
  public IEnumerator InitRelease(
    List<QuestDisplayConditionConverter> list,
    GameObject iconPrefab,
    GameObject conditionPrefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214ReleaseCondition.\u003CInitRelease\u003Ec__Iterator1EF()
    {
      list = list,
      conditionPrefab = conditionPrefab,
      iconPrefab = iconPrefab,
      \u003C\u0024\u003Elist = list,
      \u003C\u0024\u003EconditionPrefab = conditionPrefab,
      \u003C\u0024\u003EiconPrefab = iconPrefab,
      \u003C\u003Ef__this = this
    };
  }

  public void StartTween(bool order)
  {
    foreach (UITweener component in ((Component) this).GetComponents<UITweener>())
    {
      if (component.tweenGroup == 1)
        component.Play(order);
    }
  }

  public void StartTweenClick(bool order)
  {
    foreach (UITweener component in ((Component) this).GetComponents<UITweener>())
    {
      if (component.tweenGroup == 2)
        component.Play(order);
    }
  }
}
