// Decompiled with JetBrains decompiler
// Type: BattleUI05BreakDown
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
}
