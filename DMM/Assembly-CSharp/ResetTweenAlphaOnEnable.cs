// Decompiled with JetBrains decompiler
// Type: ResetTweenAlphaOnEnable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[AddComponentMenu("Utility/Tween/ResetTweenAlphaOnEnable")]
public class ResetTweenAlphaOnEnable : MonoBehaviour
{
  [SerializeField]
  [Tooltip("fromの値を取る対象を絞ります")]
  private NGTween.Kind[] tweenGroups;
  [SerializeField]
  [Tooltip("fromの値を取る対象を絞ります")]
  private int[] tweenGroupIDs;
  [SerializeField]
  private bool isIncludeChildren;
  private TweenAlpha[] tweens_;

  private void OnEnable()
  {
    if (this.tweens_ == null)
    {
      int[] groups = ((IEnumerable<NGTween.Kind>) this.tweenGroups).Select<NGTween.Kind, int>((Func<NGTween.Kind, int>) (e => (int) e)).Concat<int>((IEnumerable<int>) this.tweenGroupIDs).Distinct<int>().ToArray<int>();
      this.tweens_ = (this.isIncludeChildren ? (IEnumerable<TweenAlpha>) this.GetComponentsInChildren<TweenAlpha>(true) : (IEnumerable<TweenAlpha>) this.GetComponents<TweenAlpha>()).Where<TweenAlpha>((Func<TweenAlpha, bool>) (t => ((IEnumerable<int>) groups).Contains<int>(t.tweenGroup))).ToArray<TweenAlpha>();
    }
    foreach (TweenAlpha tween in this.tweens_)
    {
      if ((bool) (UnityEngine.Object) tween)
      {
        tween.value = tween.from;
        tween.tweenFactor = 0.0f;
      }
    }
  }
}
