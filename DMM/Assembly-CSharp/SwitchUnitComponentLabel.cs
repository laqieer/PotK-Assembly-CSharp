﻿// Decompiled with JetBrains decompiler
// Type: SwitchUnitComponentLabel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SwitchUnitComponentLabel : SwitchUnitComponentBase
{
  [Header("通常ユニット文言Label")]
  public string defaultUnitText;
  [Header("魔法少女まどかマギカ文言Label")]
  public string madomagiUnitText;
  private UILabel label;

  protected override void Init()
  {
    if ((bool) (Object) this.label || !((Object) this.gameObject.GetComponent<UILabel>() != (Object) null))
      return;
    this.materialType = SwitchUnitComponentBase.MATERIALTYPE.Label;
    this.label = this.gameObject.GetComponent<UILabel>();
  }

  public override void SwitchMaterial(int UnitID)
  {
    base.SwitchMaterial(UnitID);
    if (this.currUnitType == SwitchUnitComponentBase.UnitType.DefaultUnit)
    {
      if (this.defaultUnitText.Equals(""))
        return;
      this.label.SetTextLocalize(this.defaultUnitText);
    }
    else
    {
      if (this.madomagiUnitText.Equals(""))
        return;
      this.label.SetTextLocalize(this.madomagiUnitText);
    }
  }
}
