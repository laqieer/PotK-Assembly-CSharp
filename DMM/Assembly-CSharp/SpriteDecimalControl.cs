// Decompiled with JetBrains decompiler
// Type: SpriteDecimalControl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SpriteDecimalControl : MonoBehaviour
{
  [SerializeField]
  [Tooltip("ONの時、表現数値以上の桁を0で埋める")]
  private bool fillZero_;
  [SerializeField]
  [Tooltip("字詰用。未設定時は字詰無し")]
  private UIGrid repositionControl_;
  [SerializeField]
  [Tooltip("1の位から上位桁の順に設定")]
  private SpriteNumberSelectDirect[] digits_;
  private bool firstReposition_ = true;
  private const int UNIT_DECIMAL = 10;
  private int? wMaxValue_;

  private void Awake() => this.initialize();

  private void initialize()
  {
    if (this.digits_ != null && this.digits_.Length != 0)
      return;
    this.digits_ = this.GetComponentsInChildren<SpriteNumberSelectDirect>(true);
  }

  private int maxValue_
  {
    get
    {
      if (this.wMaxValue_.HasValue)
        return this.wMaxValue_.Value;
      this.initialize();
      int num1 = 1;
      foreach (SpriteNumberSelectDirect digit in this.digits_)
        num1 *= 10;
      int num2 = num1 - 1;
      this.wMaxValue_ = new int?(num2);
      return num2;
    }
  }

  public void resetNumber(int num) => this.setNumber(num, true);

  public void setNumber(int num) => this.setNumber(num, false);

  private void setNumber(int value, bool immediate)
  {
    value = Mathf.Min(value, this.maxValue_);
    int num = this.fillZero_ ? this.digits_.Length : (value != 0 ? (int) Mathf.Log10((float) value) + 1 : 1);
    if (immediate)
      this.firstReposition_ = true;
    bool flag = this.firstReposition_;
    foreach (SpriteNumberSelectDirect digit in this.digits_)
    {
      if (num > 0)
      {
        if (!digit.gameObject.activeSelf)
        {
          digit.gameObject.SetActive(true);
          flag = true;
        }
        digit.setNumber(value % 10);
        value /= 10;
        --num;
      }
      else if (digit.gameObject.activeSelf)
      {
        digit.gameObject.SetActive(false);
        flag = true;
      }
    }
    if (!(!this.fillZero_ & flag) || !((Object) this.repositionControl_ != (Object) null))
      return;
    if (this.firstReposition_)
    {
      this.repositionControl_.animateSmoothly = false;
      this.repositionControl_.onReposition = (UIGrid.OnReposition) (() =>
      {
        this.firstReposition_ = false;
        this.repositionControl_.onReposition = (UIGrid.OnReposition) null;
      });
    }
    else
      this.repositionControl_.animateSmoothly = true;
    this.repositionControl_.repositionNow = true;
    this.repositionControl_.Reposition();
  }
}
