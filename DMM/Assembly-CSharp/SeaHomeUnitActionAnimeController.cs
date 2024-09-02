// Decompiled with JetBrains decompiler
// Type: SeaHomeUnitActionAnimeController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SeaHomeUnitActionAnimeController : StateMachineBehaviour
{
  private SeaHomeUnitController owner;

  public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    this.owner = this.owner ?? animator.transform.parent.gameObject.GetComponent<SeaHomeUnitController>();
    if (!((Object) this.owner != (Object) null) || Random.Range(0, 10000) >= 2000)
      return;
    this.owner.SetLookuped();
  }

  public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    this.owner = this.owner ?? animator.transform.parent.gameObject.GetComponent<SeaHomeUnitController>();
    if (!((Object) this.owner != (Object) null))
      return;
    this.owner.ResetLookuped();
  }
}
