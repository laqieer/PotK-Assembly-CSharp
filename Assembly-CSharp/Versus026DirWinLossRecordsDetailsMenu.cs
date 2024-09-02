// Decompiled with JetBrains decompiler
// Type: Versus026DirWinLossRecordsDetailsMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using UnityEngine;

public class Versus026DirWinLossRecordsDetailsMenu : BackButtonMenuBase
{
  private WebAPI.Response.PvpClassMatchHistoryDetail apiResponse;
  private Versus02613Scene.BootParam param_;
  private Player target_player;
  private GameObject popupInfoPrefab;
  [SerializeField]
  private UILabel txtSceneTitle;
  [Space(10f)]
  [Header("Top")]
  [SerializeField]
  private UILabel txtPlayerNameTop;
  [SerializeField]
  private UILabel txtEnemyNameTop;
  [SerializeField]
  private UILabel txtDate;
  [SerializeField]
  private UILabel txtTime;
  [SerializeField]
  private Battle01PVPSetPointGauge hpGaugePlayer;
  [SerializeField]
  private Battle01PVPSetPointGauge hpGaugeEnemy;
  [Space(10f)]
  [Header("Middle - Player")]
  [SerializeField]
  private UI2DSprite playerGuildTitle;
  [SerializeField]
  private GameObject playerSlcWin;
  [SerializeField]
  private GameObject playerSlcGreat;
  [SerializeField]
  private GameObject playerSlcExcellent;
  [SerializeField]
  private GameObject playerSlcDraw;
  [SerializeField]
  private GameObject playerSlcLose;
  [SerializeField]
  private UILabel txtPlayerName;
  [SerializeField]
  private UILabel txtPlayerPointValue;
  [SerializeField]
  private UILabel txtPlayerRankingValue;
  [SerializeField]
  private UILabel txtPlayerClassValue;
  [SerializeField]
  private UILabel txtPlayerTotalBattlePowerValue;
  [SerializeField]
  private Transform[] unitsStatusPlayer;
  [Space(5f)]
  [Header("Middle - Enemy")]
  [SerializeField]
  private UI2DSprite enemyGuildTitle;
  [SerializeField]
  private GameObject enemySlcWin;
  [SerializeField]
  private GameObject enemySlcGreat;
  [SerializeField]
  private GameObject enemySlcExcellent;
  [SerializeField]
  private GameObject enemySlcDraw;
  [SerializeField]
  private GameObject enemySlcLose;
  [SerializeField]
  private UILabel txtEnemyName;
  [SerializeField]
  private UILabel txtEnemyPointValue;
  [SerializeField]
  private UILabel txtEnemyRankingValue;
  [SerializeField]
  private UILabel txtEnemyClassValue;
  [SerializeField]
  private UILabel txtEnemyTotalBattlePowerValue;
  [SerializeField]
  private Transform[] unitsStatusEnemy;
  [SerializeField]
  private UIButton btnEnemyMastarDetails;

  public IEnumerator Init(Versus02613Scene.BootParam param)
  {
    this.param_ = param;
    this.txtSceneTitle.SetText(Consts.GetInstance().VERSUS_0026_WIN_LOSS_RECORDS_DETAILS_TITLE);
    Future<WebAPI.Response.PvpClassMatchHistoryDetail> apiF = WebAPI.PvpClassMatchHistoryDetail(param.current.battleId, param.current.playerId, (System.Action<WebAPI.Response.UserError>) (error =>
    {
      WebAPI.DefaultUserErrorCallback(error);
      MypageScene.ChangeSceneOnError();
    }));
    IEnumerator e = apiF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.apiResponse = apiF.Result;
    this.target_player = this.apiResponse.target_player;
    Future<GameObject> unitStatusDetailF = Res.Prefabs.versus026_win_loss_records.dir_win_loss_records_unit_status.Load<GameObject>();
    e = unitStatusDetailF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    GameObject unitStatusDetail = unitStatusDetailF.Result;
    Future<GameObject> unitIconPrefabF = Res.Prefabs.UnitIcon.normal.Load<GameObject>();
    e = unitIconPrefabF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    GameObject unitIconPrefab = unitIconPrefabF.Result;
    Future<GameObject> popupInfoPrefabF = new ResourceObject("Prefabs/battleUI_03/Battle030627_UI_PlayerStatus_2").Load<GameObject>();
    e = popupInfoPrefabF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.popupInfoPrefab = popupInfoPrefabF.Result;
    this.txtPlayerNameTop.text = this.apiResponse.player.name;
    this.txtEnemyNameTop.text = this.apiResponse.target_player.name;
    this.txtDate.text = string.Format("{0:yy/MM/dd}", (object) this.apiResponse.start_at);
    this.txtTime.text = string.Format("{0:HH:mm}", (object) this.apiResponse.start_at);
    int battleStagePoint = this.apiResponse.battle_stage_point;
    this.hpGaugePlayer.initValueHistory(this.apiResponse.player_battle_result_point, battleStagePoint);
    this.hpGaugeEnemy.initValueHistory(this.apiResponse.target_player_battle_result_point, battleStagePoint);
    Future<UnityEngine.Sprite> emblemPlayerSpriteF = EmblemUtility.LoadEmblemSprite(this.apiResponse.player.current_emblem_id);
    e = emblemPlayerSpriteF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.playerGuildTitle.sprite2D = emblemPlayerSpriteF.Result;
    this.ClearPLayerSlcResult();
    string playerBattleResult1 = this.apiResponse.player_battle_result;
    if (!(playerBattleResult1 == "Win"))
    {
      if (!(playerBattleResult1 == "Draw"))
      {
        if (playerBattleResult1 == "Lose")
          this.playerSlcLose.SetActive(true);
      }
      else
        this.playerSlcDraw.SetActive(true);
    }
    else
      this.playerSlcWin.SetActive(true);
    string battleResultEffect1 = this.apiResponse.player_battle_result_effect;
    if (!(battleResultEffect1 == "GreatEffect"))
    {
      if (battleResultEffect1 == "ExcellentEffect")
        this.playerSlcExcellent.SetActive(true);
    }
    else
      this.playerSlcGreat.SetActive(true);
    this.txtPlayerName.text = this.apiResponse.player.name;
    this.txtPlayerPointValue.SetTextLocalize(Consts.Format(Consts.GetInstance().VERSUS_0026_WIN_LOSS_POINT, (IDictionary) new Hashtable()
    {
      {
        (object) "point",
        (object) this.apiResponse.player_pvp_rank_point
      }
    }));
    this.txtPlayerRankingValue.SetTextLocalize(Consts.Format(Consts.GetInstance().VERSUS_0026_WIN_LOSS_RANK, (IDictionary) new Hashtable()
    {
      {
        (object) "rank",
        (object) this.apiResponse.player_pvp_ranking
      }
    }));
    this.txtPlayerClassValue.text = this.apiResponse.player_pvp_emblem;
    Future<UnityEngine.Sprite> emblemTargetSpriteF = EmblemUtility.LoadEmblemSprite(this.apiResponse.target_player.current_emblem_id);
    e = emblemTargetSpriteF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.enemyGuildTitle.sprite2D = emblemTargetSpriteF.Result;
    this.ClearEnemySlcResult();
    string playerBattleResult2 = this.apiResponse.target_player_battle_result;
    if (!(playerBattleResult2 == "Win"))
    {
      if (!(playerBattleResult2 == "Draw"))
      {
        if (playerBattleResult2 == "Lose")
          this.enemySlcLose.SetActive(true);
      }
      else
        this.enemySlcDraw.SetActive(true);
    }
    else
      this.enemySlcWin.SetActive(true);
    string battleResultEffect2 = this.apiResponse.target_player_battle_result_effect;
    if (!(battleResultEffect2 == "GreatEffect"))
    {
      if (battleResultEffect2 == "ExcellentEffect")
        this.enemySlcExcellent.SetActive(true);
    }
    else
      this.enemySlcGreat.SetActive(true);
    this.txtEnemyName.text = this.apiResponse.target_player.name;
    this.txtEnemyPointValue.SetTextLocalize(Consts.Format(Consts.GetInstance().VERSUS_0026_WIN_LOSS_POINT, (IDictionary) new Hashtable()
    {
      {
        (object) "point",
        (object) this.apiResponse.target_player_pvp_rank_point
      }
    }));
    UILabel enemyRankingValue = this.txtEnemyRankingValue;
    string text;
    if (this.apiResponse.is_cpu_battle)
      text = Consts.GetInstance().VERSUS_0026_WIN_LOSS_RECORDS_NONE_VALUE;
    else
      text = Consts.Format(Consts.GetInstance().VERSUS_0026_WIN_LOSS_RANK, (IDictionary) new Hashtable()
      {
        {
          (object) "rank",
          (object) this.apiResponse.target_player_pvp_ranking
        }
      });
    enemyRankingValue.SetTextLocalize(text);
    this.txtEnemyClassValue.text = this.apiResponse.target_player_pvp_emblem;
    this.btnEnemyMastarDetails.isEnabled = !this.apiResponse.is_cpu_battle;
    if (param.current.playerId != SMManager.Get<Player>().id)
      this.btnEnemyMastarDetails.isEnabled = false;
    int playerBattlePower = 0;
    int i;
    Versus026DirWinLossRecordsDetailItem detailItem;
    for (i = 0; i < this.unitsStatusPlayer.Length; ++i)
    {
      GameObject gameObject = unitStatusDetail.Clone(this.unitsStatusPlayer[i]);
      if (i < this.apiResponse.player_units.Length && i < this.apiResponse.player_unit_pvp_results.Length)
      {
        this.apiResponse.player_units[i].importOverkillersUnits(this.apiResponse.player_unit_over_killers);
        detailItem = gameObject.GetComponent<Versus026DirWinLossRecordsDetailItem>();
        e = detailItem.InitDetailItems(this.popupInfoPrefab, unitIconPrefab, this.apiResponse.player_unit_pvp_results[i], this.apiResponse.player_units[i], this.apiResponse.player_unit_awake_skills, this.apiResponse.player_items, this.apiResponse.player_reisou_items);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        playerBattlePower += detailItem.battlePower;
        detailItem = (Versus026DirWinLossRecordsDetailItem) null;
      }
    }
    this.txtPlayerTotalBattlePowerValue.text = playerBattlePower.ToString();
    int enemyBattlePower = 0;
    for (i = 0; i < this.unitsStatusEnemy.Length; ++i)
    {
      GameObject gameObject = unitStatusDetail.Clone(this.unitsStatusEnemy[i]);
      if (i < this.apiResponse.target_player_units.Length && i < this.apiResponse.target_player_unit_pvp_results.Length)
      {
        this.apiResponse.target_player_units[i].importOverkillersUnits(this.apiResponse.target_player_unit_over_killers);
        detailItem = gameObject.GetComponent<Versus026DirWinLossRecordsDetailItem>();
        e = detailItem.InitDetailItems(this.popupInfoPrefab, unitIconPrefab, this.apiResponse.target_player_unit_pvp_results[i], this.apiResponse.target_player_units[i], this.apiResponse.target_player_unit_awake_skills, this.apiResponse.target_player_items, this.apiResponse.target_player_reisou_items);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        enemyBattlePower += detailItem.battlePower;
        detailItem = (Versus026DirWinLossRecordsDetailItem) null;
      }
    }
    this.txtEnemyTotalBattlePowerValue.text = enemyBattlePower.ToString();
  }

  private void ClearPLayerSlcResult()
  {
    this.playerSlcWin.SetActive(false);
    this.playerSlcGreat.SetActive(false);
    this.playerSlcExcellent.SetActive(false);
    this.playerSlcDraw.SetActive(false);
    this.playerSlcLose.SetActive(false);
  }

  private void ClearEnemySlcResult()
  {
    this.enemySlcWin.SetActive(false);
    this.enemySlcGreat.SetActive(false);
    this.enemySlcExcellent.SetActive(false);
    this.enemySlcDraw.SetActive(false);
    this.enemySlcLose.SetActive(false);
  }

  public void IbtnMasterDetail() => Friend0086Scene.changeScene(true, this.param_, this.target_player.id, Friend0086Scene.Mode.Friend, Res.Prefabs.BackGround.MultiBackground);

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.param_.pop();
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();
}
