// Decompiled with JetBrains decompiler
// Type: Quest00221DetailMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00221DetailMenu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel txtName_;
  [SerializeField]
  private UILabel txtRecommendStrength_;
  [SerializeField]
  private UI2DSprite[] iconKinds_;
  [SerializeField]
  private UI2DSprite[] iconElements_;
  [SerializeField]
  private UI2DSprite[] iconAilments_;
  [SerializeField]
  private GameObject topDropView_;
  [SerializeField]
  private GameObject infoNoDrop_;
  [SerializeField]
  private UIScrollView scroll_;
  [SerializeField]
  private UIGrid grid_;
  [SerializeField]
  private Vector2 scaleDropIcon_ = new Vector2(0.8f, 0.8f);
  [SerializeField]
  private GameObject topSkillDetail_;
  private GameObject prefabElement_;
  private GameObject prefabSkillDetail_;
  private GameObject objSkillDetail_;
  private BattleskillSkill currentSkillDetail_;

  [DebuggerHidden]
  public IEnumerator coInitialize(QuestDetailData data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00221DetailMenu.\u003CcoInitialize\u003Ec__Iterator295()
    {
      data = data,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }

  private void setEventClickedSkillIcon(GameObject go, BattleskillSkill skill)
  {
    EventDelegate.Set(go.GetComponent<UIButton>().onClick, (EventDelegate.Callback) (() =>
    {
      if (this.currentSkillDetail_ == skill && Object.op_Inequality((Object) this.objSkillDetail_, (Object) null) && this.objSkillDetail_.GetComponentInChildren<Battle0171111Event>().DialogConteiner.activeSelf)
        return;
      this.currentSkillDetail_ = skill;
      if (Object.op_Equality((Object) this.objSkillDetail_, (Object) null))
        this.objSkillDetail_ = this.prefabSkillDetail_.Clone(this.topSkillDetail_.transform);
      Battle0171111Event componentInChildren = this.objSkillDetail_.GetComponentInChildren<Battle0171111Event>();
      componentInChildren.setData(skill);
      componentInChildren.enableSkillLv(false);
      componentInChildren.Show();
    }));
  }

  [DebuggerHidden]
  private IEnumerator coCreateDropIcon(QuestDetailData.Drop data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00221DetailMenu.\u003CcoCreateDropIcon\u003Ec__Iterator296()
    {
      data = data,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }

  private Sprite getSpriteGearKind(GearKindEnum eKind)
  {
    string path;
    switch (eKind)
    {
      case GearKindEnum.unique_wepon:
      case GearKindEnum.smith:
      case GearKindEnum.accessories:
      case GearKindEnum.dummy:
      case GearKindEnum.none:
        path = "Icons/Materials/GuideWeaponBtn/slc_unique_wepon_idle";
        break;
      default:
        path = string.Format("Icons/Materials/GuideWeaponBtn/slc_{0}_idle", (object) eKind.ToString());
        break;
    }
    return this.getSprite(path);
  }

  private Sprite getSprite(string path) => Resources.Load<Sprite>(path);

  private void initialize()
  {
    foreach (Component iconKind in this.iconKinds_)
      iconKind.gameObject.SetActive(false);
    foreach (Component iconElement in this.iconElements_)
      iconElement.gameObject.SetActive(false);
    foreach (Component iconAilment in this.iconAilments_)
      iconAilment.gameObject.SetActive(false);
  }

  public override void onBackButton() => this.onClickBack();

  public void onClickBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }
}
