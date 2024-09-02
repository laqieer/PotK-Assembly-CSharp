// Decompiled with JetBrains decompiler
// Type: Bugu00539Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu00539Menu : BackButtonMenuBase
{
  public Bugu00539Scene scene;
  public EffectControllerArmorSythesis effect;
  [SerializeField]
  private GameObject back_button_;
  private bool is_new_;
  private bool m_bIsBeginAnimation;
  public Touch2NextAuto touchScript;

  private void Awake()
  {
    this.touchScript = ((Component) this).gameObject.AddComponent<Touch2NextAuto>();
  }

  [DebuggerHidden]
  private IEnumerator SkipCurrentAnimation()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00539Menu.\u003CSkipCurrentAnimation\u003Ec__Iterator3A2()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void Update()
  {
    base.Update();
    if (!this.m_bIsBeginAnimation || !Object.op_Implicit((Object) this.effect) || this.effect.isAnimation || this.touchScript.touch2Next.activeSelf)
      return;
    this.touchScript.touch2Next.SetActive(true);
    this.m_bIsBeginAnimation = false;
  }

  public virtual void IbtnBack()
  {
    if (this.effect.isAnimation)
    {
      this.StartCoroutine(this.SkipCurrentAnimation());
    }
    else
    {
      Singleton<NGSoundManager>.GetInstance().stopSE();
      if (!this.scene.sythesisItem.gear.kind.isEquip)
        Bugu00561Scene.changeScene(false, this.scene.sythesisItem, this.scene.sythesisItem.is_new, true);
      else
        Singleton<NGSceneManager>.GetInstance().changeScene("gacha006_11", false, (object) this.is_new_, (object) this.scene.sythesisItem, (object) this.scene.baseItem);
    }
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnStartcomposite()
  {
    Debug.Log((object) "click default event IbtnStartcomposite");
  }

  [DebuggerHidden]
  public IEnumerator SetEffectData(
    List<PlayerItem> num_list,
    bool is_new,
    PlayerItem item_data,
    string[] anim_pattern,
    PlayerItem baseItem)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00539Menu.\u003CSetEffectData\u003Ec__Iterator3A3()
    {
      is_new = is_new,
      num_list = num_list,
      item_data = item_data,
      anim_pattern = anim_pattern,
      baseItem = baseItem,
      \u003C\u0024\u003Eis_new = is_new,
      \u003C\u0024\u003Enum_list = num_list,
      \u003C\u0024\u003Eitem_data = item_data,
      \u003C\u0024\u003Eanim_pattern = anim_pattern,
      \u003C\u0024\u003EbaseItem = baseItem,
      \u003C\u003Ef__this = this
    };
  }
}
