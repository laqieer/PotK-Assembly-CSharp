// Decompiled with JetBrains decompiler
// Type: ColosseumRankBattleEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ColosseumRankBattleEffect : MonoBehaviour
{
  private Colosseum02346Menu menu;

  public void Init(Colosseum02346Menu menu) => this.menu = menu;

  public void End() => this.menu.EndRankBattleEffect();
}
