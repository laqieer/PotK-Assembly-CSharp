// Decompiled with JetBrains decompiler
// Type: Bugu0059Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
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
  private UIButton m_DrillingBtn;
  [SerializeField]
  private UILabel m_ZenyLabel;
  private GameObject m_ItemIconPrefab;
  private GameObject m_SkillIconPrefab;
  private GameObject m_CheckMaterialPopupPrefab;
  private PlayerItem m_Base;
  private PlayerItem m_After;
  private List<PlayerItem> m_Materials = new List<PlayerItem>();
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
    return (IEnumerator) new Bugu0059Menu.\u003ConInitAsync\u003Ec__Iterator352()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartAsync(
    PlayerItem baseGear,
    List<PlayerItem> materials,
    WebAPI.Response.ItemGearDrillingConfirm response,
    Bugu0059Scene scene)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0059Menu.\u003ConStartAsync\u003Ec__Iterator353()
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
  private IEnumerator SetNoResponse(PlayerItem baseGear)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0059Menu.\u003CSetNoResponse\u003Ec__Iterator354()
    {
      baseGear = baseGear,
      \u003C\u0024\u003EbaseGear = baseGear,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetResponse(
    PlayerItem baseGear,
    WebAPI.Response.ItemGearDrillingConfirm response)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0059Menu.\u003CSetResponse\u003Ec__Iterator355()
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
    if (this.m_Base.gear_level == this.m_Base.gear_level_limit)
      Bugu0052Scene.changeSceneSpecialDrillingMaterial(false, true, this.m_Materials, this.m_Base);
    else
      Bugu0052Scene.changeSceneDrillingMaterial(false, true, this.m_Materials, this.m_Base);
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
    return (IEnumerator) new Bugu0059Menu.\u003COpenMaterialCheckPopup\u003Ec__Iterator356()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator drilling()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0059Menu.\u003Cdrilling\u003Ec__Iterator357()
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
