// Decompiled with JetBrains decompiler
// Type: Startup00010Score
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections.Generic;
using UnityEngine;

public class Startup00010Score : MonoBehaviour
{
  public List<GameObject> score_sprite_list;

  public void SetActive(int number) => this.score_sprite_list.ForEachIndex<GameObject>((System.Action<GameObject, int>) ((x, n) => x.SetActive(n == number)));
}
