﻿// Decompiled with JetBrains decompiler
// Type: RaidExtraChallengeLAPEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RaidExtraChallengeLAPEffect : MonoBehaviour
{
  public UILabel exNum;

  public void SetNum(int num) => this.exNum.SetText(num.ToString());
}
