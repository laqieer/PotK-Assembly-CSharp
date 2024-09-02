// Decompiled with JetBrains decompiler
// Type: Gacha0063Kiseki
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class Gacha0063Kiseki : Gacha0063hindicator
{
  [SerializeField]
  private GameObject dyn_Chara;
  [SerializeField]
  private UI2DSprite dyn_Star;
  [SerializeField]
  private BattleSkillIcon dyn_Unit_Skill;
  [SerializeField]
  private GearKindIcon dyn_Weapon;
  [SerializeField]
  private UILabel txt_Title;
  [SerializeField]
  private UILabel txt_pickupSkill_description;
  [SerializeField]
  private UILabel txt_LeaderSkill_description;
  [SerializeField]
  private UILabel txt_JobName;
  [SerializeField]
  private Transform modelLocator;
  [SerializeField]
  private GameObject slc_Kiseki_Bonus;
  private Modified<CoinBonus[]> coinBonus;
  [SerializeField]
  private UI2DSprite TopImg;
  [SerializeField]
  private GameObject NoneTopImgObj;
  [SerializeField]
  private UIWidget charactersWidget;
  [SerializeField]
  private Gacha0063KisekiExtention kisekiEx;
  [Header("恒常ガチャ")]
  [SerializeField]
  private GameObject SteadyObj;
  [SerializeField]
  private GameObject SteadyNormalGacha;
  [SerializeField]
  private GachaButton SteadyNormalGachaButton;
  [SerializeField]
  private GachaButton SteadyNormalMultiGachaButton;
  [SerializeField]
  private GameObject SteadyCompensationGacha;
  [SerializeField]
  private GachaButton SteadyCompensationGachaButton;
  [SerializeField]
  private GameObject SteadyCoinButton;
  [SerializeField]
  private UI2DSprite SteadyCoinIcon;
  [SerializeField]
  private List<UIWidget> SteadyTweenWidgetList;
  [Header("ガチャボタン上部のテキスト")]
  [SerializeField]
  private GameObject SteadyNoticeObject;
  [SerializeField]
  private UILabel SteadyNoticeText;
  private UI3DModel ui3DModel;
  private int pickupUnitIdNumber;
  private List<int> pickupUnitIdList;
  private List<GameObject> imagePrefabList;
  private List<UnityEngine.Sprite> spriteList;
  private bool gachaExFlag;
  private bool gachaIntroduction;
  private DateTime? serverTime;
  private bool SteadyFadeOutPlay;
  private bool SteadyFadeInPlay;
  private const float FadeOutWaitTime = 5f;
  private float FadeOutWaitTimer = 5f;
  private bool Create3dModel;
  private bool CreateCharacterImageEnd;
  private bool CreateSkillImageEnd;
  private int CreateModelId = -1;
  private Texture2D CommonBgTexture;
  [SerializeField]
  private List<Gacha0063NoCoinObject> NoCoinObject;
  [SerializeField]
  private Gacha0063NoCoinObject TopImgMove;

  private void Start()
  {
    this.coinBonus = SMManager.Observe<CoinBonus[]>();
    this.coinBonus.NotifyChanged();
  }

  public override void PlayAnim()
  {
  }

  public override void EndAnim()
  {
  }

  private void MultiGachBtnSettinng(GachaModule gachaModule)
  {
    this.SteadyObj.SetActive(true);
    if (gachaModule.gacha[0].payment_type_id == Gacha0063Menu.PaymentTypeIDCompensation)
    {
      this.SteadyNormalGacha.SetActive(false);
      this.SteadyCompensationGacha.SetActive(true);
      this.SteadyCompensationGachaButton.Init(gachaModule.name, gachaModule.gacha[0], this.Menu, gachaModule.type, gachaModule.number, gachaModule);
      this.SteadyCompensationGachaButton.ChangeButtonEvent(this.GachaModule);
    }
    else
    {
      this.SteadyNormalGacha.SetActive(true);
      this.SteadyCompensationGacha.SetActive(false);
      this.SteadyNormalGachaButton.Init(gachaModule.name, gachaModule.gacha[0], this.Menu, gachaModule.type, gachaModule.number, gachaModule);
      this.SteadyNormalGachaButton.ChangeButtonEvent(this.GachaModule);
      this.SteadyNormalMultiGachaButton.Init(gachaModule.name, gachaModule.gacha[1], this.Menu, gachaModule.type, gachaModule.number, gachaModule);
      this.SteadyNormalMultiGachaButton.ChangeButtonEvent(this.GachaModule);
    }
    this.SetCoin(gachaModule.gacha[0].common_ticket_id);
  }

  public override void InitGachaModuleGacha(
    Gacha0063Menu gacha0063Menu,
    GachaModule gachaModule,
    DateTime serverTime,
    UIScrollView scrollView,
    int prefabCount)
  {
    this.GachaModule = gachaModule;
    this.Menu = gacha0063Menu;
    this.serverTime = new DateTime?(serverTime);
    this.PrefabCount = prefabCount;
    this.Uipanel.baseClipRegion = scrollView.gameObject.GetComponent<UIPanel>().baseClipRegion + new Vector4(0.0f, 0.0f, 0.0f, 500f);
    this.Uipanel.ResetAnchors();
    this.Uipanel.baseClipRegion = new Vector4(0.0f, this.Uipanel.baseClipRegion.y, this.Uipanel.baseClipRegion.z, this.Uipanel.baseClipRegion.w);
    this.FadeOutWaitTimer = 5f;
    this.CreateModelId = -1;
    this.Create3dModel = false;
    if (gachaModule.number == 1)
    {
      if (gachaModule.gacha.Length > 1)
        this.MultiGachBtnSettinng(gachaModule);
      else if (gachaModule.gacha[0].payment_type_id == Gacha0063Menu.PaymentTypeIDCompensation)
        this.singleCompensationGachaButton.Init(gachaModule.name, gachaModule.gacha[0], this.Menu, gachaModule.type, gachaModule.number, gachaModule);
      else
        this.singleGachaButton.Init(gachaModule.name, gachaModule.gacha[0], this.Menu, gachaModule.type, gachaModule.number, gachaModule);
      this.gachaExFlag = false;
    }
    else if (gachaModule.gacha.Length > 1)
    {
      this.MultiGachBtnSettinng(gachaModule);
      this.gachaExFlag = false;
    }
    else
    {
      this.kisekiEx.SetKisekiEx(gachaModule, this.Menu);
      this.gachaExFlag = true;
    }
    if (!this.GachaModule.period.display_count_down)
      return;
    this.kisekiEx.SetTimiLimit(this.GachaModule);
  }

  private void Init() => this.pickupUnitIdNumber = -1;

  public override IEnumerator Set(GameObject detailPopup)
  {
    Gacha0063Kiseki gacha0063Kiseki = this;
    if (gacha0063Kiseki.coinBonus != null && gacha0063Kiseki.coinBonus.IsChangedOnce() && gacha0063Kiseki.slc_Kiseki_Bonus != null)
    {
      GameObject slcKisekiBonus = gacha0063Kiseki.slc_Kiseki_Bonus;
      CoinBonus[] coinBonusArray = gacha0063Kiseki.coinBonus.Value;
      int num = coinBonusArray != null ? ((uint) coinBonusArray.Length > 0U ? 1 : 0) : 0;
      slcKisekiBonus.SetActive(num != 0);
    }
    if (!Persist.tutorial.Data.IsFinishTutorial() && gacha0063Kiseki.slc_Kiseki_Bonus != null)
      gacha0063Kiseki.slc_Kiseki_Bonus.SetActive(false);
    bool flag = !string.IsNullOrEmpty(gacha0063Kiseki.GachaModule.front_image_url);
    IEnumerator e;
    if (!PerformanceConfig.GetInstance().IsGachaLowMemory)
    {
      if (flag)
      {
        e = Singleton<NGGameDataManager>.GetInstance().LoadWebImage(gacha0063Kiseki.GachaModule.front_image_url);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
      else
      {
        Future<Texture2D> texFuture = new ResourceObject("Prefabs/BackGround/bg_gacha_Himeisi").Load<Texture2D>();
        e = texFuture.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        gacha0063Kiseki.CommonBgTexture = texFuture.Result;
        texFuture = (Future<Texture2D>) null;
      }
    }
    e = gacha0063Kiseki.kisekiEx.InitDetail(gacha0063Kiseki.GachaModule, detailPopup, gacha0063Kiseki.Menu);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    gacha0063Kiseki.SteadyNoticeObject.SetActive(false);
    if (!string.IsNullOrEmpty(gacha0063Kiseki.GachaModule.gacha[gacha0063Kiseki.GachaModule.gacha.Length - 1].button_text))
    {
      gacha0063Kiseki.SteadyNoticeObject.SetActive(true);
      gacha0063Kiseki.SteadyNoticeText.text = gacha0063Kiseki.GachaModule.gacha[gacha0063Kiseki.GachaModule.gacha.Length - 1].button_text;
    }
    gacha0063Kiseki.CreatePickupUnitIdList();
  }

  public override IEnumerator TextureSet()
  {
    Gacha0063Kiseki gacha0063Kiseki = this;
    bool isTopImgLoad = false;
    bool isModelCreate = false;
    gacha0063Kiseki.SteadyFadeOutPlay = false;
    gacha0063Kiseki.SteadyFadeInPlay = false;
    for (int index = 0; index < gacha0063Kiseki.SteadyTweenWidgetList.Count; ++index)
      gacha0063Kiseki.SteadyTweenWidgetList[index].alpha = 0.0f;
    IEnumerator e;
    if (!string.IsNullOrEmpty(gacha0063Kiseki.GachaModule.front_image_url))
    {
      isTopImgLoad = true;
      e = Singleton<NGGameDataManager>.GetInstance().GetWebImage(gacha0063Kiseki.GachaModule.front_image_url, gacha0063Kiseki.TopImg);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      gacha0063Kiseki.TopImg.gameObject.SetActive(true);
      if ((double) gacha0063Kiseki.TopImg.localSize.x / (double) gacha0063Kiseki.TopImg.localSize.y >= 1.0)
        gacha0063Kiseki.SetOldGacha();
    }
    else if (gacha0063Kiseki.gachaExFlag)
    {
      gacha0063Kiseki.TopImg.sprite2D = (UnityEngine.Sprite) null;
      e = gacha0063Kiseki.CashClean();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
    if (gacha0063Kiseki.pickupUnitIdList != null && gacha0063Kiseki.pickupUnitIdList.Count > 0 && (UnityEngine.Object) gacha0063Kiseki.ui3DModel == (UnityEngine.Object) null)
    {
      gacha0063Kiseki.dyn_Star.gameObject.SetActive(false);
      gacha0063Kiseki.txt_Title.gameObject.SetActive(false);
      gacha0063Kiseki.dyn_Unit_Skill.gameObject.SetActive(false);
      gacha0063Kiseki.dyn_Weapon.gameObject.SetActive(false);
      gacha0063Kiseki.txt_pickupSkill_description.gameObject.SetActive(false);
      gacha0063Kiseki.txt_LeaderSkill_description.gameObject.SetActive(false);
      gacha0063Kiseki.txt_JobName.gameObject.SetActive(false);
      if (!isTopImgLoad)
      {
        if (!PerformanceConfig.GetInstance().IsGachaLowMemory)
        {
          if ((UnityEngine.Object) gacha0063Kiseki.CommonBgTexture == (UnityEngine.Object) null)
          {
            yield break;
          }
          else
          {
            gacha0063Kiseki.CommonBgTexture.wrapMode = TextureWrapMode.Clamp;
            float width = (float) gacha0063Kiseki.CommonBgTexture.width;
            float height = (float) gacha0063Kiseki.CommonBgTexture.height;
            gacha0063Kiseki.TopImg.sprite2D = UnityEngine.Sprite.Create(gacha0063Kiseki.CommonBgTexture, new Rect(0.0f, 0.0f, width, height), new Vector2(0.0f, 0.0f), 100f, 0U, SpriteMeshType.FullRect);
            gacha0063Kiseki.TopImg.SetDimensions((int) width, (int) height);
            gacha0063Kiseki.TopImg.gameObject.SetActive(true);
          }
        }
        else
        {
          gacha0063Kiseki.TopImg.gameObject.SetActive(false);
          Future<Texture2D> texFuture = new ResourceObject("Prefabs/BackGround/bg_gacha_Himeisi").Load<Texture2D>();
          e = texFuture.Wait();
          while (e.MoveNext())
            yield return e.Current;
          e = (IEnumerator) null;
          Texture2D result = texFuture.Result;
          if ((UnityEngine.Object) result == (UnityEngine.Object) null)
          {
            yield break;
          }
          else
          {
            result.wrapMode = TextureWrapMode.Clamp;
            float width = (float) result.width;
            float height = (float) result.height;
            gacha0063Kiseki.TopImg.sprite2D = UnityEngine.Sprite.Create(result, new Rect(0.0f, 0.0f, width, height), new Vector2(0.0f, 0.0f), 100f, 0U, SpriteMeshType.FullRect);
            gacha0063Kiseki.TopImg.SetDimensions((int) width, (int) height);
            gacha0063Kiseki.TopImg.gameObject.SetActive(true);
            texFuture = (Future<Texture2D>) null;
          }
        }
      }
      e = gacha0063Kiseki.CreateCharacterImage();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      gacha0063Kiseki.StartCoroutine(gacha0063Kiseki.CreateSkillImage());
      isModelCreate = true;
    }
    gacha0063Kiseki.gachaIntroduction = !string.IsNullOrEmpty(gacha0063Kiseki.GachaModule.front_image_url) && (uint) gacha0063Kiseki.GachaModule.newentity.Length > 0U;
    if (string.IsNullOrEmpty(gacha0063Kiseki.GachaModule.front_image_url) && gacha0063Kiseki.GachaModule.newentity.Length == 0)
    {
      Debug.LogError((object) "注目ユニットも、フロント画像も無いので　画面が正常に表示されません");
    }
    else
    {
      while (!(!gacha0063Kiseki.gachaIntroduction & isTopImgLoad) && (gacha0063Kiseki.imagePrefabList.Count <= 0 || gacha0063Kiseki.spriteList.Count <= 0) && (!gacha0063Kiseki.CreateCharacterImageEnd || !gacha0063Kiseki.CreateSkillImageEnd))
        yield return (object) null;
      if (gacha0063Kiseki.gachaIntroduction)
        gacha0063Kiseki.ChangeTopImg();
      else if (gacha0063Kiseki.GachaModule.newentity.Length != 0 && isModelCreate)
      {
        gacha0063Kiseki.ChangeCharacterImage(gacha0063Kiseki.pickupUnitIdNumber);
        gacha0063Kiseki.SetStatus(gacha0063Kiseki.pickupUnitIdList[gacha0063Kiseki.pickupUnitIdNumber]);
        gacha0063Kiseki.ChangeSkillIcon(gacha0063Kiseki.pickupUnitIdNumber);
      }
      else if (isTopImgLoad && (bool) (UnityEngine.Object) gacha0063Kiseki.NoneTopImgObj)
        gacha0063Kiseki.NoneTopImgObj.SetActive(false);
    }
  }

  public override void TextureClear()
  {
    this.StopCoroutine("ChangeCharacter");
    this.StopCoroutine("Creare3dModelReset");
    if ((UnityEngine.Object) this.TopImg.sprite2D != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.TopImg.sprite2D);
      this.TopImg.sprite2D = (UnityEngine.Sprite) null;
    }
    if (!string.IsNullOrEmpty(this.GachaModule.front_image_url) && PerformanceConfig.GetInstance().IsGachaLowMemory)
      Singleton<NGGameDataManager>.GetInstance().webImageCache.Remove(this.GachaModule.front_image_url);
    if (this.imagePrefabList != null)
    {
      foreach (GameObject imagePrefab in this.imagePrefabList)
        UnityEngine.Object.Destroy((UnityEngine.Object) imagePrefab.gameObject);
      this.imagePrefabList.Clear();
    }
    this.imagePrefabList = (List<GameObject>) null;
    this.imagePrefabList = new List<GameObject>();
    if ((UnityEngine.Object) this.ui3DModel != (UnityEngine.Object) null)
    {
      if ((UnityEngine.Object) this.ui3DModel.ModelCamera != (UnityEngine.Object) null)
        this.ui3DModel.ModelCamera.enabled = false;
      this.ui3DModel.Remove();
      UnityEngine.Object.Destroy((UnityEngine.Object) this.ui3DModel.gameObject);
      this.ui3DModel = (UI3DModel) null;
    }
    this.pickupUnitIdNumber = 0;
    this.SteadyFadeOutPlay = false;
    this.SteadyFadeInPlay = false;
    this.Create3dModel = false;
    this.CreateModelId = -1;
    this.FadeOutWaitTimer = 5f;
    for (int index = 0; index < this.SteadyTweenWidgetList.Count; ++index)
      this.SteadyTweenWidgetList[index].alpha = 0.0f;
  }

  public override void ScrollCenterOnFinished()
  {
    if (this.gachaExFlag || this.SteadyFadeOutPlay || this.SteadyFadeInPlay)
      return;
    this.StartCoroutine("Creare3dModelReset");
  }

  private IEnumerator Creare3dModelReset()
  {
    if (this.pickupUnitIdList != null && !this.SteadyFadeInPlay && !this.Create3dModel)
    {
      this.Create3dModel = true;
      if (Singleton<CommonRoot>.GetInstance().isLoading)
        yield return (object) null;
      IEnumerator e = this.CreateCharacterModel();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      e = this.ChangeCharacter(0);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.SteadyFadeInPlay = true;
    }
  }

  private void CreatePickupUnitIdList()
  {
    this.pickupUnitIdList = (List<int>) null;
    this.pickupUnitIdList = new List<int>();
    foreach (GachaModuleNewentity gachaModuleNewentity in this.GachaModule.newentity)
    {
      if (1 == gachaModuleNewentity.reward_type_id || 24 == gachaModuleNewentity.reward_type_id)
        this.pickupUnitIdList.Add(gachaModuleNewentity.reward_id);
    }
  }

  private IEnumerator CreateCharacterImage()
  {
    this.CreateCharacterImageEnd = false;
    UI2DSprite component1 = this.dyn_Chara.GetComponent<UI2DSprite>();
    int depth = component1.depth;
    component1.enabled = false;
    if (this.imagePrefabList != null)
    {
      foreach (GameObject imagePrefab in this.imagePrefabList)
        UnityEngine.Object.Destroy((UnityEngine.Object) imagePrefab.gameObject);
      this.imagePrefabList.Clear();
    }
    this.imagePrefabList = (List<GameObject>) null;
    this.imagePrefabList = new List<GameObject>();
    Future<UnityEngine.Sprite> maskf = Res.GUI._006_3_sozai.mask_Character.Load<UnityEngine.Sprite>();
    IEnumerator e = maskf.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    UnityEngine.Sprite mask = maskf.Result;
    foreach (int pickupUnitId in this.pickupUnitIdList)
    {
      Future<GameObject> prefabf = MasterData.UnitUnit[pickupUnitId].LoadMypage();
      e = prefabf.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      GameObject prefab = prefabf.Result.Clone(this.dyn_Chara.transform);
      Future<UnityEngine.Sprite> imgf = MasterData.UnitUnit[pickupUnitId].LoadSpriteLarge();
      e = imgf.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      UnityEngine.Sprite result = imgf.Result;
      prefab.GetComponent<UIWidget>().depth = depth;
      UI2DSprite component2 = prefab.GetComponent<UI2DSprite>();
      component2.sprite2D = result;
      NGxMaskSpriteWithScale component3 = prefab.GetComponent<NGxMaskSpriteWithScale>();
      component3.yOffsetPixel = -180;
      component3.scale = 0.6f;
      component3.MainUI2DSprite = component2;
      component3.maskTexture = mask.texture;
      component3.enabled = false;
      prefab.SetActive(false);
      this.imagePrefabList.Add(prefab);
      yield return (object) null;
      prefabf = (Future<GameObject>) null;
      prefab = (GameObject) null;
      imgf = (Future<UnityEngine.Sprite>) null;
    }
    this.CreateCharacterImageEnd = true;
  }

  private IEnumerator CreateSkillImage()
  {
    Gacha0063Kiseki gacha0063Kiseki = this;
    gacha0063Kiseki.CreateSkillImageEnd = false;
    if (gacha0063Kiseki.spriteList != null)
    {
      foreach (UnityEngine.Object sprite in gacha0063Kiseki.spriteList)
        UnityEngine.Object.Destroy(sprite);
      gacha0063Kiseki.spriteList.Clear();
    }
    gacha0063Kiseki.spriteList = (List<UnityEngine.Sprite>) null;
    gacha0063Kiseki.spriteList = new List<UnityEngine.Sprite>();
    foreach (int pickupUnitId in gacha0063Kiseki.pickupUnitIdList)
    {
      UnitUnit unit_data = MasterData.UnitUnit[pickupUnitId];
      if (unit_data.PickupSkill != null)
      {
        UnityEngine.Sprite sprite;
        if (unit_data.PickupSkill.skill_type != BattleskillSkillType.magic)
        {
          Future<UnityEngine.Sprite> ft = unit_data.PickupSkill.LoadBattleSkillIcon();
          IEnumerator e = ft.Wait();
          while (e.MoveNext())
            yield return e.Current;
          e = (IEnumerator) null;
          sprite = ft.Result;
          ft = (Future<UnityEngine.Sprite>) null;
        }
        else
        {
          gacha0063Kiseki.Menu.commonElementIcon.Init(unit_data.PickupSkill.element);
          sprite = gacha0063Kiseki.Menu.commonElementIcon.iconSprite.sprite2D;
        }
        if ((UnityEngine.Object) sprite == (UnityEngine.Object) null)
        {
          gacha0063Kiseki.Menu.commonElementIcon.Init(unit_data.PickupSkill.element);
          sprite = gacha0063Kiseki.Menu.commonElementIcon.iconSprite.sprite2D;
          BattleskillSkill pickupSkill = MasterData.UnitUnit[pickupUnitId].PickupSkill;
          Debug.LogError((object) ("スキルID " + (object) pickupSkill.ID + " ユニットID " + (object) pickupUnitId + " ユニット名 " + MasterData.UnitUnit[pickupUnitId].name + " スキル名 " + pickupSkill.name + "の画像がない"));
        }
        gacha0063Kiseki.spriteList.Add(sprite);
        yield return (object) null;
        unit_data = (UnitUnit) null;
      }
    }
    gacha0063Kiseki.CreateSkillImageEnd = true;
  }

  private IEnumerator CreateCharacterModel()
  {
    if (Singleton<CommonRoot>.GetInstance().isLoading)
      yield return (object) null;
    if ((UnityEngine.Object) this.ui3DModel == (UnityEngine.Object) null)
    {
      Future<GameObject> fModel = Res.Prefabs.gacha006_8.slc_3DModel.Load<GameObject>();
      IEnumerator e = fModel.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.ui3DModel = fModel.Result.Clone(this.modelLocator).GetComponent<UI3DModel>();
      this.ui3DModel.GetComponent<UIWidget>().depth = 10;
      this.ui3DModel.GetComponent<UITexture>().enabled = true;
      this.ui3DModel.GetComponent<UIButton>().enabled = false;
      this.ui3DModel.transform.localPosition = new Vector3(60f, 0.0f, 0.0f);
      this.ui3DModel.isNotLotate = true;
      fModel = (Future<GameObject>) null;
    }
  }

  private IEnumerator CashClean()
  {
    GC.Collect();
    GC.WaitForPendingFinalizers();
    Singleton<ResourceManager>.GetInstance().ClearCache();
    AsyncOperation asyncOP = Resources.UnloadUnusedAssets();
    while (!asyncOP.isDone)
      yield return (object) null;
  }

  private void SetOldGacha()
  {
    this.TopImgMove.transform.localPosition = this.TopImgMove.noCoinPosition;
    this.kisekiEx.SetOldGacha();
  }

  public static IEnumerator createPaymentIcon(UI2DSprite icon, int payment_type_id)
  {
    string path;
    switch (payment_type_id)
    {
      case 1:
        path = "Icons/Kiseki_Icon";
        break;
      case 2:
        path = "Icons/Zeny_Icon";
        break;
      case 3:
        path = "Icons/Item_Icon_Medal";
        break;
      case 4:
        path = "Icons/ManaPoint_Icon";
        break;
      case 5:
        path = "Icons/GachaTicket_Icon";
        break;
      case 6:
        path = "Icons/BattleMedal_Icon";
        break;
      case 8:
        path = "Icons/Item_Icon_TowerMedal";
        break;
      case 9:
        path = "Icons/Kiseki_Icon";
        break;
      case 10:
        path = "Icons/GuildMedal_Icon";
        break;
      default:
        path = "Icons/Common_Icon";
        break;
    }
    Future<UnityEngine.Sprite> future = Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Sprite>(path);
    IEnumerator e = future.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    icon.sprite2D = future.Result;
    icon.SetDimensions(icon.sprite2D.texture.width, icon.sprite2D.texture.height);
  }

  public override void IbtnBuyKiseki()
  {
    base.IbtnBuyKiseki();
    this.Menu.IbtnBuyKiseki();
    this.StartCoroutine(PopupUtility.BuyKiseki());
  }

  public void IbtnCoin() => this.StartCoroutine(this.Menu.popup_Coin_Detail(this.GachaModule.gacha[0]));

  public IEnumerator ChangeCharacter(int flag)
  {
    if (this.pickupUnitIdList != null)
    {
      if (this.pickupUnitIdNumber >= this.pickupUnitIdList.Count)
      {
        this.pickupUnitIdNumber = 0;
        if (this.gachaIntroduction)
        {
          this.ChangeTopImg();
          yield break;
        }
      }
      if ((bool) (UnityEngine.Object) this.NoneTopImgObj)
        this.NoneTopImgObj.SetActive(true);
      this.ChangeCharacterImage(this.pickupUnitIdNumber);
      if (flag == 1)
      {
        this.SetStatus(this.pickupUnitIdList[this.pickupUnitIdNumber]);
        this.ChangeSkillIcon(this.pickupUnitIdNumber);
      }
      yield return (object) this.CreateModel(this.pickupUnitIdNumber);
      if (flag == 1)
        this.SteadyFadeInPlay = true;
      ++this.pickupUnitIdNumber;
    }
  }

  public void ChangeTopImg()
  {
    if ((bool) (UnityEngine.Object) this.NoneTopImgObj)
      this.NoneTopImgObj.SetActive(false);
    this.TopImg.gameObject.SetActive(true);
    this.imagePrefabList.ForEach((System.Action<GameObject>) (x => x.SetActive(false)));
  }

  private void ChangeCharacterImage(int id) => this.imagePrefabList.ForEachIndex<GameObject>((System.Action<GameObject, int>) ((x, n) => x.SetActive(n == id)));

  private IEnumerator CreateModel(int id)
  {
    if (!((UnityEngine.Object) this.ui3DModel == (UnityEngine.Object) null) && this.pickupUnitIdList != null && this.CreateModelId != id)
    {
      if (Singleton<CommonRoot>.GetInstance().isLoading)
        yield return (object) null;
      IEnumerator e = this.CashClean();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      e = this.ui3DModel.PickUpUnit(MasterData.UnitUnit[this.pickupUnitIdList[id]]);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.CreateModelId = id;
      yield return (object) new WaitForSeconds(0.5f);
      this.ui3DModel.model_creater_.UnitModel.SetActive(true);
    }
  }

  private void ChangeSkillIcon(int id)
  {
    if (this.spriteList.Count<UnityEngine.Sprite>() <= id)
      return;
    this.dyn_Unit_Skill.Init(this.spriteList[id]);
    this.dyn_Unit_Skill.iconSprite.SetDimensions(this.dyn_Unit_Skill.iconSprite.mainTexture.width == 60 ? 60 : 64, this.dyn_Unit_Skill.iconSprite.mainTexture.height == 62 ? 62 : 58);
    this.dyn_Unit_Skill.gameObject.SetActive(true);
  }

  private void SetStatus(int unitId)
  {
    UnitUnit unit = MasterData.UnitUnit[unitId];
    RarityIcon.SetRarity(unit, this.dyn_Star, true);
    this.txt_Title.SetTextLocalize(unit.name);
    this.dyn_Weapon.Init(unit.kind, unit.GetElement());
    this.txt_JobName.SetTextLocalize(unit.job.name.ToConverter());
    BattleskillSkill pickupSkill = unit.PickupSkill;
    if (pickupSkill != null)
      this.txt_pickupSkill_description.SetTextLocalize(pickupSkill.description.ToConverter());
    else
      this.txt_pickupSkill_description.text = string.Empty;
    BattleskillSkill rememberLeaderSkill = unit.RememberLeaderSkill;
    if (rememberLeaderSkill != null)
      this.txt_LeaderSkill_description.SetTextLocalize(rememberLeaderSkill.description.ToConverter());
    else
      this.txt_LeaderSkill_description.text = string.Empty;
    this.dyn_Star.gameObject.SetActive(true);
    this.txt_Title.gameObject.SetActive(true);
    this.dyn_Weapon.gameObject.SetActive(true);
    this.txt_pickupSkill_description.gameObject.SetActive(true);
    this.txt_LeaderSkill_description.gameObject.SetActive(true);
    this.txt_JobName.gameObject.SetActive(true);
  }

  private void LateUpdate()
  {
    if (this.coinBonus != null && Persist.tutorial.Data.IsFinishTutorial() && (this.coinBonus.IsChangedOnce() && this.slc_Kiseki_Bonus != null))
    {
      GameObject slcKisekiBonus = this.slc_Kiseki_Bonus;
      CoinBonus[] coinBonusArray = this.coinBonus.Value;
      int num = coinBonusArray != null ? ((uint) coinBonusArray.Length > 0U ? 1 : 0) : 0;
      slcKisekiBonus.SetActive(num != 0);
    }
    if (this.serverTime.HasValue && this.GachaModule.period.end_at.HasValue)
      this.serverTime = new DateTime?(ServerTime.NowAppTimeAddDelta());
    if (this.GachaModule != null && this.GachaModule.period.display_count_down)
      this.kisekiEx.UpdateLimitTime(this.GachaModule, this.serverTime.Value);
    if (!this.Menu.scene.IsCenterCheck(this.PrefabCount))
      return;
    if (this.SteadyFadeOutPlay)
    {
      this.SteadyFadeOutStart();
    }
    else
    {
      if (!this.SteadyFadeInPlay)
        return;
      this.SteadyFadeInStart();
    }
  }

  private void SteadyFadeOutStart()
  {
    bool flag = true;
    for (int index = 0; index < this.SteadyTweenWidgetList.Count; ++index)
    {
      if ((double) this.SteadyTweenWidgetList[index].alpha > 0.0)
        this.SteadyTweenWidgetList[index].alpha -= 1f * Time.deltaTime;
      if ((double) this.SteadyTweenWidgetList[index].alpha >= 0.0)
        flag = false;
    }
    if (!flag)
      return;
    for (int index = 0; index < this.SteadyTweenWidgetList.Count; ++index)
      this.SteadyTweenWidgetList[index].alpha = 0.0f;
    this.SteadyFadeOutPlay = false;
    this.StartCoroutine("ChangeCharacter", (object) 1);
  }

  private void SteadyFadeInStart()
  {
    for (int index = 0; index < this.SteadyTweenWidgetList.Count; ++index)
    {
      if ((double) this.SteadyTweenWidgetList[index].alpha < 1.0)
        this.SteadyTweenWidgetList[index].alpha += 1f * Time.deltaTime;
    }
    if ((double) this.SteadyTweenWidgetList[0].alpha >= 1.0)
      this.FadeOutWaitTimer -= 1f * Time.deltaTime;
    if ((double) this.FadeOutWaitTimer > 0.0)
      return;
    for (int index = 0; index < this.SteadyTweenWidgetList.Count; ++index)
      this.SteadyTweenWidgetList[index].alpha = 1f;
    this.SteadyFadeInPlay = false;
    this.SteadyFadeOutPlay = true;
    this.FadeOutWaitTimer = 5f;
  }

  private void SetCoin(int? common_ticket_id)
  {
    int ticket_id = !common_ticket_id.HasValue ? 0 : common_ticket_id.Value;
    if (ticket_id == 0)
    {
      this.SteadyCoinButton.SetActive(false);
      foreach (Gacha0063NoCoinObject gacha0063NoCoinObject in this.NoCoinObject)
        gacha0063NoCoinObject.transform.localPosition = gacha0063NoCoinObject.noCoinPosition;
    }
    else
    {
      this.StartCoroutine(this.SetCoinIcon(ticket_id));
      this.SteadyCoinButton.SetActive(true);
    }
  }

  private IEnumerator SetCoinIcon(int ticket_id)
  {
    if (!MasterData.CommonTicket.ContainsKey(ticket_id))
    {
      Debug.LogError((object) "id:{0}のcommon_ticketが存在しません。".F((object) ticket_id));
    }
    else
    {
      Future<UnityEngine.Sprite> future = MasterData.CommonTicket[ticket_id].LoadIconMSpriteF();
      IEnumerator e = future.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.SteadyCoinIcon.sprite2D = future.Result;
    }
  }
}
