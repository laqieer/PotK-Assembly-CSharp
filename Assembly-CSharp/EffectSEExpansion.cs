// Decompiled with JetBrains decompiler
// Type: EffectSEExpansion
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class EffectSEExpansion : MonoBehaviour
{
  private EffectSE effectSE;

  private void Awake() => this.effectSE = this.GetComponent<EffectSE>();

  private void OnDisable()
  {
    if (!(bool) (Object) Singleton<NGSoundManager>.GetInstance() || this.effectSE.UseChannel == -1)
      return;
    Singleton<NGSoundManager>.GetInstance().StopSe(this.effectSE.UseChannel);
  }
}
