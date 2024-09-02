// Decompiled with JetBrains decompiler
// Type: MypageSlidePanelDragged
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using UnityEngine;

public class MypageSlidePanelDragged : MonoBehaviour
{
  [SerializeField]
  private UISprite slcPressedEffect;
  public CircularMotionPositionSet drag;
  public GameObject OpenObject;
  public GameObject DisableObject;
  public UISprite SlcOpen;
  public UISprite SlcDisable;
  public UISprite SlcMark;
  public UISprite SlcDisableMark;
  [SerializeField]
  private UIWidget EnableContainer;
  [SerializeField]
  private UIWidget DisableContainer;
  private Vector2 defaultsize;
  private const float FULLOPEN = 20f;
  private const float OPENSTART = 45f;
  public bool jogPlayed = true;
  public bool isOpen = true;
  public string preparationSpriteName = "";
  public string preparationBacgrondSpriteName = "";
  [SerializeField]
  private AnimationCurve animeContainerAlpha;
  private bool enabledContainer = true;
  private Tuple<Transform, Future<GameObject>> Effect;
  private bool isOpenEffect;
  private GameObject EffectObject;

  public void EnableSlcPressedEffect() => this.slcPressedEffect.gameObject.SetActive(true);

  public void DisableSlcPressedEffect() => this.slcPressedEffect.gameObject.SetActive(false);

  public void SetPreparation()
  {
    this.isOpen = false;
    this.SlcDisable.GetComponent<UIButton>().normalSprite = this.preparationSpriteName;
    this.SlcDisable.GetComponent<UIButton>().pressedSprite = this.preparationSpriteName;
    this.SlcDisable.spriteName = this.preparationSpriteName;
    this.DisableObject.transform.GetChildInFind("slc_background").gameObject.GetComponent<UISprite>().spriteName = this.preparationBacgrondSpriteName;
  }

  public UISprite GetButton() => this.isOpen ? this.SlcOpen : this.SlcDisable;

  public UIButton GetEnableButton() => this.isOpen ? this.GetComponent<UIButton>() : this.SlcDisable.GetComponent<UIButton>();

  public UIWidget GetContainer() => this.isOpen ? this.EnableContainer : this.DisableContainer;

  public IEnumerator SetEffect(Future<GameObject> effect, bool isActive = true)
  {
    IEnumerator e = effect.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.EffectObject = effect.Result.Clone(this.EnableContainer.transform);
    this.EffectObject.SetActive(isActive);
  }

  public void SetEffect(GameObject effect, string name, bool isActive = true)
  {
    this.EffectObject = effect.Clone(this.EnableContainer.transform);
    this.EffectObject.transform.GetChildren().ForEach<Transform>((System.Action<Transform>) (x => x.gameObject.SetActive(x.name == name)));
    this.EffectObject.SetActive(isActive);
  }

  public void EnableEffect()
  {
    if (!((UnityEngine.Object) this.EffectObject != (UnityEngine.Object) null))
      return;
    this.EffectObject.SetActive(true);
  }

  private void OnPress(bool isDown)
  {
    if (isDown)
      this.drag.onPress();
    else
      this.drag.onRelease();
  }

  public void ChangeState(bool isOpen)
  {
    this.isOpen = isOpen;
    UISprite uiSprite;
    if (!isOpen)
    {
      uiSprite = this.SlcDisable;
      if ((UnityEngine.Object) this.OpenObject != (UnityEngine.Object) null)
        this.OpenObject.SetActive(false);
      if ((UnityEngine.Object) this.DisableObject != (UnityEngine.Object) null)
        this.DisableObject.SetActive(true);
      if ((UnityEngine.Object) this.SlcMark != (UnityEngine.Object) null)
        this.SlcMark.gameObject.SetActive(false);
      if ((UnityEngine.Object) this.SlcDisableMark != (UnityEngine.Object) null)
        this.SlcDisableMark.gameObject.SetActive(true);
      this.GetComponent<UIButton>().enabled = false;
    }
    else
    {
      uiSprite = this.SlcOpen;
      if ((UnityEngine.Object) this.OpenObject != (UnityEngine.Object) null)
        this.OpenObject.SetActive(true);
      if ((UnityEngine.Object) this.DisableObject != (UnityEngine.Object) null)
        this.DisableObject.SetActive(false);
      if ((UnityEngine.Object) this.SlcMark != (UnityEngine.Object) null)
        this.SlcMark.gameObject.SetActive(true);
      if ((UnityEngine.Object) this.SlcDisableMark != (UnityEngine.Object) null)
        this.SlcDisableMark.gameObject.SetActive(false);
      this.GetComponent<BoxCollider>().enabled = true;
    }
    if (!((UnityEngine.Object) uiSprite != (UnityEngine.Object) null))
      return;
    this.defaultsize = uiSprite.localSize;
  }

  private void Start() => this.ChangeState(this.isOpen);

  private void Update()
  {
  }

  public void PanelEffect(float panelY)
  {
    float num1 = (float) (((double) Mathf.Abs(this.transform.localPosition.y - panelY) - 20.0) / 25.0);
    float num2 = 1f - ((double) num1 > 1.0 ? 1f : ((double) num1 < 0.0 ? 0.0f : num1));
    this.Fade((float) ((double) num2 / 2.0 + 0.5));
    this.Expand((float) ((double) num2 / 2.0 + 0.5));
  }

  public void PanelEffectMin()
  {
    this.Fade(0.0f);
    this.Expand(0.0f);
  }

  private void Fade(float rate)
  {
    UISprite uiSprite = this.SlcOpen;
    if (!this.isOpen)
      uiSprite = this.SlcDisable;
    if ((UnityEngine.Object) uiSprite == (UnityEngine.Object) null)
      return;
    if ((double) rate <= 0.5)
    {
      uiSprite.gameObject.SetActive(false);
      if (!this.enabledContainer)
        return;
    }
    else
    {
      uiSprite.gameObject.SetActive(true);
      Color color = uiSprite.color;
      color.a = rate;
      uiSprite.color = color;
    }
    UIWidget container = this.GetContainer();
    if (!((UnityEngine.Object) container != (UnityEngine.Object) null))
      return;
    if (this.animeContainerAlpha != null)
      rate = Mathf.Clamp01(this.animeContainerAlpha.Evaluate(rate));
    if ((double) rate < 0.100000001490116)
      rate = 0.0f;
    container.alpha = rate;
    this.enabledContainer = (double) rate > 0.0;
    TweenAlpha tweenAlpha = Array.Find<TweenAlpha>(container.GetComponents<TweenAlpha>(), (Predicate<TweenAlpha>) (x => x.tweenGroup == MypageMenuBase.START_TWEEN_GROUP_JOGDIAL));
    if (!((UnityEngine.Object) tweenAlpha != (UnityEngine.Object) null))
      return;
    tweenAlpha.to = this.enabledContainer ? 1f : 0.0f;
  }

  private void Expand(float rato)
  {
    GameObject gameObject = this.SlcOpen.gameObject;
    if (!this.isOpen)
      gameObject = this.SlcDisable.gameObject;
    if ((UnityEngine.Object) gameObject == (UnityEngine.Object) null)
      return;
    Vector3 vector3 = new Vector3(rato, rato, 1f);
    gameObject.transform.localScale = vector3;
    UIWidget container = this.GetContainer();
    if (!((UnityEngine.Object) container != (UnityEngine.Object) null))
      return;
    container.transform.localScale = vector3;
  }

  public Vector3 GetSpriteObjectScale()
  {
    GameObject gameObject = this.SlcOpen.gameObject;
    if (!this.isOpen)
      gameObject = this.SlcDisable.gameObject;
    return (UnityEngine.Object) gameObject == (UnityEngine.Object) null ? Vector3.zero : gameObject.transform.localScale;
  }
}
