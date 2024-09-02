// Decompiled with JetBrains decompiler
// Type: PlaySEStateMachineBehaviour
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PlaySEStateMachineBehaviour : StateMachineBehaviour
{
  public string seName;

  public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) => Singleton<NGSoundManager>.GetInstance().playSE(this.seName);
}
