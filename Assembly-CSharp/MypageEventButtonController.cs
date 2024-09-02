// Decompiled with JetBrains decompiler
// Type: MypageEventButtonController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class MypageEventButtonController : MonoBehaviour
{
  [SerializeField]
  private UIGrid mGrid;
  private MypageEventButton[] mEventButtons;

  public MypageEventButton GetButton<T>() => this.mEventButtons == null ? (MypageEventButton) null : Array.Find<MypageEventButton>(this.mEventButtons, (Predicate<MypageEventButton>) (x => x is T));

  public virtual void UpdateButtonState()
  {
    this.mEventButtons = this.GetComponentsInChildren<MypageEventButton>(true);
    foreach (MypageEventButton mEventButton in this.mEventButtons)
      mEventButton.UpdateButtonState();
    if (!((UnityEngine.Object) this.mGrid != (UnityEngine.Object) null))
      return;
    this.mGrid.repositionNow = true;
  }
}
