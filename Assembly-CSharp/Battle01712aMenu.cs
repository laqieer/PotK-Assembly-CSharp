// Decompiled with JetBrains decompiler
// Type: Battle01712aMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using UnityEngine;

public class Battle01712aMenu : NGBattleMenuBase
{
  [SerializeField]
  private UILabel txt_name;
  [SerializeField]
  private UILabel txt_balloon;

  private void Awake()
  {
    foreach (Component componentsInChild in this.GetComponentsInChildren<Battle01712aCharaView>(true))
      componentsInChild.gameObject.SetActive(false);
  }

  private IEnumerator doSetSprite(UnitUnit unit, int job_id, int? metamorId)
  {
    Battle01712aMenu battle01712aMenu = this;
    Future<UnityEngine.Sprite> f = unit.LoadSpriteLarge(!metamorId.HasValue || metamorId.Value == 0 ? job_id : metamorId.Value, 1f);
    IEnumerator e = f.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    UnityEngine.Sprite result = f.Result;
    foreach (Battle01712aCharaView componentsInChild in battle01712aMenu.GetComponentsInChildren<Battle01712aCharaView>(true))
    {
      componentsInChild.setSprite(result);
      componentsInChild.gameObject.SetActive(true);
    }
  }

  public void setUnit(BL.Unit unit)
  {
    SkillMetamorphosis metamorphosis = unit.metamorphosis;
    int num = metamorphosis != null ? metamorphosis.metamorphosis_id : 0;
    UnitUnit unit1 = unit.unit;
    this.setText(this.txt_name, unit1.getName(num));
    this.StartCoroutine(this.doSetSprite(unit.unit, unit.playerUnit.job_id, num != 0 ? new int?(num) : new int?()));
    if (!((Object) this.txt_balloon != (Object) null))
      return;
    UnitVoicePattern voicePattern = unit1.getVoicePattern(num);
    this.setText(this.txt_balloon, voicePattern?.dead_message ?? string.Empty);
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    instance.playSE("SE_2022");
    instance.playVoiceByID(voicePattern, 76);
  }
}
