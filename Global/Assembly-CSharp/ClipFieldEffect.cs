// Decompiled with JetBrains decompiler
// Type: ClipFieldEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class ClipFieldEffect : BattleMonoBehaviour
{
  private NGSoundManager soundManager;
  private BL.Unit target;
  private GameObject[] prefabs;

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ClipFieldEffect.\u003CStart_Battle\u003Ec__Iterator81F()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onPlayEffect(string var)
  {
    int index = int.Parse(var);
    if (this.target == null || index >= this.prefabs.Length)
      return;
    this.battleManager.battleEffects.fieldEffectsStart(this.prefabs[index], this.target);
  }

  public void onPlayBGM(string var) => this.soundManager.playBGM(var);

  public void onPlaySE(string var) => this.soundManager.playSE(var);

  public void onAnimationTrigger(string var)
  {
    if (this.target == null)
      return;
    this.env.unitResource[this.target].gameObject.GetComponent<UnitUpdate>().setAnimationTrigger(var);
  }

  public void onEndEffect() => this.battleManager.battleEffects.onPopupDismiss();

  public void setEffectData(BL.FieldEffect effect)
  {
    if (Object.op_Equality((Object) this.battleManager, (Object) null))
      this.battleManager = Singleton<NGBattleManager>.GetInstance();
    this.prefabs = this.battleManager.battleEffects.effectResourceAllPrefabs(effect);
    if (effect.fieldEffect.category == BattleFieldEffectCategory.boss)
      this.target = this.env.core.getBossUnit();
    else
      this.target = (BL.Unit) null;
  }
}
