// Decompiled with JetBrains decompiler
// Type: BattleSkillIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleSkillIcon : IconPrefabBase
{
  public UI2DSprite iconSprite;
  public GameObject unLockIcon;
  public GameObject skillNeedLvIcon;
  public UILabel skillNeedRankTxt;
  public UILabel skillNeedLvTxt;
  public int skillID;

  [DebuggerHidden]
  public IEnumerator Init(BattleskillSkill skill)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleSkillIcon.\u003CInit\u003Ec__Iterator906()
    {
      skill = skill,
      \u003C\u0024\u003Eskill = skill,
      \u003C\u003Ef__this = this
    };
  }

  public void Init(Sprite sprite)
  {
    if (Object.op_Implicit((Object) this.unLockIcon))
      this.unLockIcon.SetActive(false);
    this.iconSprite.sprite2D = sprite;
  }

  public void SetDepth(int value)
  {
    ((Component) this).GetComponent<UIWidget>().depth = value;
    this.iconSprite.depth = value;
  }

  public void DisableNeedDisp()
  {
    this.iconSprite.color = Color.white;
    ((Component) this.skillNeedRankTxt).gameObject.SetActive(false);
    this.skillNeedLvIcon.SetActive(false);
  }

  public void EnableNeedLvIcon(int needLv)
  {
    this.iconSprite.color = new Color(0.3f, 0.3f, 0.3f);
    this.skillNeedLvIcon.SetActive(true);
    this.skillNeedLvTxt.SetTextLocalize(needLv.ToString());
  }

  public void EnableNeedRankIcon(int needRank)
  {
    if (needRank > 0)
    {
      this.iconSprite.color = new Color(0.3f, 0.3f, 0.3f);
      ((Component) this.skillNeedRankTxt).gameObject.SetActive(true);
      this.skillNeedRankTxt.SetTextLocalize(Consts.Lookup("GEAR_RANK_TXT", (IDictionary) new Hashtable()
      {
        {
          (object) "rank",
          (object) needRank
        }
      }));
    }
    else
    {
      this.iconSprite.color = new Color(1f, 1f, 1f);
      ((Component) this.skillNeedRankTxt).gameObject.SetActive(false);
    }
  }
}
