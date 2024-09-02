// Decompiled with JetBrains decompiler
// Type: PopupMapCheckBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class PopupMapCheckBase : BackButtonMonoBehaiviour
{
  private readonly string chipExt = ".png__GUI__battle_mapchip__battle_mapchip_prefab";
  [SerializeField]
  private GameObject map_grid;
  [SerializeField]
  private UIWidget map_base;
  protected List<PopupMapCheckBase.StageFormation> unitFormationList;
  protected List<PopupMapCheckBase.StageFormation> facilityAreaList;
  protected List<PopupMapCheckBase.StageFormation> facilityList;
  private GameObject mapChipPrefab;
  private UIWidget widget;
  private int widgetWidth;
  private int widgetHeight;
  private BattleStage stage;
  protected string formationChipExt;

  private UISprite cloneMapChip(string name, int size, GameObject prefab)
  {
    UISprite component = prefab.CloneAndGetComponent<UISprite>(this.map_grid);
    component.spriteName = name + this.chipExt;
    component.width = size;
    component.height = size;
    component.depth = this.map_base.depth + 1;
    return component;
  }

  private void clonePvPFormation(UISprite targetMap, GameObject prefab)
  {
    UISprite component = prefab.CloneAndGetComponent<UISprite>(targetMap.transform);
    component.spriteName = this.formationChipExt + this.chipExt;
    component.depth = targetMap.depth + 1;
    component.transform.Clear();
    component.width = targetMap.width;
    component.height = targetMap.height;
  }

  protected IEnumerator Init(BattleStage stage)
  {
    this.stage = stage;
    IEnumerator e = this.setupMapChips();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  protected IEnumerator setupMapChips()
  {
    IEnumerator e;
    if ((UnityEngine.Object) this.mapChipPrefab == (UnityEngine.Object) null)
    {
      Future<GameObject> prefabF = Res.Battle_Mapchip.BattleMapChipSprite.Load<GameObject>();
      e = prefabF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.mapChipPrefab = prefabF.Result;
      prefabF = (Future<GameObject>) null;
    }
    e = MasterData.LoadBattleMapLandform(this.stage.map);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    int mapHeight = this.stage.map_height;
    int mapWidth = this.stage.map_width;
    UIGrid component = this.map_grid.GetComponent<UIGrid>();
    if ((UnityEngine.Object) this.widget == (UnityEngine.Object) null)
    {
      this.widget = NGUITools.FindInParents<UIWidget>(this.map_grid);
      this.widgetWidth = this.widget.width;
      this.widgetHeight = this.widget.height;
    }
    else
      component.transform.Clear();
    float b = (float) this.widgetHeight / (float) mapHeight;
    int size = (int) Mathf.Min((float) this.widgetWidth / (float) mapWidth, b);
    string[,] sn = new string[this.stage.map_width, this.stage.map_height];
    this.stage.ApplyLandforms((System.Action<int, int, BattleMapLandform>) ((x, y, landform) => sn[x, y] = "slc_mapchip_" + (object) landform.landform.baseID));
    for (int r = mapHeight - 1; r >= 0; r--)
    {
      for (int c = 0; c < mapWidth; c++)
      {
        if (r >= 0 && r < this.stage.map_height && (c >= 0 && c < this.stage.map_width))
        {
          UISprite targetMap = this.cloneMapChip(sn[c, r], size, this.mapChipPrefab);
          PopupMapCheckBase.StageFormation stageFormation1 = this.unitFormationList.FirstOrDefault<PopupMapCheckBase.StageFormation>((Func<PopupMapCheckBase.StageFormation, bool>) (x => x.offset_x - 1 == c && x.offset_y - 1 == r));
          if (this.unitFormationList.Count > 0 && stageFormation1 != null)
          {
            this.SetChipName(stageFormation1.chipType);
            this.clonePvPFormation(targetMap, this.mapChipPrefab);
          }
          else
          {
            if (this.facilityList != null)
            {
              PopupMapCheckBase.StageFormation stageFormation2 = this.facilityList.FirstOrDefault<PopupMapCheckBase.StageFormation>((Func<PopupMapCheckBase.StageFormation, bool>) (x => x.offset_x - 1 == c && x.offset_y - 1 == r));
              if (this.facilityList.Count > 0 && stageFormation2 != null)
              {
                this.SetChipName(stageFormation2.chipType);
                this.clonePvPFormation(targetMap, this.mapChipPrefab);
                continue;
              }
            }
            if (this.facilityAreaList != null)
            {
              PopupMapCheckBase.StageFormation stageFormation2 = this.facilityAreaList.FirstOrDefault<PopupMapCheckBase.StageFormation>((Func<PopupMapCheckBase.StageFormation, bool>) (x => x.offset_x - 1 == c && x.offset_y - 1 == r));
              if (this.facilityAreaList.Count > 0 && stageFormation2 != null)
              {
                this.SetChipName(stageFormation2.chipType);
                this.clonePvPFormation(targetMap, this.mapChipPrefab);
              }
            }
          }
        }
      }
    }
    component.arrangement = UIGrid.Arrangement.Horizontal;
    component.maxPerLine = mapWidth;
    component.cellHeight = (float) size;
    component.cellWidth = (float) size;
    this.widget.width = size * mapWidth;
    this.widget.height = size * mapHeight;
    component.repositionNow = true;
  }

  protected virtual void SetChipName(PopupMapCheckBase.ChipType type)
  {
  }

  public override void onBackButton()
  {
  }

  public enum ChipType
  {
    Player,
    Enemy,
    OwnArea,
    facility,
    facilityArea,
  }

  public class StageFormation
  {
    public int offset_x;
    public int offset_y;
    public PopupMapCheckBase.ChipType chipType;

    public StageFormation(int offset_x, int offset_y, PopupMapCheckBase.ChipType chipType)
    {
      this.offset_x = offset_x;
      this.offset_y = offset_y;
      this.chipType = chipType;
    }
  }
}
