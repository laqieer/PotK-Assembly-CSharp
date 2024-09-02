// Decompiled with JetBrains decompiler
// Type: UILabel
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/UI/NGUI Label")]
[ExecuteInEditMode]
public class UILabel : UIWidget
{
  public UILabel.Crispness keepCrispWhenShrunk = UILabel.Crispness.OnDesktop;
  [SerializeField]
  [HideInInspector]
  private Font mTrueTypeFont;
  [HideInInspector]
  [SerializeField]
  private UIFont mFont;
  [Multiline(6)]
  [HideInInspector]
  [SerializeField]
  private string mText = string.Empty;
  [SerializeField]
  [HideInInspector]
  private int mFontSize = 16;
  [SerializeField]
  [HideInInspector]
  private FontStyle mFontStyle;
  [HideInInspector]
  [SerializeField]
  private NGUIText.Alignment mAlignment;
  [HideInInspector]
  [SerializeField]
  private bool mEncoding = true;
  [HideInInspector]
  [SerializeField]
  private int mMaxLineCount;
  [HideInInspector]
  [SerializeField]
  private UILabel.Effect mEffectStyle;
  [HideInInspector]
  [SerializeField]
  private Color mEffectColor = Color.black;
  [HideInInspector]
  [SerializeField]
  private NGUIText.SymbolStyle mSymbols = NGUIText.SymbolStyle.Normal;
  [HideInInspector]
  [SerializeField]
  private Vector2 mEffectDistance = Vector2.one;
  [HideInInspector]
  [SerializeField]
  private UILabel.Overflow mOverflow;
  [SerializeField]
  [HideInInspector]
  private Material mMaterial;
  [SerializeField]
  [HideInInspector]
  private bool mApplyGradient;
  [HideInInspector]
  [SerializeField]
  private Color mGradientTop = Color.white;
  [SerializeField]
  [HideInInspector]
  private Color mGradientBottom = new Color(0.7f, 0.7f, 0.7f);
  [SerializeField]
  [HideInInspector]
  private int mSpacingX;
  [SerializeField]
  [HideInInspector]
  private int mSpacingY;
  [SerializeField]
  [HideInInspector]
  private bool mShrinkToFit;
  [HideInInspector]
  [SerializeField]
  private int mMaxLineWidth;
  [SerializeField]
  [HideInInspector]
  private int mMaxLineHeight;
  [HideInInspector]
  [SerializeField]
  private float mLineWidth;
  [HideInInspector]
  [SerializeField]
  private bool mMultiline = true;
  private Font mActiveTTF;
  private float mDensity = 1f;
  private bool mShouldBeProcessed = true;
  private string mProcessedText;
  private bool mPremultiply;
  private Vector2 mCalculatedSize = Vector2.zero;
  private float mScale = 1f;
  private int mPrintedSize;
  private int mLastWidth;
  private int mLastHeight;
  private static BetterList<UILabel> mList = new BetterList<UILabel>();
  private static Dictionary<Font, int> mFontUsage = new Dictionary<Font, int>();
  private static bool mTexRebuildAdded = false;
  private static BetterList<Vector3> mTempVerts = new BetterList<Vector3>();
  private static BetterList<int> mTempIndices = new BetterList<int>();

  private bool shouldBeProcessed
  {
    get => this.mShouldBeProcessed;
    set
    {
      if (value)
      {
        this.mChanged = true;
        this.mShouldBeProcessed = true;
      }
      else
        this.mShouldBeProcessed = false;
    }
  }

  public override bool isAnchoredHorizontally
  {
    get => base.isAnchoredHorizontally || this.mOverflow == UILabel.Overflow.ResizeFreely;
  }

  public override bool isAnchoredVertically
  {
    get
    {
      return base.isAnchoredVertically || this.mOverflow == UILabel.Overflow.ResizeFreely || this.mOverflow == UILabel.Overflow.ResizeHeight;
    }
  }

  public override Material material
  {
    get
    {
      if (Object.op_Inequality((Object) this.mMaterial, (Object) null))
        return this.mMaterial;
      if (Object.op_Inequality((Object) this.mFont, (Object) null))
        return this.mFont.material;
      return Object.op_Inequality((Object) this.mTrueTypeFont, (Object) null) ? this.mTrueTypeFont.material : (Material) null;
    }
    set
    {
      if (!Object.op_Inequality((Object) this.mMaterial, (Object) value))
        return;
      this.MarkAsChanged();
      this.mMaterial = value;
      this.MarkAsChanged();
    }
  }

  [Obsolete("Use UILabel.bitmapFont instead")]
  public UIFont font
  {
    get => this.bitmapFont;
    set => this.bitmapFont = value;
  }

  public UIFont bitmapFont
  {
    get => this.mFont;
    set
    {
      if (!Object.op_Inequality((Object) this.mFont, (Object) value))
        return;
      this.RemoveFromPanel();
      this.mFont = value;
      this.mTrueTypeFont = (Font) null;
      this.MarkAsChanged();
    }
  }

  public Font trueTypeFont
  {
    get
    {
      if (Object.op_Inequality((Object) this.mTrueTypeFont, (Object) null))
        return this.mTrueTypeFont;
      return Object.op_Inequality((Object) this.mFont, (Object) null) ? this.mFont.dynamicFont : (Font) null;
    }
    set
    {
      if (!Object.op_Inequality((Object) this.mTrueTypeFont, (Object) value))
        return;
      this.SetActiveFont((Font) null);
      this.RemoveFromPanel();
      this.mTrueTypeFont = value;
      this.shouldBeProcessed = true;
      this.mFont = (UIFont) null;
      this.SetActiveFont(value);
      this.ProcessAndRequest();
      if (!Object.op_Inequality((Object) this.mActiveTTF, (Object) null))
        return;
      base.MarkAsChanged();
    }
  }

  public Object ambigiousFont
  {
    get
    {
      return Object.op_Inequality((Object) this.mFont, (Object) null) ? (Object) this.mFont : (Object) this.mTrueTypeFont;
    }
    set
    {
      UIFont uiFont = value as UIFont;
      if (Object.op_Inequality((Object) uiFont, (Object) null))
        this.bitmapFont = uiFont;
      else
        this.trueTypeFont = value as Font;
    }
  }

  public string text
  {
    get => this.mText;
    set
    {
      if (this.mText == value)
        return;
      if (string.IsNullOrEmpty(value))
      {
        if (!string.IsNullOrEmpty(this.mText))
        {
          this.mText = string.Empty;
          this.shouldBeProcessed = true;
          this.ProcessAndRequest();
        }
      }
      else if (this.mText != value)
      {
        this.mText = value;
        this.shouldBeProcessed = true;
        this.ProcessAndRequest();
      }
      if (!this.autoResizeBoxCollider)
        return;
      this.ResizeCollider();
    }
  }

  public int defaultFontSize
  {
    get
    {
      if (Object.op_Inequality((Object) this.trueTypeFont, (Object) null))
        return this.mFontSize;
      return Object.op_Inequality((Object) this.mFont, (Object) null) ? this.mFont.defaultSize : 16;
    }
  }

  public int fontSize
  {
    get => this.mFontSize;
    set
    {
      value = Mathf.Clamp(value, 0, 256);
      if (this.mFontSize == value)
        return;
      this.mFontSize = value;
      this.shouldBeProcessed = true;
      this.ProcessAndRequest();
    }
  }

  public FontStyle fontStyle
  {
    get => this.mFontStyle;
    set
    {
      if (this.mFontStyle == value)
        return;
      this.mFontStyle = value;
      this.shouldBeProcessed = true;
      this.ProcessAndRequest();
    }
  }

  public NGUIText.Alignment alignment
  {
    get => this.mAlignment;
    set
    {
      if (this.mAlignment == value)
        return;
      this.mAlignment = value;
      this.shouldBeProcessed = true;
      this.ProcessAndRequest();
    }
  }

  public bool applyGradient
  {
    get => this.mApplyGradient;
    set
    {
      if (this.mApplyGradient == value)
        return;
      this.mApplyGradient = value;
      this.MarkAsChanged();
    }
  }

  public Color gradientTop
  {
    get => this.mGradientTop;
    set
    {
      if (!Color.op_Inequality(this.mGradientTop, value))
        return;
      this.mGradientTop = value;
      if (!this.mApplyGradient)
        return;
      this.MarkAsChanged();
    }
  }

  public Color gradientBottom
  {
    get => this.mGradientBottom;
    set
    {
      if (!Color.op_Inequality(this.mGradientBottom, value))
        return;
      this.mGradientBottom = value;
      if (!this.mApplyGradient)
        return;
      this.MarkAsChanged();
    }
  }

  public int spacingX
  {
    get => this.mSpacingX;
    set
    {
      if (this.mSpacingX == value)
        return;
      this.mSpacingX = value;
      this.MarkAsChanged();
    }
  }

  public int spacingY
  {
    get => this.mSpacingY;
    set
    {
      if (this.mSpacingY == value)
        return;
      this.mSpacingY = value;
      this.MarkAsChanged();
    }
  }

  private bool keepCrisp
  {
    get
    {
      return Object.op_Inequality((Object) this.trueTypeFont, (Object) null) && this.keepCrispWhenShrunk != UILabel.Crispness.Never && this.keepCrispWhenShrunk == UILabel.Crispness.Always;
    }
  }

  public bool supportEncoding
  {
    get => this.mEncoding;
    set
    {
      if (this.mEncoding == value)
        return;
      this.mEncoding = value;
      this.shouldBeProcessed = true;
    }
  }

  public NGUIText.SymbolStyle symbolStyle
  {
    get => this.mSymbols;
    set
    {
      if (this.mSymbols == value)
        return;
      this.mSymbols = value;
      this.shouldBeProcessed = true;
    }
  }

  public UILabel.Overflow overflowMethod
  {
    get => this.mOverflow;
    set
    {
      if (this.mOverflow == value)
        return;
      this.mOverflow = value;
      this.shouldBeProcessed = true;
    }
  }

  [Obsolete("Use 'width' instead")]
  public int lineWidth
  {
    get => this.width;
    set => this.width = value;
  }

  [Obsolete("Use 'height' instead")]
  public int lineHeight
  {
    get => this.height;
    set => this.height = value;
  }

  public bool multiLine
  {
    get => this.mMaxLineCount != 1;
    set
    {
      if (this.mMaxLineCount != 1 == value)
        return;
      this.mMaxLineCount = !value ? 1 : 0;
      this.shouldBeProcessed = true;
    }
  }

  public override Vector3[] localCorners
  {
    get
    {
      if (this.shouldBeProcessed)
        this.ProcessText();
      return base.localCorners;
    }
  }

  public override Vector3[] worldCorners
  {
    get
    {
      if (this.shouldBeProcessed)
        this.ProcessText();
      return base.worldCorners;
    }
  }

  public override Vector4 drawingDimensions
  {
    get
    {
      if (this.shouldBeProcessed)
        this.ProcessText();
      return base.drawingDimensions;
    }
  }

  public int maxLineCount
  {
    get => this.mMaxLineCount;
    set
    {
      if (this.mMaxLineCount == value)
        return;
      this.mMaxLineCount = Mathf.Max(value, 0);
      this.shouldBeProcessed = true;
      if (this.overflowMethod != UILabel.Overflow.ShrinkContent)
        return;
      this.MakePixelPerfect();
    }
  }

  public UILabel.Effect effectStyle
  {
    get => this.mEffectStyle;
    set
    {
      if (this.mEffectStyle == value)
        return;
      this.mEffectStyle = value;
      this.shouldBeProcessed = true;
    }
  }

  public Color effectColor
  {
    get => this.mEffectColor;
    set
    {
      if (!Color.op_Inequality(this.mEffectColor, value))
        return;
      this.mEffectColor = value;
      if (this.mEffectStyle == UILabel.Effect.None)
        return;
      this.shouldBeProcessed = true;
    }
  }

  public Vector2 effectDistance
  {
    get => this.mEffectDistance;
    set
    {
      if (!Vector2.op_Inequality(this.mEffectDistance, value))
        return;
      this.mEffectDistance = value;
      this.shouldBeProcessed = true;
    }
  }

  [Obsolete("Use 'overflowMethod == UILabel.Overflow.ShrinkContent' instead")]
  public bool shrinkToFit
  {
    get => this.mOverflow == UILabel.Overflow.ShrinkContent;
    set
    {
      if (!value)
        return;
      this.overflowMethod = UILabel.Overflow.ShrinkContent;
    }
  }

  public string processedText
  {
    get
    {
      if (this.mLastWidth != this.mWidth || this.mLastHeight != this.mHeight)
      {
        this.mLastWidth = this.mWidth;
        this.mLastHeight = this.mHeight;
        this.mShouldBeProcessed = true;
      }
      if (this.shouldBeProcessed)
        this.ProcessText();
      return this.mProcessedText;
    }
  }

  public Vector2 printedSize
  {
    get
    {
      if (this.shouldBeProcessed)
        this.ProcessText();
      return this.mCalculatedSize;
    }
  }

  public override Vector2 localSize
  {
    get
    {
      if (this.shouldBeProcessed)
        this.ProcessText();
      return base.localSize;
    }
  }

  private bool isValid
  {
    get
    {
      return Object.op_Inequality((Object) this.mFont, (Object) null) || Object.op_Inequality((Object) this.mTrueTypeFont, (Object) null);
    }
  }

  protected override void OnInit()
  {
    base.OnInit();
    UILabel.mList.Add(this);
    this.SetActiveFont(this.trueTypeFont);
  }

  protected override void OnDisable()
  {
    this.SetActiveFont((Font) null);
    UILabel.mList.Remove(this);
    base.OnDisable();
  }

  protected void SetActiveFont(Font fnt)
  {
    if (!Object.op_Inequality((Object) this.mActiveTTF, (Object) fnt))
      return;
    int num1;
    if (Object.op_Inequality((Object) this.mActiveTTF, (Object) null) && UILabel.mFontUsage.TryGetValue(this.mActiveTTF, out num1))
    {
      int num2;
      int num3 = Mathf.Max(0, num2 = num1 - 1);
      if (num3 == 0)
        UILabel.mFontUsage.Remove(this.mActiveTTF);
      else
        UILabel.mFontUsage[this.mActiveTTF] = num3;
    }
    this.mActiveTTF = fnt;
    if (!Object.op_Inequality((Object) this.mActiveTTF, (Object) null))
      return;
    int num4 = 0;
    int num5;
    UILabel.mFontUsage[this.mActiveTTF] = num5 = num4 + 1;
  }

  private static void OnFontChanged(Font font)
  {
    for (int i = 0; i < UILabel.mList.size; ++i)
    {
      UILabel m = UILabel.mList[i];
      if (Object.op_Inequality((Object) m, (Object) null))
      {
        Font trueTypeFont = m.trueTypeFont;
        if (Object.op_Equality((Object) trueTypeFont, (Object) font))
        {
          trueTypeFont.RequestCharactersInTexture(m.mText, m.mPrintedSize, m.mFontStyle);
          m.MarkAsChanged();
        }
      }
    }
  }

  public override Vector3[] GetSides(Transform relativeTo)
  {
    if (this.shouldBeProcessed)
      this.ProcessText();
    return base.GetSides(relativeTo);
  }

  protected override void UpgradeFrom265()
  {
    this.ProcessText(true, true);
    if (this.mShrinkToFit)
    {
      this.overflowMethod = UILabel.Overflow.ShrinkContent;
      this.mMaxLineCount = 0;
    }
    if (this.mMaxLineWidth != 0)
    {
      this.width = this.mMaxLineWidth;
      this.overflowMethod = this.mMaxLineCount <= 0 ? UILabel.Overflow.ShrinkContent : UILabel.Overflow.ResizeHeight;
    }
    else
      this.overflowMethod = UILabel.Overflow.ResizeFreely;
    if (this.mMaxLineHeight != 0)
      this.height = this.mMaxLineHeight;
    if (Object.op_Inequality((Object) this.mFont, (Object) null))
    {
      int defaultSize = this.mFont.defaultSize;
      if (this.height < defaultSize)
        this.height = defaultSize;
    }
    this.mMaxLineWidth = 0;
    this.mMaxLineHeight = 0;
    this.mShrinkToFit = false;
    if (!Object.op_Inequality((Object) ((Component) this).GetComponent<BoxCollider>(), (Object) null))
      return;
    NGUITools.AddWidgetCollider(((Component) this).gameObject, true);
  }

  protected override void OnAnchor()
  {
    if (this.mOverflow == UILabel.Overflow.ResizeFreely)
    {
      if (this.isFullyAnchored)
        this.mOverflow = UILabel.Overflow.ShrinkContent;
    }
    else if (this.mOverflow == UILabel.Overflow.ResizeHeight && Object.op_Inequality((Object) this.topAnchor.target, (Object) null) && Object.op_Inequality((Object) this.bottomAnchor.target, (Object) null))
      this.mOverflow = UILabel.Overflow.ShrinkContent;
    base.OnAnchor();
  }

  private void ProcessAndRequest()
  {
    if (!Object.op_Inequality(this.ambigiousFont, (Object) null))
      return;
    this.ProcessText();
  }

  protected override void OnEnable()
  {
    base.OnEnable();
    if (UILabel.mTexRebuildAdded)
      return;
    UILabel.mTexRebuildAdded = true;
    Font.textureRebuilt += new Action<Font>(UILabel.OnFontChanged);
  }

  protected override void OnStart()
  {
    base.OnStart();
    if ((double) this.mLineWidth > 0.0)
    {
      this.mMaxLineWidth = Mathf.RoundToInt(this.mLineWidth);
      this.mLineWidth = 0.0f;
    }
    if (!this.mMultiline)
    {
      this.mMaxLineCount = 1;
      this.mMultiline = true;
    }
    this.mPremultiply = Object.op_Inequality((Object) this.material, (Object) null) && Object.op_Inequality((Object) this.material.shader, (Object) null) && ((Object) this.material.shader).name.Contains("Premultiplied");
    this.ProcessAndRequest();
  }

  public override void MarkAsChanged()
  {
    this.shouldBeProcessed = true;
    base.MarkAsChanged();
  }

  private void ProcessText() => this.ProcessText(false, true);

  private void ProcessText(bool legacyMode, bool full)
  {
    if (!this.isValid)
      return;
    this.mChanged = true;
    this.shouldBeProcessed = false;
    NGUIText.rectWidth = !legacyMode ? this.width : (this.mMaxLineWidth == 0 ? 1000000 : this.mMaxLineWidth);
    NGUIText.rectHeight = !legacyMode ? this.height : (this.mMaxLineHeight == 0 ? 1000000 : this.mMaxLineHeight);
    this.mPrintedSize = Mathf.Abs(!legacyMode ? this.defaultFontSize : Mathf.RoundToInt(this.cachedTransform.localScale.x));
    this.mScale = 1f;
    if (NGUIText.rectWidth < 1 || NGUIText.rectHeight < 0)
    {
      this.mProcessedText = string.Empty;
    }
    else
    {
      bool flag1 = Object.op_Inequality((Object) this.trueTypeFont, (Object) null);
      if (flag1 && this.keepCrisp)
      {
        UIRoot root = this.root;
        if (Object.op_Inequality((Object) root, (Object) null))
          this.mDensity = !Object.op_Inequality((Object) root, (Object) null) ? 1f : root.pixelSizeAdjustment;
      }
      else
        this.mDensity = 1f;
      if (full)
        this.UpdateNGUIText();
      if (this.mOverflow == UILabel.Overflow.ResizeFreely)
        NGUIText.rectWidth = 1000000;
      if (this.mOverflow == UILabel.Overflow.ResizeFreely || this.mOverflow == UILabel.Overflow.ResizeHeight)
        NGUIText.rectHeight = 1000000;
      if (this.mPrintedSize > 0)
      {
        bool keepCrisp = this.keepCrisp;
        int num;
        for (int index = this.mPrintedSize; index > 0; index = num - 1)
        {
          if (keepCrisp)
          {
            this.mPrintedSize = index;
            NGUIText.fontSize = this.mPrintedSize;
          }
          else
          {
            this.mScale = (float) index / (float) this.mPrintedSize;
            NGUIText.fontScale = !flag1 ? (float) this.mFontSize / (float) this.mFont.defaultSize * this.mScale : this.mScale;
          }
          NGUIText.Update(false);
          bool flag2 = NGUIText.WrapText(this.mText, out this.mProcessedText, true);
          if (this.mOverflow == UILabel.Overflow.ShrinkContent && !flag2)
          {
            if ((num = index - 1) <= 1)
              break;
          }
          else
          {
            if (this.mOverflow == UILabel.Overflow.ResizeFreely)
            {
              this.mCalculatedSize = NGUIText.CalculatePrintedSize(this.mProcessedText);
              this.mWidth = Mathf.Max(this.minWidth, Mathf.RoundToInt(this.mCalculatedSize.x));
              this.mHeight = Mathf.Max(this.minHeight, Mathf.RoundToInt(this.mCalculatedSize.y));
              if ((this.mWidth & 1) == 1)
                ++this.mWidth;
              if ((this.mHeight & 1) == 1)
                ++this.mHeight;
            }
            else if (this.mOverflow == UILabel.Overflow.ResizeHeight)
            {
              this.mCalculatedSize = NGUIText.CalculatePrintedSize(this.mProcessedText);
              this.mHeight = Mathf.Max(this.minHeight, Mathf.RoundToInt(this.mCalculatedSize.y));
              if ((this.mHeight & 1) == 1)
                ++this.mHeight;
            }
            else
              this.mCalculatedSize = NGUIText.CalculatePrintedSize(this.mProcessedText);
            if (!legacyMode)
              break;
            this.width = Mathf.RoundToInt(this.mCalculatedSize.x);
            this.height = Mathf.RoundToInt(this.mCalculatedSize.y);
            this.cachedTransform.localScale = Vector3.one;
            break;
          }
        }
      }
      else
      {
        this.cachedTransform.localScale = Vector3.one;
        this.mProcessedText = string.Empty;
        this.mScale = 1f;
      }
    }
  }

  public override void MakePixelPerfect()
  {
    if (Object.op_Inequality(this.ambigiousFont, (Object) null))
    {
      Vector3 localPosition = this.cachedTransform.localPosition;
      localPosition.x = (float) Mathf.RoundToInt(localPosition.x);
      localPosition.y = (float) Mathf.RoundToInt(localPosition.y);
      localPosition.z = (float) Mathf.RoundToInt(localPosition.z);
      this.cachedTransform.localPosition = localPosition;
      this.cachedTransform.localScale = Vector3.one;
      if (this.mOverflow == UILabel.Overflow.ResizeFreely)
      {
        this.AssumeNaturalSize();
      }
      else
      {
        int width = this.width;
        int height = this.height;
        UILabel.Overflow mOverflow = this.mOverflow;
        this.mOverflow = UILabel.Overflow.ShrinkContent;
        this.mWidth = 100000;
        this.mHeight = 100000;
        this.ProcessText(false, true);
        this.mOverflow = mOverflow;
        int num1 = Mathf.RoundToInt(this.mCalculatedSize.x);
        int num2 = Mathf.RoundToInt(this.mCalculatedSize.y);
        int num3 = Mathf.Max(num1, this.minWidth);
        int num4 = Mathf.Max(num2, this.minHeight);
        this.mWidth = Mathf.Max(width, num3);
        this.mHeight = Mathf.Max(height, num4);
        this.MarkAsChanged();
      }
    }
    else
      base.MakePixelPerfect();
  }

  public void AssumeNaturalSize()
  {
    if (!Object.op_Inequality(this.ambigiousFont, (Object) null))
      return;
    this.mWidth = 100000;
    this.mHeight = 100000;
    this.ProcessText(false, true);
    this.mWidth = Mathf.RoundToInt(this.mCalculatedSize.x);
    this.mHeight = Mathf.RoundToInt(this.mCalculatedSize.y);
    if ((this.mWidth & 1) == 1)
      ++this.mWidth;
    if ((this.mHeight & 1) == 1)
      ++this.mHeight;
    this.MarkAsChanged();
  }

  [Obsolete("Use UILabel.GetCharacterAtPosition instead")]
  public int GetCharacterIndex(Vector3 worldPos) => this.GetCharacterIndexAtPosition(worldPos);

  [Obsolete("Use UILabel.GetCharacterAtPosition instead")]
  public int GetCharacterIndex(Vector2 localPos) => this.GetCharacterIndexAtPosition(localPos);

  public int GetCharacterIndexAtPosition(Vector3 worldPos)
  {
    return this.GetCharacterIndexAtPosition(Vector2.op_Implicit(this.cachedTransform.InverseTransformPoint(worldPos)));
  }

  public int GetCharacterIndexAtPosition(Vector2 localPos)
  {
    if (this.isValid)
    {
      string processedText = this.processedText;
      if (string.IsNullOrEmpty(processedText))
        return 0;
      this.UpdateNGUIText();
      NGUIText.PrintCharacterPositions(processedText, UILabel.mTempVerts, UILabel.mTempIndices);
      if (UILabel.mTempVerts.size > 0)
      {
        this.ApplyOffset(UILabel.mTempVerts, 0);
        int closestCharacter = NGUIText.GetClosestCharacter(UILabel.mTempVerts, localPos);
        int mTempIndex = UILabel.mTempIndices[closestCharacter];
        UILabel.mTempVerts.Clear();
        UILabel.mTempIndices.Clear();
        return mTempIndex;
      }
    }
    return 0;
  }

  public string GetWordAtPosition(Vector3 worldPos)
  {
    return this.GetWordAtCharacterIndex(this.GetCharacterIndexAtPosition(worldPos));
  }

  public string GetWordAtPosition(Vector2 localPos)
  {
    return this.GetWordAtCharacterIndex(this.GetCharacterIndexAtPosition(localPos));
  }

  public string GetWordAtCharacterIndex(int characterIndex)
  {
    if (characterIndex != -1 && characterIndex < this.mText.Length)
    {
      int startIndex = this.mText.LastIndexOf(' ', characterIndex) + 1;
      int num = this.mText.IndexOf(' ', characterIndex);
      if (num == -1)
        num = this.mText.Length;
      if (startIndex != num)
        return NGUIText.StripSymbols(this.mText.Substring(startIndex, num - startIndex));
    }
    return (string) null;
  }

  public string GetUrlAtPosition(Vector3 worldPos)
  {
    return this.GetUrlAtCharacterIndex(this.GetCharacterIndexAtPosition(worldPos));
  }

  public string GetUrlAtPosition(Vector2 localPos)
  {
    return this.GetUrlAtCharacterIndex(this.GetCharacterIndexAtPosition(localPos));
  }

  public string GetUrlAtCharacterIndex(int characterIndex)
  {
    if (characterIndex != -1 && characterIndex < this.mText.Length)
    {
      int num1 = this.mText.LastIndexOf("[url=", characterIndex);
      if (num1 != -1)
      {
        int startIndex1 = num1 + 5;
        int startIndex2 = this.mText.IndexOf("]", startIndex1);
        if (startIndex2 != -1)
        {
          int num2 = this.mText.IndexOf("[/url]", startIndex2);
          if (num2 == -1 || num2 >= characterIndex)
            return this.mText.Substring(startIndex1, startIndex2 - startIndex1);
        }
      }
    }
    return (string) null;
  }

  public int GetCharacterIndex(int currentIndex, KeyCode key)
  {
    if (this.isValid)
    {
      string processedText = this.processedText;
      if (string.IsNullOrEmpty(processedText))
        return 0;
      int defaultFontSize = this.defaultFontSize;
      this.UpdateNGUIText();
      NGUIText.PrintCharacterPositions(processedText, UILabel.mTempVerts, UILabel.mTempIndices);
      if (UILabel.mTempVerts.size > 0)
      {
        this.ApplyOffset(UILabel.mTempVerts, 0);
        for (int i = 0; i < UILabel.mTempIndices.size; ++i)
        {
          if (UILabel.mTempIndices[i] == currentIndex)
          {
            Vector2 pos = Vector2.op_Implicit(UILabel.mTempVerts[i]);
            if (key == 273)
              pos.y += (float) (defaultFontSize + this.spacingY);
            else if (key == 274)
              pos.y -= (float) (defaultFontSize + this.spacingY);
            else if (key == 278)
              pos.x -= 1000f;
            else if (key == 279)
              pos.x += 1000f;
            int closestCharacter = NGUIText.GetClosestCharacter(UILabel.mTempVerts, pos);
            int mTempIndex = UILabel.mTempIndices[closestCharacter];
            if (mTempIndex != currentIndex)
            {
              UILabel.mTempVerts.Clear();
              UILabel.mTempIndices.Clear();
              return mTempIndex;
            }
            break;
          }
        }
        UILabel.mTempVerts.Clear();
        UILabel.mTempIndices.Clear();
      }
      if (key == 273 || key == 278)
        return 0;
      if (key == 274 || key == 279)
        return processedText.Length;
    }
    return currentIndex;
  }

  public void PrintOverlay(
    int start,
    int end,
    UIGeometry caret,
    UIGeometry highlight,
    Color caretColor,
    Color highlightColor)
  {
    caret?.Clear();
    highlight?.Clear();
    if (!this.isValid)
      return;
    string processedText = this.processedText;
    this.UpdateNGUIText();
    int size1 = caret.verts.size;
    Vector2 vector2;
    // ISSUE: explicit constructor call
    ((Vector2) ref vector2).\u002Ector(0.5f, 0.5f);
    float finalAlpha = this.finalAlpha;
    if (highlight != null && start != end)
    {
      int size2 = highlight.verts.size;
      NGUIText.PrintCaretAndSelection(processedText, start, end, caret.verts, highlight.verts);
      if (highlight.verts.size > size2)
      {
        this.ApplyOffset(highlight.verts, size2);
        Color32 color32 = Color32.op_Implicit(new Color(highlightColor.r, highlightColor.g, highlightColor.b, highlightColor.a * finalAlpha));
        for (int index = size2; index < highlight.verts.size; ++index)
        {
          highlight.uvs.Add(vector2);
          highlight.cols.Add(color32);
        }
      }
    }
    else
      NGUIText.PrintCaretAndSelection(processedText, start, end, caret.verts, (BetterList<Vector3>) null);
    this.ApplyOffset(caret.verts, size1);
    Color32 color32_1 = Color32.op_Implicit(new Color(caretColor.r, caretColor.g, caretColor.b, caretColor.a * finalAlpha));
    for (int index = size1; index < caret.verts.size; ++index)
    {
      caret.uvs.Add(vector2);
      caret.cols.Add(color32_1);
    }
  }

  public override void OnFill(
    BetterList<Vector3> verts,
    BetterList<Vector2> uvs,
    BetterList<Color32> cols)
  {
    if (!this.isValid)
      return;
    int size1 = verts.size;
    Color c = this.color;
    c.a = this.finalAlpha;
    if (Object.op_Inequality((Object) this.mFont, (Object) null) && this.mFont.premultipliedAlphaShader)
      c = NGUITools.ApplyPMA(c);
    string processedText = this.processedText;
    int size2 = verts.size;
    this.UpdateNGUIText();
    NGUIText.tint = c;
    NGUIText.Print(processedText, verts, uvs, cols);
    Vector2 vector2 = this.ApplyOffset(verts, size2);
    if (Object.op_Inequality((Object) this.mFont, (Object) null) && this.mFont.packedFontShader || this.effectStyle == UILabel.Effect.None)
      return;
    int size3 = verts.size;
    vector2.x = this.mEffectDistance.x;
    vector2.y = this.mEffectDistance.y;
    this.ApplyShadow(verts, uvs, cols, size1, size3, vector2.x, -vector2.y);
    if (this.effectStyle != UILabel.Effect.Outline)
      return;
    int start1 = size3;
    int size4 = verts.size;
    this.ApplyShadow(verts, uvs, cols, start1, size4, -vector2.x, vector2.y);
    int start2 = size4;
    int size5 = verts.size;
    this.ApplyShadow(verts, uvs, cols, start2, size5, vector2.x, vector2.y);
    int start3 = size5;
    int size6 = verts.size;
    this.ApplyShadow(verts, uvs, cols, start3, size6, -vector2.x, -vector2.y);
  }

  protected Vector2 ApplyOffset(BetterList<Vector3> verts, int start)
  {
    Vector2 pivotOffset = this.pivotOffset;
    float num1 = Mathf.Lerp(0.0f, (float) -this.mWidth, pivotOffset.x);
    float num2 = Mathf.Lerp((float) this.mHeight, 0.0f, pivotOffset.y) + Mathf.Lerp(this.mCalculatedSize.y - (float) this.mHeight, 0.0f, pivotOffset.y);
    float num3 = Mathf.Round(num1);
    float num4 = Mathf.Round(num2);
    for (int index = start; index < verts.size; ++index)
    {
      verts.buffer[index].x += num3;
      verts.buffer[index].y += num4;
    }
    return new Vector2(num3, num4);
  }

  private void ApplyShadow(
    BetterList<Vector3> verts,
    BetterList<Vector2> uvs,
    BetterList<Color32> cols,
    int start,
    int end,
    float x,
    float y)
  {
    Color mEffectColor = this.mEffectColor;
    mEffectColor.a *= this.finalAlpha;
    Color32 color32 = Color32.op_Implicit(!Object.op_Inequality((Object) this.bitmapFont, (Object) null) || !this.bitmapFont.premultipliedAlphaShader ? mEffectColor : NGUITools.ApplyPMA(mEffectColor));
    for (int index = start; index < end; ++index)
    {
      verts.Add(verts.buffer[index]);
      uvs.Add(uvs.buffer[index]);
      cols.Add(cols.buffer[index]);
      Vector3 vector3 = verts.buffer[index];
      vector3.x += x;
      vector3.y += y;
      verts.buffer[index] = vector3;
      cols.buffer[index] = color32;
    }
  }

  public int CalculateOffsetToFit(string text)
  {
    this.UpdateNGUIText();
    NGUIText.encoding = false;
    NGUIText.symbolStyle = NGUIText.SymbolStyle.None;
    return NGUIText.CalculateOffsetToFit(text);
  }

  public void SetCurrentProgress()
  {
    if (!Object.op_Inequality((Object) UIProgressBar.current, (Object) null))
      return;
    this.text = UIProgressBar.current.value.ToString("F");
  }

  public void SetCurrentPercent()
  {
    if (!Object.op_Inequality((Object) UIProgressBar.current, (Object) null))
      return;
    this.text = Mathf.RoundToInt(UIProgressBar.current.value * 100f).ToString() + "%";
  }

  public void SetCurrentSelection()
  {
    if (!Object.op_Inequality((Object) UIPopupList.current, (Object) null))
      return;
    this.text = !UIPopupList.current.isLocalized ? UIPopupList.current.value : Localization.Get(UIPopupList.current.value);
  }

  public bool Wrap(string text, out string final) => this.Wrap(text, out final, 1000000);

  public bool Wrap(string text, out string final, int height)
  {
    this.UpdateNGUIText();
    return NGUIText.WrapText(text, out final);
  }

  public void UpdateNGUIText()
  {
    Font trueTypeFont = this.trueTypeFont;
    bool flag = Object.op_Inequality((Object) trueTypeFont, (Object) null);
    NGUIText.fontSize = this.mPrintedSize;
    NGUIText.fontStyle = this.mFontStyle;
    NGUIText.rectWidth = this.mWidth;
    NGUIText.rectHeight = this.mHeight;
    NGUIText.gradient = this.mApplyGradient && (Object.op_Equality((Object) this.mFont, (Object) null) || !this.mFont.packedFontShader);
    NGUIText.gradientTop = this.mGradientTop;
    NGUIText.gradientBottom = this.mGradientBottom;
    NGUIText.encoding = this.mEncoding;
    NGUIText.premultiply = this.mPremultiply;
    NGUIText.symbolStyle = this.mSymbols;
    NGUIText.maxLines = this.mMaxLineCount;
    NGUIText.spacingX = (float) this.mSpacingX;
    NGUIText.spacingY = (float) this.mSpacingY;
    NGUIText.fontScale = !flag ? (float) this.mFontSize / (float) this.mFont.defaultSize * this.mScale : this.mScale;
    if (Object.op_Inequality((Object) this.mFont, (Object) null))
    {
      NGUIText.bitmapFont = this.mFont;
      while (true)
      {
        UIFont replacement = NGUIText.bitmapFont.replacement;
        if (!Object.op_Equality((Object) replacement, (Object) null))
          NGUIText.bitmapFont = replacement;
        else
          break;
      }
      if (NGUIText.bitmapFont.isDynamic)
      {
        NGUIText.dynamicFont = NGUIText.bitmapFont.dynamicFont;
        NGUIText.bitmapFont = (UIFont) null;
      }
      else
        NGUIText.dynamicFont = (Font) null;
    }
    else
    {
      NGUIText.dynamicFont = trueTypeFont;
      NGUIText.bitmapFont = (UIFont) null;
    }
    if (flag && this.keepCrisp)
    {
      UIRoot root = this.root;
      if (Object.op_Inequality((Object) root, (Object) null))
        NGUIText.pixelDensity = !Object.op_Inequality((Object) root, (Object) null) ? 1f : root.pixelSizeAdjustment;
    }
    else
      NGUIText.pixelDensity = 1f;
    if ((double) this.mDensity != (double) NGUIText.pixelDensity)
    {
      this.ProcessText(false, false);
      NGUIText.rectWidth = this.mWidth;
      NGUIText.rectHeight = this.mHeight;
    }
    if (this.alignment == NGUIText.Alignment.Automatic)
    {
      switch (this.pivot)
      {
        case UIWidget.Pivot.TopLeft:
        case UIWidget.Pivot.Left:
        case UIWidget.Pivot.BottomLeft:
          NGUIText.alignment = NGUIText.Alignment.Left;
          break;
        case UIWidget.Pivot.TopRight:
        case UIWidget.Pivot.Right:
        case UIWidget.Pivot.BottomRight:
          NGUIText.alignment = NGUIText.Alignment.Right;
          break;
        default:
          NGUIText.alignment = NGUIText.Alignment.Center;
          break;
      }
    }
    else
      NGUIText.alignment = this.alignment;
    NGUIText.Update();
  }

  public string GetStandardizationTextEN(string text)
  {
    this.text = text;
    return text;
  }

  public static void SetProhibitionJP(string first, string last)
  {
    NGUIText.firstInterdictionTextJP = first;
    NGUIText.lastInterdictionTextJP = last;
  }

  public static void SetProhibitionEN(string first, string last)
  {
    NGUIText.firstInterdictionTextEN = first;
    NGUIText.lastInterdictionTextEN = last;
  }

  public enum Effect
  {
    None,
    Shadow,
    Outline,
  }

  public enum Overflow
  {
    ShrinkContent,
    ClampContent,
    ResizeFreely,
    ResizeHeight,
  }

  public enum Crispness
  {
    Never,
    OnDesktop,
    Always,
  }
}
