// Decompiled with JetBrains decompiler
// Type: Versus0261MenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Versus0261MenuBase : NGMenuBase
{
  [SerializeField]
  protected UILabel TxtMatchRemain;
  [SerializeField]
  protected UILabel TxtRemain;

  public virtual void IbtnBack() => Debug.Log((object) "click default event IbtnBack");

  public virtual void IbtnClassMatch() => Debug.Log((object) "click default event IbtnClassMatch");

  public virtual void IbtnRundomMatch()
  {
    Debug.Log((object) "click default event IbtnRundomMatch");
  }

  public virtual void IbtnFriendMatch()
  {
    Debug.Log((object) "click default event IbtnFriendMatch");
  }

  public virtual void IbtnReplay() => Debug.Log((object) "click default event IbtnReplay");
}
