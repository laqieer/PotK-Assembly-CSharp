﻿// Decompiled with JetBrains decompiler
// Type: Friend00820Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

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
