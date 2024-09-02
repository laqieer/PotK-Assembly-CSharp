// Decompiled with JetBrains decompiler
// Type: AnimationTrigger
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

#nullable disable
public class AnimationTrigger : BattleMonoBehaviour
{
  public void onAnimationTrigger(string name)
  {
    this.battleManager.getManager<TreasureBoxManager>().cloneMoveEffect();
  }

  public void onBoxOpenTrigger(string name)
  {
    this.battleManager.getManager<TreasureBoxManager>().startEffect();
  }
}
