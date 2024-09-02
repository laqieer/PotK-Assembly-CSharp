// Decompiled with JetBrains decompiler
// Type: Shop00720EffectGetItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Shop00720EffectGetItem : MonoBehaviour
{
  [SerializeField]
  private Shop00720EffectRarity[] rarities_;

  public void getItemSoundPlay(int n) => this.rarities_[n - 1].getItemSoundPlay(n);
}
