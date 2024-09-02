// Decompiled with JetBrains decompiler
// Type: TutorialMessageBox
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class TutorialMessageBox : MonoBehaviour
{
  [SerializeField]
  private UILabel label;
  [SerializeField]
  private GameObject arrow;
  [SerializeField]
  private GameObject[] characters;
  [SerializeField]
  private NGxFaceSprite[] face;
  [SerializeField]
  private GameObject ItemIconRoot;
  private GameObject UniqueIconsPrefab;
  private GameObject effectPrefab;

  public void Init(
    string message,
    int characterIndex,
    bool dispArrow,
    string faceName,
    string itemName,
    int keyId)
  {
    this.label.SetTextLocalize(message);
    this.DispCharacter(characterIndex);
    if (Object.op_Inequality((Object) this.arrow, (Object) null))
      this.arrow.SetActive(dispArrow);
    this.StartCoroutine(this.ChangeItemIcon(itemName, keyId));
    this.StartCoroutine(this.FaceChange(faceName, characterIndex));
  }

  [DebuggerHidden]
  public IEnumerator FaceChange(string faceName, int characterIndex)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialMessageBox.\u003CFaceChange\u003Ec__Iterator66C()
    {
      faceName = faceName,
      characterIndex = characterIndex,
      \u003C\u0024\u003EfaceName = faceName,
      \u003C\u0024\u003EcharacterIndex = characterIndex,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ChangeItemIcon(string itemName, int keyId = 1)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialMessageBox.\u003CChangeItemIcon\u003Ec__Iterator66D()
    {
      itemName = itemName,
      keyId = keyId,
      \u003C\u0024\u003EitemName = itemName,
      \u003C\u0024\u003EkeyId = keyId,
      \u003C\u003Ef__this = this
    };
  }

  private void DispCharacter(int characterIndex)
  {
    for (int index = 0; index < this.characters.Length; ++index)
      this.characters[index].SetActive(index == characterIndex);
  }

  private MasterDataTable.CommonRewardType? GetReward(string itemName)
  {
    string key = itemName;
    if (key != null)
    {
      // ISSUE: reference to a compiler-generated field
      if (TutorialMessageBox.\u003C\u003Ef__switch\u0024map1E == null)
      {
        // ISSUE: reference to a compiler-generated field
        TutorialMessageBox.\u003C\u003Ef__switch\u0024map1E = new Dictionary<string, int>(8)
        {
          {
            "none",
            0
          },
          {
            "kiseki",
            1
          },
          {
            "medal",
            2
          },
          {
            "zeny",
            3
          },
          {
            "key",
            4
          },
          {
            "point",
            5
          },
          {
            "battlemedal",
            6
          },
          {
            "gachaticket",
            7
          }
        };
      }
      int num;
      // ISSUE: reference to a compiler-generated field
      if (TutorialMessageBox.\u003C\u003Ef__switch\u0024map1E.TryGetValue(key, out num))
      {
        switch (num)
        {
          case 0:
            return new MasterDataTable.CommonRewardType?();
          case 1:
            return new MasterDataTable.CommonRewardType?(MasterDataTable.CommonRewardType.coin);
          case 2:
            return new MasterDataTable.CommonRewardType?(MasterDataTable.CommonRewardType.medal);
          case 3:
            return new MasterDataTable.CommonRewardType?(MasterDataTable.CommonRewardType.money);
          case 4:
            return new MasterDataTable.CommonRewardType?(MasterDataTable.CommonRewardType.quest_key);
          case 5:
            return new MasterDataTable.CommonRewardType?(MasterDataTable.CommonRewardType.friend_point);
          case 6:
            return new MasterDataTable.CommonRewardType?(MasterDataTable.CommonRewardType.battle_medal);
          case 7:
            return new MasterDataTable.CommonRewardType?(MasterDataTable.CommonRewardType.gacha_ticket);
        }
      }
    }
    Debug.LogWarning((object) ("ChangeItemIcon アイテム名：" + itemName + "が見つかりませんでした。"));
    return new MasterDataTable.CommonRewardType?();
  }
}
