// Decompiled with JetBrains decompiler
// Type: EarthUnitNumIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class EarthUnitNumIcon : MonoBehaviour
{
  [SerializeField]
  private Vector3 onesScale;
  [SerializeField]
  private Vector3 tensScale;
  [SerializeField]
  private Vector3 onesPos;
  [SerializeField]
  private Vector3[] tensPosList;
  [SerializeField]
  private UnityEngine.Sprite[] baseSprites;
  [SerializeField]
  private UnityEngine.Sprite[] numSprites;
  [SerializeField]
  private UI2DSprite numBase;
  [SerializeField]
  private UI2DSprite[] digitObject;

  public void SetNumIcon(int num, bool isGorgeous = false)
  {
    EarthUnitNumIcon.Leader leader = !isGorgeous ? EarthUnitNumIcon.Leader.None : EarthUnitNumIcon.Leader.Leader;
    this.numBase.gameObject.SetActive(true);
    this.numBase.sprite2D = this.baseSprites[(int) leader];
    this.numBase.SetDimensions((int) this.baseSprites[(int) leader].textureRect.width, (int) this.baseSprites[(int) leader].textureRect.height);
    int num1 = num >= 10 ? 1 : 0;
    int num2 = num % 10;
    int num3 = num / 10;
    if (num1 == 1)
    {
      this.digitObject[0].transform.localPosition = this.tensPosList[0];
      this.digitObject[0].transform.localScale = this.tensScale;
      this.ChangeNumSprite(this.digitObject[0], num2);
      this.digitObject[1].transform.localPosition = this.tensPosList[1];
      this.digitObject[1].transform.localScale = this.tensScale;
      this.ChangeNumSprite(this.digitObject[1], num3);
    }
    else
    {
      this.digitObject[0].transform.localPosition = this.onesPos;
      this.digitObject[0].transform.localScale = this.onesScale;
      this.ChangeNumSprite(this.digitObject[0], num2);
      this.digitObject[1].gameObject.SetActive(false);
    }
  }

  private void ChangeNumSprite(UI2DSprite sprites, int num)
  {
    sprites.gameObject.SetActive(false);
    if (num < 0)
      return;
    sprites.gameObject.SetActive(true);
    sprites.sprite2D = this.numSprites[num];
    UI2DSprite ui2Dsprite = sprites;
    Rect textureRect = this.numSprites[num].textureRect;
    int width = (int) textureRect.width;
    textureRect = this.numSprites[num].textureRect;
    int height = (int) textureRect.height;
    ui2Dsprite.SetDimensions(width, height);
  }

  private enum DigitType
  {
    One,
    Ten,
  }

  private enum Leader
  {
    None,
    Leader,
  }
}
