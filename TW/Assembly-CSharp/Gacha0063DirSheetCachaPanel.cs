// Decompiled with JetBrains decompiler
// Type: Gacha0063DirSheetCachaPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Gacha0063DirSheetCachaPanel : MonoBehaviour
{
  private const float ANIM_START_TIME = 0.25f;
  private const float ANIM_DURUTION = 0.5f;
  private const float ANIM_ADD_TIME1 = 0.5f;
  private const float ANIM_ADD_TIME2 = 0.25f;
  [SerializeField]
  private GameObject iBtn_Panel;
  [SerializeField]
  private GameObject dyn_Detail;
  [SerializeField]
  private GameObject dyn_RewardThum;
  [SerializeField]
  private GameObject dir_Amount;
  [SerializeField]
  private GameObject dyn_Point;
  [SerializeField]
  private GameObject SheetPanelsBlacks;
  [SerializeField]
  private GameObject amountDigitX;
  [SerializeField]
  private GameObject[] amountDigit;
  [SerializeField]
  private GameObject[] pointDigit;
  private GameObject effectObject;
  private GameObject hitEffectObject;
  private Popup0063SheetMenu parentObject;
  private MasterDataTable.CommonRewardType rewardType;
  private int rewardID;
  public bool isOpen;
  public bool IsResultEffect;

  private void SentNum(GameObject parent, GameObject[] go, int num)
  {
    int num1 = num;
    ((IEnumerable<GameObject>) go).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(false)));
    if (num1 == -1)
    {
      parent.SetActive(false);
    }
    else
    {
      parent.SetActive(true);
      int length = num.ToString().Length;
      if (length > go.Length)
        return;
      for (int index = 0; index < length; ++index)
      {
        Sprite sprite = Resources.Load<Sprite>("Icons/slc_Number" + (num1 % 10).ToString());
        go[index].GetComponent<UI2DSprite>().sprite2D = sprite;
        UI2DSprite component = go[index].GetComponent<UI2DSprite>();
        Rect textureRect1 = sprite.textureRect;
        int width = (int) ((Rect) ref textureRect1).width;
        Rect textureRect2 = sprite.textureRect;
        int height = (int) ((Rect) ref textureRect2).height;
        component.SetDimensions(width, height);
        go[index].SetActive(true);
        num1 /= 10;
      }
    }
  }

  private void SetAmountDigit(int num)
  {
    this.SentNum(this.dir_Amount, this.amountDigit, num);
    if (num >= 10)
      return;
    this.amountDigitX.transform.position = new Vector3(this.amountDigit[1].transform.position.x, this.amountDigitX.transform.position.y, this.amountDigitX.transform.position.z);
  }

  private void SetPointDigit(int num) => this.SentNum(this.dyn_Point, this.pointDigit, num);

  [DebuggerHidden]
  public IEnumerator Init(
    Popup0063SheetMenu parent,
    GachaG007PlayerPanel panel,
    bool isResultEffect = false,
    GameObject effectPrefab = null,
    GameObject hitEffectPrefab = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063DirSheetCachaPanel.\u003CInit\u003Ec__Iterator434()
    {
      parent = parent,
      panel = panel,
      isResultEffect = isResultEffect,
      effectPrefab = effectPrefab,
      hitEffectPrefab = hitEffectPrefab,
      \u003C\u0024\u003Eparent = parent,
      \u003C\u0024\u003Epanel = panel,
      \u003C\u0024\u003EisResultEffect = isResultEffect,
      \u003C\u0024\u003EeffectPrefab = effectPrefab,
      \u003C\u0024\u003EhitEffectPrefab = hitEffectPrefab,
      \u003C\u003Ef__this = this
    };
  }

  public void SelEffect(float correct)
  {
    this.effectObject.GetComponent<ParticleSystem>().playbackSpeed = 1f;
    this.effectObject.SetActive(false);
    this.effectObject.SetActive(true);
  }

  public void HitEffect()
  {
    this.effectObject.SetActive(false);
    this.hitEffectObject.SetActive(true);
  }

  public void IbtnDetail() => this.StartCoroutine(this.ShowDetailPopup());

  [DebuggerHidden]
  private IEnumerator ShowDetailPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063DirSheetCachaPanel.\u003CShowDetailPopup\u003Ec__Iterator435()
    {
      \u003C\u003Ef__this = this
    };
  }
}
