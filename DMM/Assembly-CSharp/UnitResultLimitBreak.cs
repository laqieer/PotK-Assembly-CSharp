﻿// Decompiled with JetBrains decompiler
// Type: UnitResultLimitBreak
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[Serializable]
public class UnitResultLimitBreak
{
  public GameObject LBIconNone;
  public GameObject LBIconBule;
  public GameObject LBIconBuleEffect;

  public void OnOff(bool isOn)
  {
    this.LBIconNone.SetActive(!isOn);
    this.LBIconBule.SetActive(isOn);
    this.LBIconBuleEffect.SetActive(isOn);
  }
}
