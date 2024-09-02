﻿// Decompiled with JetBrains decompiler
// Type: Popup02689Effect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using UnityEngine;

#nullable disable
public class Popup02689Effect : MonoBehaviour
{
  private static readonly string[] effectPath = new string[6]
  {
    "Prefabs/versus_result/classdown",
    "Prefabs/versus_result/classstayed",
    "Prefabs/versus_result/classstayed_top",
    "Prefabs/versus_result/classup",
    "Prefabs/versus_result/classup_title",
    "Prefabs/versus_result/classstayed_title"
  };
  private static readonly string[] effectSEName = new string[6]
  {
    "SE_1501",
    "SE_1502",
    "SE_0549",
    "SE_1500",
    "SE_0551",
    "SE_0550"
  };

  public Future<GameObject> StartEffect(PvpClassKind.Condition c)
  {
    return ResourceManager.Load<GameObject>(Popup02689Effect.effectPath[(int) c]);
  }

  public string GetSEName(PvpClassKind.Condition c) => Popup02689Effect.effectSEName[(int) c];
}
