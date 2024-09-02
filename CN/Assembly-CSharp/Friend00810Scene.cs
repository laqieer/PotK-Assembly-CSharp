// Decompiled with JetBrains decompiler
// Type: Friend00810Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
  public GameObject goFbInvite;
  [SerializeField]
  private GameObject IbtnBnr;
  [SerializeField]
  private GameObject SlcAttencion;

  public override IEnumerator onInitSceneAsync()
  {
    this.IbtnBnr.SetActive(false);
    this.SlcAttencion.SetActive(false);
    if (Object.op_Inequality((Object) this.goFbInvite, (Object) null))
      this.goFbInvite.SetActive(false);
    this.menu.setTxtId(SMManager.Get<Player>().short_id);
    this.menu.setInpFriendid(string.Empty);
    this.menu.setKeyboardTypeNumber();
    this.menu.SetBtnInviteResp();
    return base.onInitSceneAsync();
  }

  public void update() => this.menu.onChangeInpFriendid();

  [DebuggerHidden]
  protected IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Friend00810Scene.\u003ConStartSceneAsync\u003Ec__Iterator4C2 asyncCIterator4C2 = new Friend00810Scene.\u003ConStartSceneAsync\u003Ec__Iterator4C2();
    return (IEnumerator) asyncCIterator4C2;
  }
}
