// Decompiled with JetBrains decompiler
// Type: Battle01712aMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01712aMenu : NGBattleMenuBase
{
  [SerializeField]
  private UILabel txt_name;
  [SerializeField]
  private UILabel txt_balloon;

  private void Awake()
  {
    foreach (Component componentsInChild in ((Component) this).GetComponentsInChildren<Battle01712aCharaView>(true))
      componentsInChild.gameObject.SetActive(false);
  }

  [DebuggerHidden]
  private IEnumerator doSetSprite(UnitUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01712aMenu.\u003CdoSetSprite\u003Ec__Iterator7C0()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  public void setUnit(BL.Unit unit)
  {
    this.setText(this.txt_name, unit.unit.name);
    if (Object.op_Inequality((Object) this.txt_balloon, (Object) null))
      this.setText(this.txt_balloon, unit.unit.unitVoicePattern.dead_message);
    this.StartCoroutine(this.doSetSprite(unit.unit));
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (!Object.op_Inequality((Object) this.txt_balloon, (Object) null))
      return;
    instance.playSE("SE_2022");
    instance.playVoiceByID(unit.unit.unitVoicePattern.file_name, 76);
  }
}
