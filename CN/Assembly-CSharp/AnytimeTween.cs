// Decompiled with JetBrains decompiler
// Type: AnytimeTween
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public class AnytimeTween : MonoBehaviour
{
  public static void TweenStart(Transform trans)
  {
    UITweener[] components = ((Component) trans).gameObject.GetComponents<UITweener>();
    if (components != null)
      ((IEnumerable<UITweener>) components).Where<UITweener>((Func<UITweener, bool>) (x => x.tweenGroup == 12 || x.tweenGroup == 11)).ToList<UITweener>().ForEach((Action<UITweener>) (x => NGTween.playTween(x)));
    foreach (Transform tran in trans)
      AnytimeTween.TweenStart(tran);
  }

  public static void TweenStart(Transform trans, bool active)
  {
    ((Component) trans).gameObject.SetActive(active);
    AnytimeTween.TweenStart(trans);
  }
}
