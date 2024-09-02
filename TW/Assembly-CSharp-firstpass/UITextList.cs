// Decompiled with JetBrains decompiler
// Type: UITextList
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System.Text;
using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/UI/Text List")]
public class UITextList : MonoBehaviour
{
  private const float MOUSE_SCROLL_DIS = 0.03f;
  public UILabel textLabel;
  public UIProgressBar scrollBar;
  public UITextList.Style style;
  public int paragraphHistory = 50;
  protected char[] mSeparator = new char[1]{ '\n' };
  protected BetterList<UITextList.Paragraph> mParagraphs = new BetterList<UITextList.Paragraph>();
  protected float mScroll;
  protected int mTotalLines;
  protected int mLastWidth;
  protected int mLastHeight;

  public bool isValid
  {
    get
    {
      return Object.op_Inequality((Object) this.textLabel, (Object) null) && Object.op_Inequality(this.textLabel.ambigiousFont, (Object) null);
    }
  }

  public float scrollValue
  {
    get => this.mScroll;
    set
    {
      value = Mathf.Clamp01(value);
      if (!this.isValid || (double) this.mScroll == (double) value)
        return;
      if (Object.op_Inequality((Object) this.scrollBar, (Object) null))
      {
        this.scrollBar.value = value;
      }
      else
      {
        this.mScroll = value;
        this.UpdateVisibleText();
      }
    }
  }

  protected float lineHeight
  {
    get
    {
      return Object.op_Inequality((Object) this.textLabel, (Object) null) ? (float) (this.textLabel.fontSize + this.textLabel.spacingY) : 20f;
    }
  }

  protected int scrollHeight
  {
    get
    {
      return !this.isValid ? 0 : Mathf.Max(0, this.mTotalLines - Mathf.FloorToInt((float) this.textLabel.height / this.lineHeight));
    }
  }

  public void Clear()
  {
    this.mParagraphs.Clear();
    this.UpdateVisibleText();
  }

  private void Start()
  {
    if (Object.op_Equality((Object) this.textLabel, (Object) null))
      this.textLabel = ((Component) this).GetComponentInChildren<UILabel>();
    if (Object.op_Inequality((Object) this.scrollBar, (Object) null))
      EventDelegate.Add(this.scrollBar.onChange, new EventDelegate.Callback(this.OnScrollBar));
    this.textLabel.overflowMethod = UILabel.Overflow.ClampContent;
    if (this.style == UITextList.Style.Chat)
    {
      this.textLabel.pivot = UIWidget.Pivot.BottomLeft;
      this.scrollValue = 1f;
    }
    else
    {
      this.textLabel.pivot = UIWidget.Pivot.TopLeft;
      this.scrollValue = 0.0f;
    }
  }

  private void Update()
  {
    if (!this.isValid || this.textLabel.width == this.mLastWidth && this.textLabel.height == this.mLastHeight)
      return;
    this.mLastWidth = this.textLabel.width;
    this.mLastHeight = this.textLabel.height;
    this.Rebuild();
  }

  public void OnScroll(float val)
  {
    val = (double) val <= 0.0 ? -0.03f : 0.03f;
    int scrollHeight = this.scrollHeight;
    if (scrollHeight == 0)
      return;
    val *= this.lineHeight;
    this.scrollValue = this.mScroll - val / (float) scrollHeight;
  }

  public void OnDrag(Vector2 delta)
  {
    int scrollHeight = this.scrollHeight;
    if (scrollHeight == 0)
      return;
    this.scrollValue = this.mScroll + delta.y / this.lineHeight / (float) scrollHeight;
  }

  private void OnScrollBar()
  {
    this.mScroll = UIProgressBar.current.value;
    this.UpdateVisibleText();
  }

  public void Add(string text) => this.Add(text, true);

  protected void Add(string text, bool updateVisible)
  {
    UITextList.Paragraph paragraph;
    if (this.mParagraphs.size < this.paragraphHistory)
    {
      paragraph = new UITextList.Paragraph();
    }
    else
    {
      paragraph = this.mParagraphs[0];
      this.mParagraphs.RemoveAt(0);
    }
    paragraph.text = text;
    this.mParagraphs.Add(paragraph);
    this.Rebuild();
  }

  protected void Rebuild()
  {
    if (!this.isValid)
      return;
    this.textLabel.UpdateNGUIText();
    NGUIText.rectHeight = 1000000;
    this.mTotalLines = 0;
    bool flag = true;
    for (int index = 0; index < this.mParagraphs.size; ++index)
    {
      UITextList.Paragraph paragraph = this.mParagraphs.buffer[index];
      string finalText;
      if (NGUIText.WrapText(paragraph.text, out finalText))
      {
        paragraph.lines = finalText.Split('\n');
        this.mTotalLines += paragraph.lines.Length;
      }
      else
      {
        flag = false;
        break;
      }
    }
    this.mTotalLines = 0;
    if (flag)
    {
      int index = 0;
      for (int size = this.mParagraphs.size; index < size; ++index)
        this.mTotalLines += this.mParagraphs.buffer[index].lines.Length;
    }
    if (Object.op_Inequality((Object) this.scrollBar, (Object) null))
    {
      UIScrollBar scrollBar = this.scrollBar as UIScrollBar;
      if (Object.op_Inequality((Object) scrollBar, (Object) null))
        scrollBar.barSize = this.mTotalLines != 0 ? (float) (1.0 - (double) this.scrollHeight / (double) this.mTotalLines) : 1f;
    }
    this.UpdateVisibleText();
  }

  protected void UpdateVisibleText()
  {
    if (!this.isValid)
      return;
    if (this.mTotalLines == 0)
    {
      this.textLabel.text = string.Empty;
    }
    else
    {
      int num1 = Mathf.FloorToInt((float) this.textLabel.height / this.lineHeight);
      int num2 = Mathf.RoundToInt(this.mScroll * (float) Mathf.Max(0, this.mTotalLines - num1));
      if (num2 < 0)
        num2 = 0;
      StringBuilder stringBuilder = new StringBuilder();
      int index1 = 0;
      for (int size = this.mParagraphs.size; num1 > 0 && index1 < size; ++index1)
      {
        UITextList.Paragraph paragraph = this.mParagraphs.buffer[index1];
        int index2 = 0;
        for (int length = paragraph.lines.Length; num1 > 0 && index2 < length; ++index2)
        {
          string line = paragraph.lines[index2];
          if (num2 > 0)
          {
            --num2;
          }
          else
          {
            if (stringBuilder.Length > 0)
              stringBuilder.Append("\n");
            stringBuilder.Append(line);
            --num1;
          }
        }
      }
      this.textLabel.text = stringBuilder.ToString();
    }
  }

  public enum Style
  {
    Text,
    Chat,
  }

  protected class Paragraph
  {
    public string text;
    public string[] lines;
  }
}
