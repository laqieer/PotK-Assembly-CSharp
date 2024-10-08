﻿// Decompiled with JetBrains decompiler
// Type: Versus02612RewardTitle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

public class Versus02612RewardTitle : MonoBehaviour
{
  [SerializeField]
  private UI2DSprite title;

  public IEnumerator Init(int id, bool isGuild = false)
  {
    Future<UnityEngine.Sprite> spriteF = (Future<UnityEngine.Sprite>) null;
    spriteF = !isGuild ? EmblemUtility.LoadEmblemSprite(id) : EmblemUtility.LoadGuildEmblemSprite(id);
    IEnumerator e = spriteF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.title.sprite2D = spriteF.Result;
  }
}
