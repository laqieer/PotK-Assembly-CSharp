// Decompiled with JetBrains decompiler
// Type: Friend00820Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
