// Decompiled with JetBrains decompiler
// Type: Gacha99951aMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;

#nullable disable
public class Gacha99951aMenu : Quest99951Menu
{
  public override void SetText(
    int haveUnit,
    int max_haveUnit,
    Player player_data,
    bool isTryAgain = false)
  {
    this.isGacha = isTryAgain;
    this.player_data_ = player_data;
    this.TxtPopupdescripton01.SetText(Consts.Format(Consts.GetInstance().GACHA_99951MENU_DESCRIPTION01));
    this.TxtPopupdescripton02.SetText(Consts.Format(Consts.GetInstance().GACHA_99951MENU_DESCRIPTION02));
    this.TxtPopupdescripton03.SetText(Consts.Format(Consts.GetInstance().GACHA_99951MENU_DESCRIPTION03, (IDictionary) new Hashtable()
    {
      {
        (object) "haveunit",
        (object) haveUnit.ToString().ToConverter()
      },
      {
        (object) "maxhaveunit",
        (object) max_haveUnit.ToString().ToConverter()
      }
    }));
    this.TxtTitle.SetText(Consts.Format(Consts.GetInstance().GACHA_99951MENU_DESCRIPTION04));
  }

  public override void onBackButton() => this.IbtnNo();
}
