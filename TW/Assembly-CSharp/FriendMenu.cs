// Decompiled with JetBrains decompiler
// Type: FriendMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class FriendMenu : ResultMenuBase
{
  private int incr_friend_point;
  private PlayerHelper helper;
  private Gladiator gladiator;
  private bool isFriend;
  private bool isGladiator;
  private bool isHelper;
  [SerializeField]
  private UIButton touchToNext;
  private bool toNext;

  [DebuggerHidden]
  public override IEnumerator Init(GameCore.BattleInfo info, BattleEnd result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new FriendMenu.\u003CInit\u003Ec__IteratorBDB()
    {
      result = result,
      \u003C\u0024\u003Eresult = result,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Init(
    ColosseumUtility.Info info,
    ResultMenuBase.Param param,
    Gladiator gladiator)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new FriendMenu.\u003CInit\u003Ec__IteratorBDC()
    {
      gladiator = gladiator,
      \u003C\u0024\u003Egladiator = gladiator,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Init(WebAPI.Response.PvpPlayerFinish info)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new FriendMenu.\u003CInit\u003Ec__IteratorBDD()
    {
      info = info,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Run()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new FriendMenu.\u003CRun\u003Ec__IteratorBDE()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator OnFinish()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    FriendMenu.\u003COnFinish\u003Ec__IteratorBDF finishCIteratorBdf = new FriendMenu.\u003COnFinish\u003Ec__IteratorBDF();
    return (IEnumerator) finishCIteratorBdf;
  }

  [DebuggerHidden]
  private IEnumerator popup0202501()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new FriendMenu.\u003Cpopup0202501\u003Ec__IteratorBE0()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator popup0202502()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new FriendMenu.\u003Cpopup0202502\u003Ec__IteratorBE1()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator popup02349()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new FriendMenu.\u003Cpopup02349\u003Ec__IteratorBE2()
    {
      \u003C\u003Ef__this = this
    };
  }
}
