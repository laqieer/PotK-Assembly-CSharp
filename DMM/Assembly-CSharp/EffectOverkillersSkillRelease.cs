// Decompiled with JetBrains decompiler
// Type: EffectOverkillersSkillRelease
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using UnityEngine;

public class EffectOverkillersSkillRelease : MonoBehaviour
{
  [Header("淘汰値")]
  [SerializeField]
  private GameObject objUnityBox_;
  [SerializeField]
  private UILabel txtBeforeUnity_;
  [SerializeField]
  private UILabel txtAfterUnity_;
  [Header("スキル")]
  [SerializeField]
  private GameObject objSkillBox_;
  [Header("キャラクター")]
  [SerializeField]
  private UILabel txtCharacterName_;
  [SerializeField]
  private NGTweenParts maskBackground_;
  private GameObject skillPrefab_;
  private PlayerUnit playerUnit_;

  public static Future<GameObject> createLoader() => new ResourceObject("Prefabs/battle/EffectOverkillersSkillRelease").Load<GameObject>();

  public void initialize(
    GameObject skillPrefab,
    PlayerUnit playerUnit,
    bool bMaskBackground,
    int? before_unity = null,
    int? after_unity = null)
  {
    if ((Object) this.objUnityBox_ != (Object) null)
      this.objUnityBox_.SetActive(before_unity.HasValue || after_unity.HasValue);
    this.setValue(this.txtBeforeUnity_, before_unity);
    this.setValue(this.txtAfterUnity_, after_unity);
    this.skillPrefab_ = skillPrefab;
    this.playerUnit_ = playerUnit;
    if (bMaskBackground)
    {
      this.maskBackground_.GetComponent<UIRect>().alpha = 0.0f;
      this.maskBackground_.isActive = true;
    }
    else
      this.maskBackground_.gameObject.SetActive(false);
    this.objSkillBox_.SetActive(false);
  }

  private IEnumerator Start()
  {
    EffectOverkillersSkillRelease overkillersSkillRelease = this;
    UIPanel panel = overkillersSkillRelease.GetComponent<UIPanel>();
    panel.alpha = 0.0f;
    while (overkillersSkillRelease.playerUnit_ == (PlayerUnit) null)
      yield return (object) null;
    GameObject gameObject = overkillersSkillRelease.skillPrefab_.Clone(overkillersSkillRelease.objSkillBox_.transform);
    UIPanel component = gameObject.GetComponent<UIPanel>();
    if ((Object) component != (Object) null)
      component.depth = panel.depth + 1;
    gameObject.GetComponent<EffectSkillAcquisition>().initialize(overkillersSkillRelease.playerUnit_.overkillersSkill.skill);
    overkillersSkillRelease.setCharacter(overkillersSkillRelease.playerUnit_);
    panel.alpha = 1f;
    overkillersSkillRelease.objSkillBox_.SetActive(true);
  }

  private void setCharacter(PlayerUnit playerUnit) => this.txtCharacterName_.SetTextLocalize(playerUnit.unit.name);

  private void setValue(UILabel label, int? value)
  {
    if (!((Object) label != (Object) null))
      return;
    if (value.HasValue)
      label.SetTextLocalize(value.Value.ToString());
    label.gameObject.SetActive(value.HasValue);
  }
}
