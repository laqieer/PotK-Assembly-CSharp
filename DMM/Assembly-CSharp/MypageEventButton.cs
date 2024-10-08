﻿// Decompiled with JetBrains decompiler
// Type: MypageEventButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public abstract class MypageEventButton : MonoBehaviour
{
  [SerializeField]
  private GameObject mBadge;

  public abstract bool IsActive();

  public abstract bool IsBadge();

  public virtual void SetActive(bool value) => this.gameObject.SetActive(value);

  public virtual void SetBadgeActive(bool value)
  {
    if (!((Object) this.mBadge != (Object) null))
      return;
    this.mBadge.SetActive(value);
  }

  public virtual void UpdateButtonState()
  {
    if (this.IsActive())
    {
      this.SetActive(true);
      if (this.IsBadge())
        this.SetBadgeActive(true);
      else
        this.SetBadgeActive(false);
    }
    else
      this.SetActive(false);
  }
}
