// Decompiled with JetBrains decompiler
// Type: MypageSlidePanelDragged
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class MypageSlidePanelDragged : MonoBehaviour
{
  private const float FULLOPEN = 20f;
  private const float OPENSTART = 45f;
  private const float TEXTURE_FULL_X = 585f;
  private const float TEXTURE_FULL_H = 114f;
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
  public bool jogPlayed = true;
  public bool isOpen = true;
  public string preparationSpriteName = string.Empty;
  public string preparationBacgrondSpriteName = string.Empty;
  private Tuple<Transform, Future<GameObject>> Effect;
  private bool isOpenEffect;
  private GameObject EffectObject;

  public void EnableSlcPressedEffect()
  {
    ((Component) this.slcPressedEffect).gameObject.SetActive(true);
  }

  public void DisableSlcPressedEffect()
  {
    ((Component) this.slcPressedEffect).gameObject.SetActive(false);
  }

  public void SetPreparation()
  {
    this.isOpen = false;
    ((Component) this.SlcDisable).GetComponent<UIButton>().normalSprite = this.preparationSpriteName;
    ((Component) this.SlcDisable).GetComponent<UIButton>().pressedSprite = this.preparationSpriteName;
    this.SlcDisable.spriteName = this.preparationSpriteName;
    ((Component) this.DisableObject.transform.GetChildInFind("slc_background")).gameObject.GetComponent<UISprite>().spriteName = this.preparationBacgrondSpriteName;
  }

  public UISprite GetButton() => this.isOpen ? this.SlcOpen : this.SlcDisable;

  public UIButton GetEnableButton()
  {
    return this.isOpen ? ((Component) this).GetComponent<UIButton>() : ((Component) this.SlcDisable).GetComponent<UIButton>();
  }

  public UIWidget GetContainer() => this.isOpen ? this.EnableContainer : this.DisableContainer;

  [DebuggerHidden]
  public IEnumerator SetEffect(Future<GameObject> effect, bool isActive = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypageSlidePanelDragged.\u003CSetEffect\u003Ec__Iterator9E5()
    {
      effect = effect,
      isActive = isActive,
      \u003C\u0024\u003Eeffect = effect,
      \u003C\u0024\u003EisActive = isActive,
      \u003C\u003Ef__this = this
    };
  }

  public void SetEffect(GameObject effect, string name, bool isActive = true)
  {
    this.EffectObject = effect.Clone(((Component) this.EnableContainer).transform);
    this.EffectObject.transform.GetChildren().ForEach<Transform>((Action<Transform>) (x => ((Component) x).gameObject.SetActive(((Object) x).name == name)));
    this.EffectObject.SetActive(isActive);
  }

  public void EnableEffect()
  {
    if (!Object.op_Inequality((Object) this.EffectObject, (Object) null))
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
      if (Object.op_Inequality((Object) this.OpenObject, (Object) null))
        this.OpenObject.SetActive(false);
      if (Object.op_Inequality((Object) this.DisableObject, (Object) null))
        this.DisableObject.SetActive(true);
      if (Object.op_Inequality((Object) this.SlcMark, (Object) null))
        ((Component) this.SlcMark).gameObject.SetActive(false);
      if (Object.op_Inequality((Object) this.SlcDisableMark, (Object) null))
        ((Component) this.SlcDisableMark).gameObject.SetActive(true);
      ((Behaviour) ((Component) this).GetComponent<UIButton>()).enabled = false;
    }
    else
    {
      uiSprite = this.SlcOpen;
      if (Object.op_Inequality((Object) this.OpenObject, (Object) null))
        this.OpenObject.SetActive(true);
      if (Object.op_Inequality((Object) this.DisableObject, (Object) null))
        this.DisableObject.SetActive(false);
      if (Object.op_Inequality((Object) this.SlcMark, (Object) null))
        ((Component) this.SlcMark).gameObject.SetActive(true);
      if (Object.op_Inequality((Object) this.SlcDisableMark, (Object) null))
        ((Component) this.SlcDisableMark).gameObject.SetActive(false);
      ((Collider) ((Component) this).GetComponent<BoxCollider>()).enabled = true;
    }
    if (!Object.op_Inequality((Object) uiSprite, (Object) null))
      return;
    this.defaultsize = uiSprite.localSize;
    if ((double) this.defaultsize.x >= 585.0)
      return;
    this.defaultsize.x = 585f;
    this.defaultsize.y = 114f;
  }

  private void Start() => this.ChangeState(this.isOpen);

  private void Update()
  {
  }

  public void PanelEffect(float panelY)
  {
    float num1 = (float) (((double) Mathf.Abs(Mathf.Abs(((Component) this).transform.localPosition.y) - Mathf.Abs(panelY)) - 20.0) / 25.0);
    float num2 = 1f - ((double) num1 <= 1.0 ? ((double) num1 >= 0.0 ? num1 : 0.0f) : 1f);
    this.Fade((float) ((double) num2 / 2.0 + 0.5));
    this.Expand((float) ((double) num2 / 2.0 + 0.5));
  }

  public void PanelEffectMin()
  {
    this.Fade(0.0f);
    this.Expand(0.0f);
  }

  private void Fade(float rato)
  {
    UISprite uiSprite = this.SlcOpen;
    if (!this.isOpen)
      uiSprite = this.SlcDisable;
    if (Object.op_Equality((Object) uiSprite, (Object) null))
      return;
    if ((double) rato <= 0.5)
      rato = 0.0f;
    Color color = uiSprite.color;
    color.a = rato;
    uiSprite.color = color;
    this.GetContainer().color = color;
  }

  private void Expand(float rato)
  {
    GameObject gameObject = ((Component) this.SlcOpen).gameObject;
    if (!this.isOpen)
      gameObject = ((Component) this.SlcDisable).gameObject;
    if (Object.op_Equality((Object) gameObject, (Object) null))
      return;
    Vector3 vector3;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3).\u002Ector(rato, rato, 1f);
    ((Component) this.GetContainer()).transform.localScale = vector3;
    gameObject.transform.localScale = vector3;
  }

  public Vector3 GetSpriteObjectScale()
  {
    GameObject gameObject = ((Component) this.SlcOpen).gameObject;
    if (!this.isOpen)
      gameObject = ((Component) this.SlcDisable).gameObject;
    return Object.op_Equality((Object) gameObject, (Object) null) ? Vector3.zero : gameObject.transform.localScale;
  }
}
