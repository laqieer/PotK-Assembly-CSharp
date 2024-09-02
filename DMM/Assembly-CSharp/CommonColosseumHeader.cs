// Decompiled with JetBrains decompiler
// Type: CommonColosseumHeader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;

public class CommonColosseumHeader : CommonHeaderBase
{
  public UIButton ibtnHome;
  public UIButton ibtnBackColosseum;
  public UILabel txtTitleColosseum;
  public UI2DSprite emblemImg;
  private int emblemID = -1;

  private void Awake()
  {
  }

  private void Start() => this.Init();

  protected override void Update()
  {
    base.Update();
    this.UpdateApRecoveryTime();
    if (!this.UpdateApGauge())
      return;
    this.bp.setValue(this.player.Value.bp);
  }

  public IEnumerator SetInfo(CommonColosseumHeader.BtnMode mode, System.Action buttonEvent)
  {
    Player player = SMManager.Get<Player>();
    if (this.emblemID != player.current_emblem_id)
    {
      Future<UnityEngine.Sprite> sprF = EmblemUtility.LoadEmblemSprite(player.current_emblem_id);
      IEnumerator e = sprF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.emblemImg.sprite2D = sprF.Result;
      sprF = (Future<UnityEngine.Sprite>) null;
    }
    this.emblemID = player.current_emblem_id;
    this.txtTitleColosseum.SetTextLocalize(player.name);
    if (mode == CommonColosseumHeader.BtnMode.Back)
      this.EnableBackBtn(buttonEvent);
    else
      this.EnableHomeBtn(buttonEvent);
  }

  public void EnableHomeBtn(System.Action buttonEvent)
  {
    this.ibtnHome.isEnabled = true;
    EventDelegate.Set(this.ibtnHome.onClick, new EventDelegate.Callback(buttonEvent.Invoke));
    this.ibtnHome.gameObject.SetActive(true);
    this.ibtnBackColosseum.gameObject.SetActive(false);
  }

  public void EnableBackBtn(System.Action buttonEvent)
  {
    this.ibtnBackColosseum.isEnabled = true;
    this.ibtnBackColosseum.onClick.Clear();
    EventDelegate.Set(this.ibtnBackColosseum.onClick, new EventDelegate.Callback(buttonEvent.Invoke));
    this.ibtnHome.gameObject.SetActive(false);
    this.ibtnBackColosseum.gameObject.SetActive(true);
  }

  public void DisableBtn()
  {
    this.ibtnHome.isEnabled = false;
    this.ibtnBackColosseum.isEnabled = false;
  }

  public enum BtnMode
  {
    Back,
    Home,
  }
}
