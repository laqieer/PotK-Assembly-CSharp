// Decompiled with JetBrains decompiler
// Type: DetailMenuScrollView04
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class DetailMenuScrollView04 : DetailMenuScrollViewBase
{
  [SerializeField]
  protected UILabel txt_Birthday;
  [SerializeField]
  protected UILabel txt_Birthplace;
  [SerializeField]
  protected UILabel txt_Bloodgroup;
  [SerializeField]
  protected UILabel txt_Interest;
  [SerializeField]
  protected UILabel txt_Favorite;
  [SerializeField]
  protected UILabel txt_Constellation;

  public override bool Init(PlayerUnit playerUnit)
  {
    ((Component) this).gameObject.SetActive(true);
    this.Set(playerUnit.unit.character);
    return true;
  }

  public void Set(UnitCharacter character)
  {
    int result;
    string text;
    if (character.birthday.Length == 4 && int.TryParse(character.birthday, out result))
      text = Consts.Lookup("unit004_2_birthday", (IDictionary) new Hashtable()
      {
        {
          (object) "month",
          (object) this.ToMonth((result / 100).ToString())
        },
        {
          (object) "date",
          (object) (result % 100).ToString()
        }
      });
    else
      text = character.birthday;
    this.txt_Birthday.SetTextLocalize(text);
    this.txt_Birthplace.SetTextLocalize(character.origin);
    this.txt_Bloodgroup.SetTextLocalize(character.blood_type);
    this.txt_Interest.SetTextLocalize(character.hobby);
    this.txt_Favorite.SetTextLocalize(character.favorite);
    this.txt_Constellation.SetTextLocalize(character.zodiac_sign);
  }

  private string ToMonth(string str)
  {
    string key = str;
    if (key != null)
    {
      // ISSUE: reference to a compiler-generated field
      if (DetailMenuScrollView04.\u003C\u003Ef__switch\u0024map25 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DetailMenuScrollView04.\u003C\u003Ef__switch\u0024map25 = new Dictionary<string, int>(12)
        {
          {
            "1",
            0
          },
          {
            "2",
            1
          },
          {
            "3",
            2
          },
          {
            "4",
            3
          },
          {
            "5",
            4
          },
          {
            "6",
            5
          },
          {
            "7",
            6
          },
          {
            "8",
            7
          },
          {
            "9",
            8
          },
          {
            "10",
            9
          },
          {
            "11",
            10
          },
          {
            "12",
            11
          }
        };
      }
      int num;
      // ISSUE: reference to a compiler-generated field
      if (DetailMenuScrollView04.\u003C\u003Ef__switch\u0024map25.TryGetValue(key, out num))
      {
        switch (num)
        {
          case 0:
            return Consts.Lookup("January");
          case 1:
            return Consts.Lookup("February");
          case 2:
            return Consts.Lookup("March");
          case 3:
            return Consts.Lookup("April");
          case 4:
            return Consts.Lookup("May");
          case 5:
            return Consts.Lookup("June");
          case 6:
            return Consts.Lookup("July");
          case 7:
            return Consts.Lookup("August");
          case 8:
            return Consts.Lookup("September");
          case 9:
            return Consts.Lookup("October");
          case 10:
            return Consts.Lookup("November");
          case 11:
            return Consts.Lookup("December");
        }
      }
    }
    return Consts.Lookup("January");
  }
}
