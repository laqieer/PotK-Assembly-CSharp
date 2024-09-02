// Decompiled with JetBrains decompiler
// Type: Popup004ExtraSkillEquipConfirm1Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using UnityEngine;

public class Popup004ExtraSkillEquipConfirm1Menu : BackButtonPopupBase
{
  [SerializeField]
  private ExtraSkillInfo extraSkillInfo;
  private System.Action<PlayerAwakeSkill, PlayerUnit> decideAction;
  private PlayerAwakeSkill targetSkill;
  private PlayerUnit targetUnit;
  private GameObject skillDetailPrefab;

  public IEnumerator Init(
    PlayerAwakeSkill skill,
    PlayerUnit unit,
    System.Action<PlayerAwakeSkill, PlayerUnit> decideAct)
  {
    Popup004ExtraSkillEquipConfirm1Menu equipConfirm1Menu = this;
    equipConfirm1Menu.setTopObject(equipConfirm1Menu.gameObject);
    equipConfirm1Menu.targetSkill = skill;
    equipConfirm1Menu.targetUnit = unit;
    equipConfirm1Menu.decideAction = decideAct;
    IEnumerator e = equipConfirm1Menu.extraSkillInfo.Init(skill, skill.favorite, (UnityEngine.Sprite) null, (GameObject) null);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    if ((UnityEngine.Object) equipConfirm1Menu.skillDetailPrefab == (UnityEngine.Object) null)
    {
      Future<GameObject> loader = PopupSkillDetails.createPrefabLoader(false);
      yield return (object) loader.Wait();
      equipConfirm1Menu.skillDetailPrefab = loader.Result;
      loader = (Future<GameObject>) null;
    }
  }

  public void IbtnDecide()
  {
    if (this.IsPushAndSet())
      return;
    if (this.decideAction != null)
      this.decideAction(this.targetSkill, this.targetUnit);
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public void IbtnCancle()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnCancle();

  public void onClickedSkillZoom()
  {
    if (this.targetSkill == null || (UnityEngine.Object) this.skillDetailPrefab == (UnityEngine.Object) null || this.IsPushAndSet())
      return;
    PopupSkillDetails.show(this.skillDetailPrefab, PopupSkillDetails.Param.createBySkillView(this.targetSkill), onClosed: ((System.Action) (() => this.IsPush = false)));
  }
}
