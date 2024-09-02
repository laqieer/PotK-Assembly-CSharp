﻿// Decompiled with JetBrains decompiler
// Type: Story0593ScrollItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Story0593ScrollItem : MonoBehaviour
{
  [SerializeField]
  private UILabel mTitleLabel;
  private Story059ItemData mItem;

  public void Init(Story059ItemData item)
  {
    this.mItem = item;
    this.mTitleLabel.SetTextLocalize(item.title);
  }

  public void onItemClick() => this.mItem.Play();
}
