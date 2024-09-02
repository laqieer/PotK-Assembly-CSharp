// Decompiled with JetBrains decompiler
// Type: DetailMenuScrollView04
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using UnityEngine;

#nullable disable
public class DetailMenuScrollView04 : DetailMenuScrollViewBase
{
  [SerializeField]
  protected UILabel txt_Bust;
  [SerializeField]
  protected UILabel txt_Hip;
  [SerializeField]
  protected UILabel txt_Waist;
  [SerializeField]
  protected UILabel txt_Hight;
  [SerializeField]
  protected UILabel txt_Weight;
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
      text = Consts.Format(Consts.GetInstance().unit004_2_birthday, (IDictionary) new Hashtable()
      {
        {
          (object) "month",
          (object) (result / 100).ToString()
        },
        {
          (object) "date",
          (object) (result % 100).ToString()
        }
      });
    else
      text = character.birthday;
    this.txt_Bust.SetTextLocalize(character.bust);
    this.txt_Hip.SetTextLocalize(character.hip);
    this.txt_Waist.SetTextLocalize(character.waist);
    this.txt_Hight.SetTextLocalize(character.height);
    this.txt_Weight.SetTextLocalize(character.weight);
    this.txt_Birthday.SetTextLocalize(text);
    this.txt_Birthplace.SetTextLocalize(character.origin);
    this.txt_Bloodgroup.SetTextLocalize(character.blood_type);
    this.txt_Interest.SetTextLocalize(character.hobby);
    this.txt_Favorite.SetTextLocalize(character.favorite);
    this.txt_Constellation.SetTextLocalize(character.zodiac_sign);
  }
}
