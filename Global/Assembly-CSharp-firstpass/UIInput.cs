// Decompiled with JetBrains decompiler
// Type: UIInput
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/UI/Input Field")]
public class UIInput : MonoBehaviour
{
  public static UIInput current;
  public static UIInput selection;
  public UILabel label;
  public UIInput.InputType inputType;
  public UIInput.KeyboardType keyboardType;
  public UIInput.Validation validation;
  public int characterLimit;
  public string savedAs;
  public GameObject selectOnTab;
  public Color activeTextColor = Color.white;
  public Color caretColor = new Color(1f, 1f, 1f, 0.8f);
  public Color selectionColor = new Color(1f, 0.8745098f, 0.5529412f, 0.5f);
  public List<EventDelegate> onSubmit = new List<EventDelegate>();
  public List<EventDelegate> onChange = new List<EventDelegate>();
  public UIInput.OnValidate onValidate;
  [HideInInspector]
  [SerializeField]
  protected string mValue;
  protected string mDefaultText = string.Empty;
  protected Color mDefaultColor = Color.white;
  protected float mPosition;
  protected bool mDoInit = true;
  protected UIWidget.Pivot mPivot;
  protected static int mDrawStart;
  protected static TouchScreenKeyboard mKeyboard;
  private string mCached = string.Empty;

  public string defaultText
  {
    get => this.mDefaultText;
    set
    {
      if (this.mDoInit)
        this.Init();
      this.mDefaultText = value;
      this.UpdateLabel();
    }
  }

  [Obsolete("Use UIInput.value instead")]
  public string text
  {
    get => this.value;
    set => this.value = value;
  }

  public string value
  {
    get
    {
      if (this.mDoInit)
        this.Init();
      return this.mValue;
    }
    set
    {
      if (this.mDoInit)
        this.Init();
      UIInput.mDrawStart = 0;
      value = this.Validate(value);
      if (this.isSelected && UIInput.mKeyboard != null && this.mCached != value)
      {
        UIInput.mKeyboard.text = value;
        this.mCached = value;
      }
      if (!(this.mValue != value))
        return;
      this.mValue = value;
      if (!this.isSelected)
        this.SaveToPlayerPrefs(value);
      this.UpdateLabel();
      this.ExecuteOnChange();
    }
  }

  [Obsolete("Use UIInput.isSelected instead")]
  public bool selected
  {
    get => this.isSelected;
    set => this.isSelected = value;
  }

  public bool isSelected
  {
    get => Object.op_Equality((Object) UIInput.selection, (Object) this);
    set
    {
      if (!value)
      {
        if (!this.isSelected)
          return;
        UICamera.selectedObject = (GameObject) null;
      }
      else
        UICamera.selectedObject = ((Component) this).gameObject;
    }
  }

  public int cursorPosition
  {
    get => this.value.Length;
    set
    {
    }
  }

  public int selectionStart
  {
    get => this.value.Length;
    set
    {
    }
  }

  public int selectionEnd
  {
    get => this.value.Length;
    set
    {
    }
  }

  public string Validate(string val)
  {
    if (string.IsNullOrEmpty(val))
      return string.Empty;
    StringBuilder stringBuilder = new StringBuilder(val.Length);
    for (int index = 0; index < val.Length; ++index)
    {
      char ch = val[index];
      if (this.onValidate != null)
        ch = this.onValidate(stringBuilder.ToString(), stringBuilder.Length, ch);
      else if (this.validation != UIInput.Validation.None)
        ch = this.Validate(stringBuilder.ToString(), stringBuilder.Length, ch);
      if (ch != char.MinValue)
        stringBuilder.Append(ch);
    }
    return this.characterLimit > 0 && stringBuilder.Length > this.characterLimit ? stringBuilder.ToString(0, this.characterLimit) : stringBuilder.ToString();
  }

  private void Start()
  {
    if (string.IsNullOrEmpty(this.mValue))
    {
      if (string.IsNullOrEmpty(this.savedAs) || !PlayerPrefs.HasKey(this.savedAs))
        return;
      this.value = PlayerPrefs.GetString(this.savedAs);
    }
    else
      this.value = this.mValue.Replace("\\n", "\n");
  }

  protected void Init()
  {
    if (!this.mDoInit || !Object.op_Inequality((Object) this.label, (Object) null))
      return;
    this.mDoInit = false;
    this.mDefaultText = this.label.text;
    this.mDefaultColor = this.label.color;
    this.label.supportEncoding = false;
    if (this.label.alignment == NGUIText.Alignment.Justified)
    {
      this.label.alignment = NGUIText.Alignment.Left;
      Debug.LogWarning((object) "Input fields using labels with justified alignment are not supported at this time", (Object) this);
    }
    this.mPivot = this.label.pivot;
    this.mPosition = this.label.cachedTransform.localPosition.x;
    this.UpdateLabel();
  }

  protected void SaveToPlayerPrefs(string val)
  {
    if (string.IsNullOrEmpty(this.savedAs))
      return;
    if (string.IsNullOrEmpty(val))
      PlayerPrefs.DeleteKey(this.savedAs);
    else
      PlayerPrefs.SetString(this.savedAs, val);
  }

  protected virtual void OnSelect(bool isSelected)
  {
    if (isSelected)
      this.OnSelectEvent();
    else
      this.OnDeselectEvent();
  }

  protected void OnSelectEvent()
  {
    UIInput.selection = this;
    if (this.mDoInit)
      this.Init();
    if (!Object.op_Inequality((Object) this.label, (Object) null) || !NGUITools.GetActive((Behaviour) this))
      return;
    this.label.color = this.activeTextColor;
    if (Application.platform == 8 || Application.platform == 11)
    {
      UIInput.mKeyboard = this.inputType != UIInput.InputType.Password ? TouchScreenKeyboard.Open(this.mValue, (TouchScreenKeyboardType) this.keyboardType, this.inputType == UIInput.InputType.AutoCorrect, this.label.multiLine, false, false, this.defaultText) : TouchScreenKeyboard.Open(this.mValue, (TouchScreenKeyboardType) 0, false, false, true);
    }
    else
    {
      Vector2 vector2 = Vector2.op_Implicit(!Object.op_Inequality((Object) UICamera.current, (Object) null) || !Object.op_Inequality((Object) UICamera.current.cachedCamera, (Object) null) ? this.label.worldCorners[0] : UICamera.current.cachedCamera.WorldToScreenPoint(this.label.worldCorners[0]));
      vector2.y = (float) Screen.height - vector2.y;
      Input.imeCompositionMode = (IMECompositionMode) 1;
      Input.compositionCursorPos = vector2;
      UIInput.mDrawStart = 0;
    }
    this.UpdateLabel();
  }

  protected void OnDeselectEvent()
  {
    if (this.mDoInit)
      this.Init();
    if (Object.op_Inequality((Object) this.label, (Object) null) && NGUITools.GetActive((Behaviour) this))
    {
      this.mValue = this.value;
      if (UIInput.mKeyboard != null)
      {
        UIInput.mKeyboard.active = false;
        UIInput.mKeyboard = (TouchScreenKeyboard) null;
      }
      if (string.IsNullOrEmpty(this.mValue))
      {
        this.label.text = this.mDefaultText;
        this.label.color = this.mDefaultColor;
      }
      else
        this.label.text = this.mValue;
      Input.imeCompositionMode = (IMECompositionMode) 0;
      this.RestoreLabelPivot();
    }
    UIInput.selection = (UIInput) null;
    this.UpdateLabel();
  }

  private void Update()
  {
    if (UIInput.mKeyboard == null || !this.isSelected)
      return;
    string text = UIInput.mKeyboard.text;
    if (this.mCached != text)
    {
      this.mCached = text;
      this.value = text;
    }
    if (!UIInput.mKeyboard.done)
      return;
    if (!UIInput.mKeyboard.wasCanceled)
      this.Submit();
    UIInput.mKeyboard = (TouchScreenKeyboard) null;
    this.isSelected = false;
    this.mCached = string.Empty;
  }

  public void Submit()
  {
    if (!NGUITools.GetActive((Behaviour) this))
      return;
    UIInput.current = this;
    this.mValue = this.value;
    EventDelegate.Execute(this.onSubmit);
    this.SaveToPlayerPrefs(this.mValue);
    UIInput.current = (UIInput) null;
  }

  public void UpdateLabel()
  {
    if (!Object.op_Inequality((Object) this.label, (Object) null))
      return;
    if (this.mDoInit)
      this.Init();
    bool isSelected = this.isSelected;
    string str1 = this.value;
    bool flag = string.IsNullOrEmpty(str1) && string.IsNullOrEmpty(Input.compositionString);
    this.label.color = !flag || isSelected ? this.activeTextColor : this.mDefaultColor;
    string text;
    if (flag)
    {
      text = !isSelected ? this.mDefaultText : string.Empty;
      this.RestoreLabelPivot();
    }
    else
    {
      string str2;
      if (this.inputType == UIInput.InputType.Password)
      {
        str2 = string.Empty;
        int num = 0;
        for (int length = str1.Length; num < length; ++num)
          str2 += "*";
      }
      else
        str2 = str1;
      int num1 = !isSelected ? 0 : Mathf.Min(str2.Length, this.cursorPosition);
      string str3 = str2.Substring(0, num1);
      if (isSelected)
        str3 += Input.compositionString;
      text = str3 + str2.Substring(num1, str2.Length - num1);
      if (isSelected && this.label.overflowMethod == UILabel.Overflow.ClampContent)
      {
        int offsetToFit1 = this.label.CalculateOffsetToFit(text);
        if (offsetToFit1 == 0)
        {
          UIInput.mDrawStart = 0;
          this.RestoreLabelPivot();
        }
        else if (num1 < UIInput.mDrawStart)
        {
          UIInput.mDrawStart = num1;
          this.SetPivotToLeft();
        }
        else if (offsetToFit1 < UIInput.mDrawStart)
        {
          UIInput.mDrawStart = offsetToFit1;
          this.SetPivotToLeft();
        }
        else
        {
          int offsetToFit2 = this.label.CalculateOffsetToFit(text.Substring(0, num1));
          if (offsetToFit2 > UIInput.mDrawStart)
          {
            UIInput.mDrawStart = offsetToFit2;
            this.SetPivotToRight();
          }
        }
        if (UIInput.mDrawStart != 0)
          text = text.Substring(UIInput.mDrawStart, text.Length - UIInput.mDrawStart);
      }
      else
      {
        UIInput.mDrawStart = 0;
        this.RestoreLabelPivot();
      }
    }
    this.label.text = text;
  }

  protected void SetPivotToLeft()
  {
    Vector2 pivotOffset = NGUIMath.GetPivotOffset(this.mPivot);
    pivotOffset.x = 0.0f;
    this.label.pivot = NGUIMath.GetPivot(pivotOffset);
  }

  protected void SetPivotToRight()
  {
    Vector2 pivotOffset = NGUIMath.GetPivotOffset(this.mPivot);
    pivotOffset.x = 1f;
    this.label.pivot = NGUIMath.GetPivot(pivotOffset);
  }

  protected void RestoreLabelPivot()
  {
    if (!Object.op_Inequality((Object) this.label, (Object) null) || this.label.pivot == this.mPivot)
      return;
    this.label.pivot = this.mPivot;
  }

  protected char Validate(string text, int pos, char ch)
  {
    if (this.validation == UIInput.Validation.None || !((Behaviour) this).enabled)
      return ch;
    if (this.validation == UIInput.Validation.Integer)
    {
      if (ch >= '0' && ch <= '9' || ch == '-' && pos == 0 && !text.Contains("-"))
        return ch;
    }
    else if (this.validation == UIInput.Validation.Float)
    {
      if (ch >= '0' && ch <= '9' || ch == '-' && pos == 0 && !text.Contains("-") || ch == '.' && !text.Contains("."))
        return ch;
    }
    else if (this.validation == UIInput.Validation.Alphanumeric)
    {
      if (ch >= 'A' && ch <= 'Z' || ch >= 'a' && ch <= 'z' || ch >= '0' && ch <= '9')
        return ch;
    }
    else if (this.validation == UIInput.Validation.Username)
    {
      if (ch >= 'A' && ch <= 'Z')
        return (char) ((int) ch - 65 + 97);
      if (ch >= 'a' && ch <= 'z' || ch >= '0' && ch <= '9')
        return ch;
    }
    else if (this.validation == UIInput.Validation.Name)
    {
      char ch1 = text.Length <= 0 ? ' ' : text[Mathf.Clamp(pos, 0, text.Length - 1)];
      char ch2 = text.Length <= 0 ? '\n' : text[Mathf.Clamp(pos + 1, 0, text.Length - 1)];
      if (ch >= 'a' && ch <= 'z')
        return ch1 == ' ' ? (char) ((int) ch - 97 + 65) : ch;
      if (ch >= 'A' && ch <= 'Z')
        return ch1 != ' ' && ch1 != '\'' ? (char) ((int) ch - 65 + 97) : ch;
      if (ch == '\'')
      {
        if (ch1 != ' ' && ch1 != '\'' && ch2 != '\'' && !text.Contains("'"))
          return ch;
      }
      else if (ch == ' ' && ch1 != ' ' && ch1 != '\'' && ch2 != ' ' && ch2 != '\'')
        return ch;
    }
    return char.MinValue;
  }

  protected void ExecuteOnChange()
  {
    if (!EventDelegate.IsValid(this.onChange))
      return;
    UIInput.current = this;
    EventDelegate.Execute(this.onChange);
    UIInput.current = (UIInput) null;
  }

  public enum InputType
  {
    Standard,
    AutoCorrect,
    Password,
  }

  public enum Validation
  {
    None,
    Integer,
    Float,
    Alphanumeric,
    Username,
    Name,
  }

  public enum KeyboardType
  {
    Default,
    ASCIICapable,
    NumbersAndPunctuation,
    URL,
    NumberPad,
    PhonePad,
    NamePhonePad,
    EmailAddress,
  }

  public delegate char OnValidate(string text, int charIndex, char addedChar);
}
