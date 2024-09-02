// Decompiled with JetBrains decompiler
// Type: Versus0262MenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Versus0262MenuBase : NGMenuBase
{
  [SerializeField]
  protected UILabel txtBonus;
  [SerializeField]
  protected UILabel txtBonus2;
  [SerializeField]
  protected UILabel txtBonus3;
  [SerializeField]
  protected UILabel txtLeaderSkill;
  [SerializeField]
  protected UILabel txtPass;
  [SerializeField]
  protected UILabel txtTimeLimit;
  [SerializeField]
  protected UILabel txtTotalPower;

  public virtual void ibtnfriendoff() => Debug.Log((object) "click default event IbtnFriendOff");

  public virtual void IbtnFriendOn() => Debug.Log((object) "click default event IbtnFriendOn");

  public virtual void IbtnOrganization()
  {
    Debug.Log((object) "click default event IbtnOrganization");
  }

  public virtual void IbtnPassOff() => Debug.Log((object) "click default event IbtnPassOff");

  public virtual void IbtnPassOn() => Debug.Log((object) "click default event IbtnPassOn");

  public virtual void IbtnStartMatch() => Debug.Log((object) "click default event IbtnStartMatch");

  public virtual void IbtnTeamCondition()
  {
    Debug.Log((object) "click default event IbtnTeamCondition");
  }

  public virtual void IbtnWarExperience()
  {
    Debug.Log((object) "click default event IbtnWarExperience");
  }
}
