// Decompiled with JetBrains decompiler
// Type: GuildGiftScrollParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GuildGiftScrollParts : MonoBehaviour
{
  [SerializeField]
  private CreateIconObject itemIcon;
  [SerializeField]
  private GameObject giftItemPos;
  [SerializeField]
  private GameObject unitIconPos;
  [SerializeField]
  private UILabel playerNameLabel;
  [SerializeField]
  private UILabel itemNameLabel;
  [SerializeField]
  private UILabel LimitTimeLabel;
  [SerializeField]
  private UI2DSprite dynTitle;
  private GuildMemberGift gift;
  private UnitIcon unitIcon;
  [SerializeField]
  private UIButton button;

  public UIButton GetButton() => this.button;

  [DebuggerHidden]
  public IEnumerator Initialize(GuildMemberGift data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildGiftScrollParts.\u003CInitialize\u003Ec__Iterator708()
    {
      data = data,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }

  public void FriendDetailScene(GuildMemberGift data)
  {
    Unit0042Scene.changeSceneFriendUnit(true, data.player.player_id);
  }
}
