// Decompiled with JetBrains decompiler
// Type: Versus02622Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Versus02622Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel txt_TitleString;
  [SerializeField]
  protected UILabel txt_RecordString01;
  [SerializeField]
  protected UILabel txt_RecordString02;
  [SerializeField]
  protected UILabel txt_RecordString03;
  [SerializeField]
  protected UILabel txt_RecordString04;
  [SerializeField]
  protected UILabel txt_RecordString05;
  [SerializeField]
  protected UILabel txt_RecordString06;
  [SerializeField]
  protected UILabel txt_RecordString07;
  [SerializeField]
  protected UILabel txt_RecordString08;
  [SerializeField]
  protected UILabel txt_RecordString09;
  [SerializeField]
  protected UILabel txt_RecordString10;
  [SerializeField]
  protected UILabel txt_RecordString11;
  [SerializeField]
  protected UILabel txt_RandomRecordNum01;
  [SerializeField]
  protected UILabel txt_RandomRecordNum02;
  [SerializeField]
  protected UILabel txt_RandomRecordNum03;
  [SerializeField]
  protected UILabel txt_RandomRecordNum04;
  [SerializeField]
  protected UILabel txt_RandomRecordNum05;
  [SerializeField]
  protected UILabel txt_RandomRecordNum06;
  [SerializeField]
  protected UILabel txt_RandomRecordNum07;
  [SerializeField]
  protected UILabel txt_RandomRecordNum08;
  [SerializeField]
  protected UILabel txt_RandomRecordNum09;
  [SerializeField]
  protected UILabel txt_RandomRecordNum10;
  [SerializeField]
  protected UILabel txt_RandomRecordNum11;
  [SerializeField]
  protected UILabel txt_FriendRecordNum01;
  [SerializeField]
  protected UILabel txt_FriendRecordNum02;
  [SerializeField]
  protected UILabel txt_FriendRecordNum03;
  [SerializeField]
  protected UILabel txt_FriendRecordNum04;
  [SerializeField]
  protected UILabel txt_FriendRecordNum05;
  [SerializeField]
  protected UILabel txt_FriendRecordNum06;
  [SerializeField]
  protected UILabel txt_FriendRecordNum07;
  [SerializeField]
  protected UILabel txt_FriendRecordNum08;
  [SerializeField]
  protected UILabel txt_FriendRecordNum09;
  [SerializeField]
  protected UILabel txt_FriendRecordNum10;
  [SerializeField]
  protected UILabel txt_FriendRecordNum11;

  [DebuggerHidden]
  public IEnumerator Initialize(PvPRecord randomInfo, PvPRecord friendInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02622Menu.\u003CInitialize\u003Ec__Iterator699()
    {
      randomInfo = randomInfo,
      friendInfo = friendInfo,
      \u003C\u0024\u003ErandomInfo = randomInfo,
      \u003C\u0024\u003EfriendInfo = friendInfo,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();
}
