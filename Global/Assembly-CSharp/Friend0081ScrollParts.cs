// Decompiled with JetBrains decompiler
// Type: Friend0081ScrollParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
