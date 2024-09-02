// Decompiled with JetBrains decompiler
// Type: BattleResultBuguSkillGet
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleResultBuguSkillGet : MonoBehaviour
{
  private bool mIsAdd;
  private System.Action mOnClick;
  [SerializeField]
  private GameObject dyn_Bugu_Thum;
  [SerializeField]
  private GameObject dyn_SkillDetail;
  [SerializeField]
  private Animator anime;
  [SerializeField]
  private UILabel skillNameLabel;
  [SerializeField]
  private UILabel skillDescriptionLabel;
  [SerializeField]
  private Transform skillIconRoot;
  [SerializeField]
  private Transform skillProperty1Root;
  [SerializeField]
  private Transform skillProperty2Root;
  [SerializeField]
  private UILabel txt_skillLv;

  [DebuggerHidden]
  public IEnumerator Init(bool isAdd, GameCore.ItemInfo gear, GearGearSkill skill)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleResultBuguSkillGet.\u003CInit\u003Ec__Iterator963()
    {
      isAdd = isAdd,
      gear = gear,
      skill = skill,
      \u003C\u0024\u003EisAdd = isAdd,
      \u003C\u0024\u003Egear = gear,
      \u003C\u0024\u003Eskill = skill,
      \u003C\u003Ef__this = this
    };
  }

  public void doStart()
  {
    string str = "Bugu_NewSkill_Update";
    if (this.mIsAdd)
      str = "Bugu_NewSkill";
    this.anime.Play(str);
  }

  public void onClick()
  {
    this.mOnClick();
    Singleton<PopupManager>.GetInstance().dismiss();
  }

  public void SetCallback(System.Action f) => this.mOnClick = f;
}
