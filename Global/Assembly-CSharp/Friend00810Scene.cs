// Decompiled with JetBrains decompiler
// Type: Friend00810Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Friend00810Scene : NGSceneBase
{
  [SerializeField]
  private UILabel TxtId;
  [SerializeField]
  private UILabel InpFriendid;
  [SerializeField]
  private Friend00810Menu menu;
  [SerializeField]
  private GameObject IbtnBnr;
  [SerializeField]
  private GameObject SlcAttencion;

  public override IEnumerator onInitSceneAsync()
  {
    this.IbtnBnr.SetActive(!WebAPI.LastPlayerBoot.application_review);
    this.SlcAttencion.SetActive(!WebAPI.LastPlayerBoot.application_review);
    this.menu.setTxtId(SMManager.Get<Player>().short_id);
    this.menu.setInpFriendid(string.Empty);
    this.menu.setKeyboardTypeNumber();
    return base.onInitSceneAsync();
  }

  public void update() => this.menu.onChangeInpFriendid();

  [DebuggerHidden]
  protected IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Friend00810Scene.\u003ConStartSceneAsync\u003Ec__Iterator427 asyncCIterator427 = new Friend00810Scene.\u003ConStartSceneAsync\u003Ec__Iterator427();
    return (IEnumerator) asyncCIterator427;
  }
}
