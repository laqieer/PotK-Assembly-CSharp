// Decompiled with JetBrains decompiler
// Type: BattleUI05BreakDown
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

#nullable disable
public class BattleUI05BreakDown : MonoBehaviour
{
  [SerializeField]
  private UILabel Txt_Point;
  [SerializeField]
  private UILabel Txt_Title;

  public void SetPoint(string title, int point)
  {
    this.Txt_Title.SetTextLocalize(title);
    this.Txt_Point.SetTextLocalize(Consts.Format(Consts.GetInstance().RESULT_RANKING_MENU_POINT, (IDictionary) new Hashtable()
    {
      {
        (object) nameof (point),
        (object) point
      }
    }));
  }

  public void SetSpecialRate(string specialRate)
  {
    this.Txt_Title.SetTextLocalize(Consts.GetInstance().RESULT_RANKING_MENU_RATE_TITLE);
    this.Txt_Point.SetTextLocalize(Consts.Format(Consts.GetInstance().RESULT_RANKING_MENU_RATE, (IDictionary) new Hashtable()
    {
      {
        (object) "rate",
        (object) specialRate
      }
    }));
  }
}
