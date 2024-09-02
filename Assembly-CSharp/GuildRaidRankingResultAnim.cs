// Decompiled with JetBrains decompiler
// Type: GuildRaidRankingResultAnim
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections.Generic;
using UnityEngine;

public class GuildRaidRankingResultAnim : MonoBehaviour
{
  private const string rankingNumSpriteFormat = "slc_text_{0}.png__GUI__battleUI_05__battleUI_05_prefab";
  [SerializeField]
  private UILabel txtTitle;
  [SerializeField]
  private UISprite[] sprRankingNumber;
  [SerializeField]
  private UIGrid gridDirRanking;
  [SerializeField]
  private UIButton btnTouchToNext;

  public void Initialize(string event_name, int ranking)
  {
    this.setBtnNextEnable(false);
    this.txtTitle.SetTextLocalize(event_name);
    int num1 = 1;
    for (int index = 0; index < this.sprRankingNumber.Length; ++index)
      num1 *= 10;
    int b = num1 - 1;
    ranking = Mathf.Min(ranking, b);
    int num2 = ranking;
    ((IEnumerable<UISprite>) this.sprRankingNumber).ForEach<UISprite>((System.Action<UISprite>) (x => x.gameObject.SetActive(false)));
    for (int index = 0; index < this.sprRankingNumber.Length; ++index)
    {
      this.sprRankingNumber[index].gameObject.SetActive(true);
      this.sprRankingNumber[index].spriteName = "slc_text_{0}.png__GUI__battleUI_05__battleUI_05_prefab".F((object) (num2 % 10));
      num2 /= 10;
      if (num2 <= 0)
        break;
    }
    ((IEnumerable<UISprite>) this.sprRankingNumber).ForEach<UISprite>((System.Action<UISprite>) (x =>
    {
      if (x.gameObject.activeSelf)
        return;
      x.gameObject.SingletonDestory();
      x = (UISprite) null;
    }));
    this.gridDirRanking.Reposition();
  }

  public void setBtnNextEnable(bool flag) => this.btnTouchToNext.enabled = flag;

  public void Close() => Singleton<PopupManager>.GetInstance().dismiss();
}
