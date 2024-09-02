// Decompiled with JetBrains decompiler
// Type: AnytimeTween
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class AnytimeTween : MonoBehaviour
{
  public static void TweenStart(Transform trans)
  {
    UITweener[] components = trans.gameObject.GetComponents<UITweener>();
    if (components != null)
      ((IEnumerable<UITweener>) components).Where<UITweener>((Func<UITweener, bool>) (x => x.tweenGroup == 12 || x.tweenGroup == 11)).ToList<UITweener>().ForEach((System.Action<UITweener>) (x => NGTween.playTween(x)));
    foreach (Transform tran in trans)
      AnytimeTween.TweenStart(tran);
  }

  public static void TweenStart(Transform trans, bool active)
  {
    trans.gameObject.SetActive(active);
    AnytimeTween.TweenStart(trans);
  }
}
