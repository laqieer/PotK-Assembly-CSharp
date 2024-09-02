// Decompiled with JetBrains decompiler
// Type: EffectControllerArmorSythesis
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class EffectControllerArmorSythesis : EffectController
{
  [SerializeField]
  private GameObject is_new_;
  [SerializeField]
  private GameObject animation_root_;
  [SerializeField]
  private GameObject armor_sythesis_prefab_;
  [SerializeField]
  private Transform armor_sythesis_trans_;
  [SerializeField]
  private CommonRarityAnim common_rarity_anim_;
  [SerializeField]
  private ArmorSythesisAnim armor_sythesis_anim_;
  [SerializeField]
  private int rarity;
  [SerializeField]
  private int gear_id_;
  public ArmorSythesis sound_manager_;
  private GameObject AnimationItemIconPrefab;

  private void Awake()
  {
  }

  public void EndSE() => this.sound_manager_.OnRarity();

  [DebuggerHidden]
  private IEnumerator initialize()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectControllerArmorSythesis.\u003Cinitialize\u003Ec__Iterator8F4()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Set(
    List<PlayerItem> thum_list,
    bool is_new,
    PlayerItem result_item,
    GameObject back_button,
    string[] anim_pattern,
    PlayerItem baseItem)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectControllerArmorSythesis.\u003CSet\u003Ec__Iterator8F5()
    {
      back_button = back_button,
      result_item = result_item,
      is_new = is_new,
      thum_list = thum_list,
      baseItem = baseItem,
      anim_pattern = anim_pattern,
      \u003C\u0024\u003Eback_button = back_button,
      \u003C\u0024\u003Eresult_item = result_item,
      \u003C\u0024\u003Eis_new = is_new,
      \u003C\u0024\u003Ethum_list = thum_list,
      \u003C\u0024\u003EbaseItem = baseItem,
      \u003C\u0024\u003Eanim_pattern = anim_pattern,
      \u003C\u003Ef__this = this
    };
  }
}
