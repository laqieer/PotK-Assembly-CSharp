// Decompiled with JetBrains decompiler
// Type: Friend00816Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Friend00816Menu.\u003CSetTargetUserData\u003Ec__Iterator4CB()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetTargetUserData(WebAPI.Response.PlayerSearch result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend00816Menu.\u003CSetTargetUserData\u003Ec__Iterator4CC()
    {
      result = result,
      \u003C\u0024\u003Eresult = result,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnPopupOk() => Debug.Log((object) "click default event IbtnPopupOk");
}
