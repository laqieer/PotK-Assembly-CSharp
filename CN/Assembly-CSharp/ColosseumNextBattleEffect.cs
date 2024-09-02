// Decompiled with JetBrains decompiler
// Type: ColosseumNextBattleEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ColosseumNextBattleEffect : MonoBehaviour
{
  private Colosseum02346Menu menu;

  public void Init(Colosseum02346Menu menu) => this.menu = menu;

  public void End() => this.menu.EndNextBattleEffect();
}
