// Decompiled with JetBrains decompiler
// Type: Bugu0059Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu0059Menu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel m_NameLabel;
  [SerializeField]
  private UI2DSprite m_RaritySprite;
  [SerializeField]
  private GearKindIcon m_GearTypeIcon;
  [SerializeField]
  private UI2DSprite m_ThumSprite;
  [SerializeField]
  private UILabel m_RankLabel;
  [SerializeField]
  private UILabel m_NextRankToLabel;
  [SerializeField]
  private GameObject m_GaugeBeforeNextRankToObject;
  [SerializeField]
  private GameObject m_GaugeAfterNextRankToObject;
  [SerializeField]
  private List<UIWidget> m_SkillIconParentList;
  [SerializeField]
  private List<GameObject> m_SkillEvolutionObjectList;
  [SerializeField]
  private List<GameObject> m_SkillAcquireObjectList;
  private List<BattleSkillIcon> m_SkillIconPrefabList;
  [SerializeField]
  private Bugu0059Menu.Status m_AtkStatus;
  [SerializeField]
  private Bugu0059Menu.Status m_MatkStatus;
  [SerializeField]
  private Bugu0059Menu.Status m_DefStatus;
  [SerializeField]
  private Bugu0059Menu.Status m_MdefStatus;
  [SerializeField]
  private Bugu0059Menu.Status m_HitStatus;
  [SerializeField]
  private Bugu0059Menu.Status m_CrtStatus;
  [SerializeField]
  private Bugu0059Menu.Status m_EvaStatus;
  [SerializeField]
  private List<Bugu0059Menu.MaterialIcon> m_MaterialIconList;
  [SerializeField]
  private SpreadColorButton m_DrillingBtn;
  [SerializeField]
  private UILabel m_ZenyLabel;
  private GameObject m_ItemIconPrefab;
  private GameObject m_SkillIconPrefab;
  private GameObject m_CheckMaterialPopupPrefab;
  private GameCore.ItemInfo m_Base;
  private GameCore.ItemInfo m_After;
  private List<InventoryItem> m_Materials = new List<InventoryItem>();
  private Bugu0059Scene m_ParentScene;
  private static readonly string COLOR_TAG_GREEN = "[00ff00]{0}[-]";
  private static readonly string COLOR_TAG_RED = "[ff0000]{0}[-]";
  private static readonly string COLOR_TAG_YELLOW = "[ffff00]{0}[-]";
  private static string[] spriteNameTBL = new string[6]
  {
    "Prefabs/ItemIcon/Materials/s_star1",
    "Prefabs/ItemIcon/Materials/s_star2",
    "Prefabs/ItemIcon/Materials/s_star3",
    "Prefabs/ItemIcon/Materials/s_star4",
    "Prefabs/ItemIcon/Materials/s_star5",
    "Prefabs/ItemIcon/Materials/s_star6"
  };

  [DebuggerHidden]
  public IEnumerator onInitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0059Menu.\u003ConInitAsync\u003Ec__Iterator3ED()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartAsync(
    GameCore.ItemInfo baseGear,
    List<InventoryItem> materials,
    WebAPI.Response.ItemGearDrillingConfirm response,
    Bugu0059Scene scene)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0059Menu.\u003ConStartAsync\u003Ec__Iterator3EE()
    {
      scene = scene,
      baseGear = baseGear,
      response = response,
      materials = materials,
      \u003C\u0024\u003Escene = scene,
      \u003C\u0024\u003EbaseGear = baseGear,
      \u003C\u0024\u003Eresponse = response,
      \u003C\u0024\u003Ematerials = materials,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetNoResponse(GameCore.ItemInfo baseGear)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0059Menu.\u003CSetNoResponse\u003Ec__Iterator3EF()
    {
      baseGear = baseGear,
      \u003C\u0024\u003EbaseGear = baseGear,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetResponse(
    GameCore.ItemInfo baseGear,
    WebAPI.Response.ItemGearDrillingConfirm response)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0059Menu.\u003CSetResponse\u003Ec__Iterator3F0()
    {
      response = response,
      baseGear = baseGear,
      \u003C\u0024\u003Eresponse = response,
      \u003C\u0024\u003EbaseGear = baseGear,
      \u003C\u003Ef__this = this
    };
  }

  private void SetStatus(Bugu0059Menu.Status status, int baseParam, int upParam = 0)
  {
    if (upParam > 0)
      status.m_ParameterLabel.SetTextLocalize(Bugu0059Menu.COLOR_TAG_YELLOW.F((object) baseParam));
    else if (upParam < 0)
      status.m_ParameterLabel.SetTextLocalize(Bugu0059Menu.COLOR_TAG_RED.F((object) baseParam));
    else
      status.m_ParameterLabel.SetTextLocalize(baseParam);
    if (upParam <= 0)
    {
      status.m_ParameterUpObject.SetActive(false);
    }
    else
    {
      status.m_ParameterUpObject.SetActive(true);
      status.m_ParameterUpLabel.SetTextLocalize(upParam);
    }
  }

  public void ibtnChangeMaterial()
  {
    if (this.IsPushAndSet())
      return;
    if (this.m_Base.gearLevel == this.m_Base.gearLevelLimit)
      Bugu00527Scene.ChangeScene(false, this.m_Materials, this.m_Base, true);
    else
      Bugu00527Scene.ChangeScene(false, this.m_Materials, this.m_Base, false);
  }

  public void ibtnDrilling()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.OpenMaterialCheckPopup());
  }

  [DebuggerHidden]
  private IEnumerator OpenMaterialCheckPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0059Menu.\u003COpenMaterialCheckPopup\u003Ec__Iterator3F1()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator drilling()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0059Menu.\u003Cdrilling\u003Ec__Iterator3F2()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void ibtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.ibtnBack();

  public void callBackScene() => this.backScene();

  private void SetRarity(GearGear gear, UI2DSprite dstSprite)
  {
    if (Object.op_Equality((Object) dstSprite, (Object) null))
      return;
    ((Component) dstSprite).gameObject.SetActive(false);
    if (gear.rarity.index <= 0)
      return;
    Sprite sprite = Resources.Load<Sprite>(Bugu0059Menu.spriteNameTBL[gear.rarity.index - 1]);
    if (!Object.op_Inequality((Object) sprite, (Object) null))
      return;
    dstSprite.sprite2D = sprite;
    UI2DSprite ui2Dsprite = dstSprite;
    Rect textureRect1 = sprite.textureRect;
    int width = (int) ((Rect) ref textureRect1).width;
    Rect textureRect2 = sprite.textureRect;
    int height = (int) ((Rect) ref textureRect2).height;
    ui2Dsprite.SetDimensions(width, height);
    ((Component) dstSprite).gameObject.SetActive(true);
  }

  [Serializable]
  public struct Status
  {
    [SerializeField]
    public UILabel m_ParameterLabel;
    [SerializeField]
    public GameObject m_ParameterUpObject;
    [SerializeField]
    public UILabel m_ParameterUpLabel;
  }

  [Serializable]
  public class MaterialIcon
  {
    [SerializeField]
    public GameObject m_Parent;
    [SerializeField]
    public GameObject m_AddMaterialObject;
    [HideInInspector]
    public ItemIcon m_ItemIcon;
  }
}
