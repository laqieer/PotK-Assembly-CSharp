// Decompiled with JetBrains decompiler
// Type: Friend00816Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Friend00816Menu : NGMenuBase
{
  [SerializeField]
  protected UILabel TxtDescription01;
  [SerializeField]
  protected UILabel TxtDescription0324_;
  [SerializeField]
  protected UILabel TxtLastplay;
  [SerializeField]
  protected UILabel TxtPlayername;
  [SerializeField]
  protected UILabel TxtPopuptitle;
  [SerializeField]
  protected UILabel TxtREADME;
  [SerializeField]
  private GameObject LinkUnit;
  [SerializeField]
  protected UILabel TxtLv;
  [SerializeField]
  protected UI2DSprite Emblem;
  private GameObject unitIconGo;
  private UnitIcon unitIcon;

  [DebuggerHidden]
  public IEnumerator SetTargetUserData()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend00816Menu.\u003CSetTargetUserData\u003Ec__Iterator51A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetTargetUserData(WebAPI.Response.PlayerSearch result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend00816Menu.\u003CSetTargetUserData\u003Ec__Iterator51B()
    {
      result = result,
      \u003C\u0024\u003Eresult = result,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnPopupOk() => Debug.Log((object) "click default event IbtnPopupOk");
}
