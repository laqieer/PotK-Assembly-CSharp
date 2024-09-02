// Decompiled with JetBrains decompiler
// Type: Invite0131Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using UnityEngine;

#nullable disable
public class Invite0131Scene : NGSceneBase
{
  [SerializeField]
  private Invite0131Menu menu;

  public override IEnumerator onInitSceneAsync()
  {
    this.menu.setInpId02(SMManager.Get<Player>().short_id);
    this.menu.setInpId01(string.Empty);
    this.menu.setKeyboardTypeNumber();
    return base.onInitSceneAsync();
  }

  public void update() => this.menu.onChangeInpId01();
}
