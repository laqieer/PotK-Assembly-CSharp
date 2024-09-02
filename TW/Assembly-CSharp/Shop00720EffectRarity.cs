// Decompiled with JetBrains decompiler
// Type: Shop00720EffectRarity
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Shop00720EffectRarity : MonoBehaviour
{
  private string seName_;
  [SerializeField]
  private int number_;
  [SerializeField]
  private GameObject[] rarities_ = new GameObject[6];

  public int Number => this.number_;

  public void Init()
  {
    this.seName_ = (string) null;
    foreach (GameObject rarity in this.rarities_)
      rarity.SetActive(false);
  }

  public void setRarity(int rarity)
  {
    --rarity;
    this.rarities_[rarity < 0 || this.rarities_.Length <= rarity ? 0 : rarity].SetActive(true);
  }

  public void setSe(string sename) => this.seName_ = sename;

  public void getItemSoundPlay(int n)
  {
    if (this.number_ != n || string.IsNullOrEmpty(this.seName_))
      return;
    Singleton<NGSoundManager>.GetInstance().playSE(this.seName_);
  }

  public static string SeName(int rarity)
  {
    if (rarity <= 0)
      rarity = 1;
    switch (rarity - 1)
    {
      case 0:
        return "SE_0502";
      case 1:
        return "SE_0503";
      case 2:
        return "SE_0504";
      case 3:
        return "SE_0505";
      default:
        return "SE_0506";
    }
  }
}
