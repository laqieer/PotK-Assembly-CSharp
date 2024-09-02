// Decompiled with JetBrains decompiler
// Type: GuildGiftScrollParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    return (IEnumerator) new GuildGiftScrollParts.\u003CInitialize\u003Ec__Iterator7BF()
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
