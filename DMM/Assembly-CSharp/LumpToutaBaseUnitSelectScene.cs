﻿// Decompiled with JetBrains decompiler
// Type: LumpToutaBaseUnitSelectScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

[AddComponentMenu("Scenes/Unit/LumpTouta/BaseUnitSelectScene")]
public class LumpToutaBaseUnitSelectScene : NGSceneBase
{
  [SerializeField]
  private LumpToutaBaseUnitSelectMenu menu;

  public override IEnumerator onInitSceneAsync()
  {
    yield return (object) this.menu.Init();
  }
}
