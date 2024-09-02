// Decompiled with JetBrains decompiler
// Type: Invite0131Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
