// Decompiled with JetBrains decompiler
// Type: Shop00720EffectGetItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Shop00720EffectGetItem : MonoBehaviour
{
  [SerializeField]
  private Shop00720EffectRarity[] rarities_;

  public void getItemSoundPlay(int n) => this.rarities_[n - 1].getItemSoundPlay(n);
}
