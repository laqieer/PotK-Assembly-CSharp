// Decompiled with JetBrains decompiler
// Type: Friend0081ScrollParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Friend0081ScrollParts : FriendScrollBar
{
  [SerializeField]
  private UIButton button;

  public void Set(int index, Friend0081Menu menu)
  {
    EventDelegate.Set(this.button.onClick, new EventDelegate.Callback(((FriendScrollBar) this).onDetails));
    this.index = index;
    this.menu = menu;
  }
}
