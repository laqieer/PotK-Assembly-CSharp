// Decompiled with JetBrains decompiler
// Type: BattleUI05BreakDown
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    this.Txt_Point.SetTextLocalize(Consts.Lookup("RESULT_RANKING_MENU_POINT", (IDictionary) new Hashtable()
    {
      {
        (object) nameof (point),
        (object) point
      }
    }));
  }
}
