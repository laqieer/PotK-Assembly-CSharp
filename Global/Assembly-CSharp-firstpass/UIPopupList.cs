// Decompiled with JetBrains decompiler
// Type: UIPopupList
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Popup List")]
public class UIPopupList : UIWidgetContainer
{
  private const float animSpeed = 0.15f;
  public static UIPopupList current;
  public UIAtlas atlas;
  public UIFont bitmapFont;
  public Font trueTypeFont;
  public int fontSize = 16;
  public FontStyle fontStyle;
  public string backgroundSprite;
  public string highlightSprite;
  public UIPopupList.Position position;
  public List<string> items = new List<string>();
  public Vector2 padding = Vector2.op_Implicit(new Vector3(4f, 4f));
  public Color textColor = Color.white;
  public Color backgroundColor = Color.white;
  public Color highlightColor = new Color(0.882352948f, 0.784313738f, 0.5882353f, 1f);
  public bool isAnimated = true;
  public bool isLocalized;
  public List<EventDelegate> onChange = new List<EventDelegate>();
  [HideInInspector]
  [SerializeField]
  private string mSelectedItem;
  private UIPanel mPanel;
  private GameObject mChild;
  private UISprite mBackground;
  private UISprite mHighlight;
  private UILabel mHighlightedLabel;
  private List<UILabel> mLabelList = new List<UILabel>();
  private float mBgBorder;
  [HideInInspector]
  [SerializeField]
  private GameObject eventReceiver;
  [SerializeField]
  [HideInInspector]
  private string functionName = "OnSelectionChange";
  [SerializeField]
  [HideInInspector]
  private float textScale;
  [SerializeField]
  [HideInInspector]
  private UIFont font;
  [HideInInspector]
  [SerializeField]
  private UILabel textLabel;
  private UIPopupList.LegacyEvent mLegacyEvent;
  private bool mUseDynamicFont;

  public Object ambigiousFont
  {
    get
    {
      if (Object.op_Inequality((Object) this.trueTypeFont, (Object) null))
        return (Object) this.trueTypeFont;
      return Object.op_Inequality((Object) this.bitmapFont, (Object) null) ? (Object) this.bitmapFont : (Object) this.font;
    }
    set
    {
      switch (value)
      {
        case Font _:
          this.trueTypeFont = value as Font;
          this.bitmapFont = (UIFont) null;
          this.font = (UIFont) null;
          break;
        case UIFont _:
          this.bitmapFont = value as UIFont;
          this.trueTypeFont = (Font) null;
          this.font = (UIFont) null;
          break;
      }
    }
  }

  [Obsolete("Use EventDelegate.Add(popup.onChange, YourCallback) instead, and UIPopupList.current.value to determine the state")]
  public UIPopupList.LegacyEvent onSelectionChange
  {
    get => this.mLegacyEvent;
    set => this.mLegacyEvent = value;
  }

  public bool isOpen => Object.op_Inequality((Object) this.mChild, (Object) null);

  public string value
  {
    get => this.mSelectedItem;
    set
    {
      this.mSelectedItem = value;
      if (this.mSelectedItem == null || this.mSelectedItem == null)
        return;
      this.TriggerCallbacks();
    }
  }

  [Obsolete("Use 'value' instead")]
  public string selection
  {
    get => this.value;
    set => this.value = value;
  }

  private bool handleEvents
  {
    get
    {
      UIKeyNavigation component = ((Component) this).GetComponent<UIKeyNavigation>();
      return Object.op_Equality((Object) component, (Object) null) || !((Behaviour) component).enabled;
    }
    set
    {
      UIKeyNavigation component = ((Component) this).GetComponent<UIKeyNavigation>();
      if (!Object.op_Inequality((Object) component, (Object) null))
        return;
      ((Behaviour) component).enabled = !value;
    }
  }

  private bool isValid
  {
    get
    {
      return Object.op_Inequality((Object) this.bitmapFont, (Object) null) || Object.op_Inequality((Object) this.trueTypeFont, (Object) null);
    }
  }

  private int activeFontSize
  {
    get
    {
      return Object.op_Inequality((Object) this.trueTypeFont, (Object) null) || Object.op_Equality((Object) this.bitmapFont, (Object) null) ? this.fontSize : this.bitmapFont.defaultSize;
    }
  }

  private float activeFontScale
  {
    get
    {
      return Object.op_Inequality((Object) this.trueTypeFont, (Object) null) || Object.op_Equality((Object) this.bitmapFont, (Object) null) ? 1f : (float) this.fontSize / (float) this.bitmapFont.defaultSize;
    }
  }

  protected void TriggerCallbacks()
  {
    UIPopupList.current = this;
    if (this.mLegacyEvent != null)
      this.mLegacyEvent(this.mSelectedItem);
    if (EventDelegate.IsValid(this.onChange))
      EventDelegate.Execute(this.onChange);
    else if (Object.op_Inequality((Object) this.eventReceiver, (Object) null) && !string.IsNullOrEmpty(this.functionName))
      this.eventReceiver.SendMessage(this.functionName, (object) this.mSelectedItem, (SendMessageOptions) 1);
    UIPopupList.current = (UIPopupList) null;
  }

  private void OnEnable()
  {
    if (EventDelegate.IsValid(this.onChange))
    {
      this.eventReceiver = (GameObject) null;
      this.functionName = (string) null;
    }
    if (Object.op_Inequality((Object) this.font, (Object) null))
    {
      if (this.font.isDynamic)
      {
        this.trueTypeFont = this.font.dynamicFont;
        this.fontStyle = this.font.dynamicFontStyle;
        this.mUseDynamicFont = true;
      }
      else if (Object.op_Equality((Object) this.bitmapFont, (Object) null))
      {
        this.bitmapFont = this.font;
        this.mUseDynamicFont = false;
      }
      this.font = (UIFont) null;
    }
    if ((double) this.textScale != 0.0)
    {
      this.fontSize = !Object.op_Inequality((Object) this.bitmapFont, (Object) null) ? 16 : Mathf.RoundToInt((float) this.bitmapFont.defaultSize * this.textScale);
      this.textScale = 0.0f;
    }
    if (!Object.op_Equality((Object) this.trueTypeFont, (Object) null) || !Object.op_Inequality((Object) this.bitmapFont, (Object) null) || !this.bitmapFont.isDynamic)
      return;
    this.trueTypeFont = this.bitmapFont.dynamicFont;
    this.bitmapFont = (UIFont) null;
  }

  private void OnValidate()
  {
    Font trueTypeFont = this.trueTypeFont;
    UIFont bitmapFont = this.bitmapFont;
    this.bitmapFont = (UIFont) null;
    this.trueTypeFont = (Font) null;
    if (Object.op_Inequality((Object) trueTypeFont, (Object) null) && (Object.op_Equality((Object) bitmapFont, (Object) null) || !this.mUseDynamicFont))
    {
      this.bitmapFont = (UIFont) null;
      this.trueTypeFont = trueTypeFont;
      this.mUseDynamicFont = true;
    }
    else if (Object.op_Inequality((Object) bitmapFont, (Object) null))
    {
      if (bitmapFont.isDynamic)
      {
        this.trueTypeFont = bitmapFont.dynamicFont;
        this.fontStyle = bitmapFont.dynamicFontStyle;
        this.fontSize = bitmapFont.defaultSize;
        this.mUseDynamicFont = true;
      }
      else
      {
        this.bitmapFont = bitmapFont;
        this.mUseDynamicFont = false;
      }
    }
    else
    {
      this.trueTypeFont = trueTypeFont;
      this.mUseDynamicFont = true;
    }
  }

  private void Start()
  {
    if (Object.op_Inequality((Object) this.textLabel, (Object) null))
    {
      EventDelegate.Add(this.onChange, new EventDelegate.Callback(this.textLabel.SetCurrentSelection));
      this.textLabel = (UILabel) null;
    }
    if (!Application.isPlaying)
      return;
    if (string.IsNullOrEmpty(this.mSelectedItem))
    {
      if (this.items.Count <= 0)
        return;
      this.value = this.items[0];
    }
    else
    {
      string mSelectedItem = this.mSelectedItem;
      this.mSelectedItem = (string) null;
      this.value = mSelectedItem;
    }
  }

  private void OnLocalize()
  {
    if (!this.isLocalized)
      return;
    this.TriggerCallbacks();
  }

  private void Highlight(UILabel lbl, bool instant)
  {
    if (!Object.op_Inequality((Object) this.mHighlight, (Object) null))
      return;
    TweenPosition component = ((Component) lbl).GetComponent<TweenPosition>();
    if (Object.op_Inequality((Object) component, (Object) null) && ((Behaviour) component).enabled)
      return;
    this.mHighlightedLabel = lbl;
    UISpriteData atlasSprite = this.mHighlight.GetAtlasSprite();
    if (atlasSprite == null)
      return;
    float pixelSize = this.atlas.pixelSize;
    float num1 = (float) atlasSprite.borderLeft * pixelSize;
    float num2 = (float) atlasSprite.borderTop * pixelSize;
    Vector3 pos = Vector3.op_Addition(lbl.cachedTransform.localPosition, new Vector3(-num1, num2, 1f));
    if (instant || !this.isAnimated)
      this.mHighlight.cachedTransform.localPosition = pos;
    else
      TweenPosition.Begin(((Component) this.mHighlight).gameObject, 0.1f, pos).method = UITweener.Method.EaseOut;
  }

  private void OnItemHover(GameObject go, bool isOver)
  {
    if (!isOver)
      return;
    this.Highlight(go.GetComponent<UILabel>(), false);
  }

  private void Select(UILabel lbl, bool instant)
  {
    this.Highlight(lbl, instant);
    this.value = ((Component) lbl).gameObject.GetComponent<UIEventListener>().parameter as string;
    UIPlaySound[] components = ((Component) this).GetComponents<UIPlaySound>();
    int index = 0;
    for (int length = components.Length; index < length; ++index)
    {
      UIPlaySound uiPlaySound = components[index];
      if (uiPlaySound.trigger == UIPlaySound.Trigger.OnClick)
        NGUITools.PlaySound(uiPlaySound.audioClip, uiPlaySound.volume, 1f);
    }
  }

  private void OnItemPress(GameObject go, bool isPressed)
  {
    if (!isPressed)
      return;
    this.Select(go.GetComponent<UILabel>(), true);
  }

  private void OnKey(KeyCode key)
  {
    if (!((Behaviour) this).enabled || !NGUITools.GetActive(((Component) this).gameObject) || !this.handleEvents)
      return;
    int num1 = this.mLabelList.IndexOf(this.mHighlightedLabel);
    if (num1 == -1)
      num1 = 0;
    int num2;
    if (key == 273)
    {
      if (num1 <= 0)
        return;
      this.Select(this.mLabelList[num2 = num1 - 1], false);
    }
    else if (key == 274)
    {
      if (num1 + 1 >= this.mLabelList.Count)
        return;
      this.Select(this.mLabelList[num2 = num1 + 1], false);
    }
    else
    {
      if (key != 27)
        return;
      this.OnSelect(false);
    }
  }

  private void OnSelect(bool isSelected)
  {
    if (isSelected)
      return;
    this.Close();
  }

  public void Close()
  {
    if (!Object.op_Inequality((Object) this.mChild, (Object) null))
      return;
    this.mLabelList.Clear();
    this.handleEvents = false;
    if (this.isAnimated)
    {
      UIWidget[] componentsInChildren1 = this.mChild.GetComponentsInChildren<UIWidget>();
      int index1 = 0;
      for (int length = componentsInChildren1.Length; index1 < length; ++index1)
      {
        UIWidget uiWidget = componentsInChildren1[index1];
        Color color = uiWidget.color;
        color.a = 0.0f;
        TweenColor.Begin(((Component) uiWidget).gameObject, 0.15f, color).method = UITweener.Method.EaseOut;
      }
      Collider[] componentsInChildren2 = this.mChild.GetComponentsInChildren<Collider>();
      int index2 = 0;
      for (int length = componentsInChildren2.Length; index2 < length; ++index2)
        componentsInChildren2[index2].enabled = false;
      Object.Destroy((Object) this.mChild, 0.15f);
    }
    else
      Object.Destroy((Object) this.mChild);
    this.mBackground = (UISprite) null;
    this.mHighlight = (UISprite) null;
    this.mChild = (GameObject) null;
  }

  private void AnimateColor(UIWidget widget)
  {
    Color color = widget.color;
    widget.color = new Color(color.r, color.g, color.b, 0.0f);
    TweenColor.Begin(((Component) widget).gameObject, 0.15f, color).method = UITweener.Method.EaseOut;
  }

  private void AnimatePosition(UIWidget widget, bool placeAbove, float bottom)
  {
    Vector3 localPosition = widget.cachedTransform.localPosition;
    Vector3 vector3 = !placeAbove ? new Vector3(localPosition.x, 0.0f, localPosition.z) : new Vector3(localPosition.x, bottom, localPosition.z);
    widget.cachedTransform.localPosition = vector3;
    TweenPosition.Begin(((Component) widget).gameObject, 0.15f, localPosition).method = UITweener.Method.EaseOut;
  }

  private void AnimateScale(UIWidget widget, bool placeAbove, float bottom)
  {
    GameObject gameObject = ((Component) widget).gameObject;
    Transform cachedTransform = widget.cachedTransform;
    float num = (float) ((double) this.activeFontSize * (double) this.activeFontScale + (double) this.mBgBorder * 2.0);
    cachedTransform.localScale = new Vector3(1f, num / (float) widget.height, 1f);
    TweenScale.Begin(gameObject, 0.15f, Vector3.one).method = UITweener.Method.EaseOut;
    if (!placeAbove)
      return;
    Vector3 localPosition = cachedTransform.localPosition;
    cachedTransform.localPosition = new Vector3(localPosition.x, localPosition.y - (float) widget.height + num, localPosition.z);
    TweenPosition.Begin(gameObject, 0.15f, localPosition).method = UITweener.Method.EaseOut;
  }

  private void Animate(UIWidget widget, bool placeAbove, float bottom)
  {
    this.AnimateColor(widget);
    this.AnimatePosition(widget, placeAbove, bottom);
  }

  private void OnClick()
  {
    if (((Behaviour) this).enabled && NGUITools.GetActive(((Component) this).gameObject) && Object.op_Equality((Object) this.mChild, (Object) null) && Object.op_Inequality((Object) this.atlas, (Object) null) && this.isValid && this.items.Count > 0)
    {
      this.mLabelList.Clear();
      if (Object.op_Equality((Object) this.mPanel, (Object) null))
      {
        this.mPanel = UIPanel.Find(((Component) this).transform);
        if (Object.op_Equality((Object) this.mPanel, (Object) null))
          return;
      }
      this.handleEvents = true;
      Transform transform1 = ((Component) this).transform;
      Bounds relativeWidgetBounds = NGUIMath.CalculateRelativeWidgetBounds(transform1.parent, transform1);
      this.mChild = new GameObject("Drop-down List");
      this.mChild.layer = ((Component) this).gameObject.layer;
      Transform transform2 = this.mChild.transform;
      transform2.parent = transform1.parent;
      transform2.localPosition = ((Bounds) ref relativeWidgetBounds).min;
      transform2.localRotation = Quaternion.identity;
      transform2.localScale = Vector3.one;
      this.mBackground = NGUITools.AddSprite(this.mChild, this.atlas, this.backgroundSprite);
      this.mBackground.pivot = UIWidget.Pivot.TopLeft;
      this.mBackground.depth = NGUITools.CalculateNextDepth(((Component) this.mPanel).gameObject);
      this.mBackground.color = this.backgroundColor;
      Vector4 border = this.mBackground.border;
      this.mBgBorder = border.y;
      this.mBackground.cachedTransform.localPosition = new Vector3(0.0f, border.y, 0.0f);
      this.mHighlight = NGUITools.AddSprite(this.mChild, this.atlas, this.highlightSprite);
      this.mHighlight.pivot = UIWidget.Pivot.TopLeft;
      this.mHighlight.color = this.highlightColor;
      UISpriteData atlasSprite = this.mHighlight.GetAtlasSprite();
      if (atlasSprite == null)
        return;
      float borderTop = (float) atlasSprite.borderTop;
      float activeFontSize = (float) this.activeFontSize;
      float activeFontScale = this.activeFontScale;
      float num1 = activeFontSize * activeFontScale;
      float num2 = 0.0f;
      float num3 = -this.padding.y;
      int num4 = !Object.op_Inequality((Object) this.bitmapFont, (Object) null) ? this.fontSize : this.bitmapFont.defaultSize;
      List<UILabel> uiLabelList = new List<UILabel>();
      int index1 = 0;
      for (int count = this.items.Count; index1 < count; ++index1)
      {
        string key = this.items[index1];
        UILabel lbl = NGUITools.AddWidget<UILabel>(this.mChild);
        lbl.pivot = UIWidget.Pivot.TopLeft;
        lbl.bitmapFont = this.bitmapFont;
        lbl.trueTypeFont = this.trueTypeFont;
        lbl.fontSize = num4;
        lbl.fontStyle = this.fontStyle;
        lbl.text = !this.isLocalized ? key : Localization.Get(key);
        lbl.color = this.textColor;
        lbl.cachedTransform.localPosition = new Vector3(border.x + this.padding.x, num3, -1f);
        lbl.overflowMethod = UILabel.Overflow.ResizeFreely;
        lbl.MakePixelPerfect();
        if ((double) activeFontScale != 1.0)
          lbl.cachedTransform.localScale = Vector3.op_Multiply(Vector3.one, activeFontScale);
        uiLabelList.Add(lbl);
        num3 = num3 - num1 - this.padding.y;
        num2 = Mathf.Max(num2, lbl.printedSize.x);
        UIEventListener uiEventListener = UIEventListener.Get(((Component) lbl).gameObject);
        uiEventListener.onHover = new UIEventListener.BoolDelegate(this.OnItemHover);
        uiEventListener.onPress = new UIEventListener.BoolDelegate(this.OnItemPress);
        uiEventListener.parameter = (object) key;
        if (this.mSelectedItem == key || index1 == 0 && string.IsNullOrEmpty(this.mSelectedItem))
          this.Highlight(lbl, true);
        this.mLabelList.Add(lbl);
      }
      float num5 = Mathf.Max(num2, (float) ((double) ((Bounds) ref relativeWidgetBounds).size.x * (double) activeFontScale - ((double) border.x + (double) this.padding.x) * 2.0));
      float num6 = num5 / activeFontScale;
      Vector3 vector3_1;
      // ISSUE: explicit constructor call
      ((Vector3) ref vector3_1).\u002Ector(num6 * 0.5f, (float) (-(double) activeFontSize * 0.5), 0.0f);
      Vector3 vector3_2;
      // ISSUE: explicit constructor call
      ((Vector3) ref vector3_2).\u002Ector(num6, (num1 + this.padding.y) / activeFontScale, 1f);
      int index2 = 0;
      for (int count = uiLabelList.Count; index2 < count; ++index2)
      {
        BoxCollider boxCollider = NGUITools.AddWidgetCollider(((Component) uiLabelList[index2]).gameObject);
        vector3_1.z = boxCollider.center.z;
        boxCollider.center = vector3_1;
        boxCollider.size = vector3_2;
      }
      float num7 = num5 + (float) (((double) border.x + (double) this.padding.x) * 2.0);
      float num8 = num3 - border.y;
      this.mBackground.width = Mathf.RoundToInt(num7);
      this.mBackground.height = Mathf.RoundToInt(-num8 + border.y);
      float num9 = 2f * this.atlas.pixelSize;
      float num10 = (float) ((double) num7 - ((double) border.x + (double) this.padding.x) * 2.0 + (double) atlasSprite.borderLeft * (double) num9);
      float num11 = num1 + borderTop * num9;
      this.mHighlight.width = Mathf.RoundToInt(num10);
      this.mHighlight.height = Mathf.RoundToInt(num11);
      bool placeAbove = this.position == UIPopupList.Position.Above;
      if (this.position == UIPopupList.Position.Auto)
      {
        UICamera cameraForLayer = UICamera.FindCameraForLayer(((Component) this).gameObject.layer);
        if (Object.op_Inequality((Object) cameraForLayer, (Object) null))
          placeAbove = (double) cameraForLayer.cachedCamera.WorldToViewportPoint(transform1.position).y < 0.5;
      }
      if (this.isAnimated)
      {
        float bottom = num8 + num1;
        this.Animate((UIWidget) this.mHighlight, placeAbove, bottom);
        int index3 = 0;
        for (int count = uiLabelList.Count; index3 < count; ++index3)
          this.Animate((UIWidget) uiLabelList[index3], placeAbove, bottom);
        this.AnimateColor((UIWidget) this.mBackground);
        this.AnimateScale((UIWidget) this.mBackground, placeAbove, bottom);
      }
      if (!placeAbove)
        return;
      transform2.localPosition = new Vector3(((Bounds) ref relativeWidgetBounds).min.x, ((Bounds) ref relativeWidgetBounds).max.y - num8 - border.y, ((Bounds) ref relativeWidgetBounds).min.z);
    }
    else
      this.OnSelect(false);
  }

  public enum Position
  {
    Auto,
    Above,
    Below,
  }

  public delegate void LegacyEvent(string val);
}
