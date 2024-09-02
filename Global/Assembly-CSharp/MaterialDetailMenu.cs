// Decompiled with JetBrains decompiler
// Type: MaterialDetailMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class MaterialDetailMenu : DetailMenuBase
{
  [SerializeField]
  protected UILabel TxtDetaildescription;
  [SerializeField]
  protected UILabel TxtOwnednumber;
  [SerializeField]
  protected UILabel TxtDropQuestName;
  [SerializeField]
  protected UISprite IconEvolution;
  [SerializeField]
  protected UISprite IconUnification;
  [SerializeField]
  protected UISprite IconRevival;
  [SerializeField]
  private UI2DSprite mainSprite;

  [DebuggerHidden]
  public override IEnumerator Init(
    Unit0042Menu menu,
    int index,
    PlayerUnit playerUnit,
    int infoIndex,
    bool isLimit,
    bool isUpdate = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MaterialDetailMenu.\u003CInit\u003Ec__Iterator8BB()
    {
      menu = menu,
      index = index,
      playerUnit = playerUnit,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003Eindex = index,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u003Ef__this = this
    };
  }

  public void changeBackScene() => this.backScene();
}
