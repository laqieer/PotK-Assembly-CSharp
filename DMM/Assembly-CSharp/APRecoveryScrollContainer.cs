﻿// Decompiled with JetBrains decompiler
// Type: APRecoveryScrollContainer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APRecoveryScrollContainer : MonoBehaviour
{
  [SerializeField]
  public UIGrid grid;
  [SerializeField]
  public UIScrollView scrollView;
  [SerializeField]
  public UIScrollBar scrollBar;
  private GameObject APRecoveryItemPrefab;
  private PlayerRecoveryItem[] playerApRecoveryItems;
  private List<Coroutine> loadingCoroutineList = new List<Coroutine>();
  private List<GameObject> loadScrollList = new List<GameObject>();
  private System.Action btnAct;
  private List<int> show_recovery_item_ids = new List<int>()
  {
    1,
    2,
    3
  };

  public void Initialize(GameObject prefab, PlayerRecoveryItem[] apRecoveryItems)
  {
    this.APRecoveryItemPrefab = prefab;
    this.playerApRecoveryItems = apRecoveryItems;
    this.SetVisible(false);
  }

  public void Clear()
  {
    foreach (Coroutine loadingCoroutine in this.loadingCoroutineList)
    {
      if (loadingCoroutine != null)
        this.StopCoroutine(loadingCoroutine);
    }
    this.loadingCoroutineList.Clear();
    foreach (Component component in this.grid.transform)
      UnityEngine.Object.Destroy((UnityEngine.Object) component.gameObject);
    this.grid.transform.Clear();
    this.loadScrollList.Clear();
  }

  public void SetVisible(bool isVisible)
  {
    this.scrollBar.gameObject.SetActive(isVisible);
    this.scrollView.gameObject.SetActive(isVisible);
  }

  public IEnumerator Create()
  {
    APRecoveryScrollContainer recoveryScrollContainer = this;
    recoveryScrollContainer.Clear();
    RecoveryItemAPHeal[] recoveryItemApHealList = MasterData.RecoveryItemAPHealList;
    Player player = SMManager.Get<Player>();
    RecoveryItemAPHeal[] recoveryItemApHealArray = recoveryItemApHealList;
    IEnumerator e;
    for (int index = 0; index < recoveryItemApHealArray.Length; ++index)
    {
      RecoveryItemAPHeal recoveryItemApHeal = recoveryItemApHealArray[index];
      int quantity = 0;
      foreach (PlayerRecoveryItem playerApRecoveryItem in recoveryScrollContainer.playerApRecoveryItems)
      {
        if (playerApRecoveryItem.recovery_item_id == recoveryItemApHeal.ID)
          quantity = playerApRecoveryItem.quantity;
      }
      if (quantity != 0 || recoveryScrollContainer.show_recovery_item_ids.Contains(recoveryItemApHeal.ID))
      {
        e = recoveryScrollContainer.APRecoveryItemPrefab.Clone(recoveryScrollContainer.grid.transform).GetComponent<APRecoveryList>().Init(APRecoveryList.MODE.APRecoveryItem, recoveryItemApHeal, quantity, recoveryScrollContainer.btnAct);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
    }
    recoveryItemApHealArray = (RecoveryItemAPHeal[]) null;
    e = recoveryScrollContainer.APRecoveryItemPrefab.Clone(recoveryScrollContainer.grid.transform).GetComponent<APRecoveryList>().Init(APRecoveryList.MODE.APRecoveryStone, (RecoveryItemAPHeal) null, player.coin, recoveryScrollContainer.btnAct);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    // ISSUE: reference to a compiler-generated method
    recoveryScrollContainer.grid.onReposition = new UIGrid.OnReposition(recoveryScrollContainer.\u003CCreate\u003Eb__12_0);
    recoveryScrollContainer.grid.Reposition();
  }

  public void SetBtnAct(System.Action questChangeScene) => this.btnAct = questChangeScene;
}
