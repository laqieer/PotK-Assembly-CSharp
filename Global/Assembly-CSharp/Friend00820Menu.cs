﻿// Decompiled with JetBrains decompiler
// Type: Friend00820Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Friend00820Menu : BackButtonMenuBase
{
  [SerializeField]
  private NGxScroll ScrollContainer;

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  public void ScrollContainerResolvePosition() => this.ScrollContainer.ResolvePosition();
}
