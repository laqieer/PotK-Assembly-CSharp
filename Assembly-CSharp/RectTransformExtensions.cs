// Decompiled with JetBrains decompiler
// Type: RectTransformExtensions
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public static class RectTransformExtensions
{
  public static void SetDefaultScale(this RectTransform trans) => trans.localScale = new Vector3(1f, 1f, 1f);

  public static void SetPivotAndAnchors(this RectTransform trans, Vector2 aVec)
  {
    trans.pivot = aVec;
    trans.anchorMin = aVec;
    trans.anchorMax = aVec;
  }

  public static Vector2 GetSize(this RectTransform trans) => trans.rect.size;

  public static float GetWidth(this RectTransform trans) => trans.rect.width;

  public static float GetHeight(this RectTransform trans) => trans.rect.height;

  public static void SetPositionOfPivot(this RectTransform trans, Vector2 newPos) => trans.localPosition = new Vector3(newPos.x, newPos.y, trans.localPosition.z);

  public static void SetLeftBottomPosition(this RectTransform trans, Vector2 newPos) => trans.localPosition = new Vector3(newPos.x + trans.pivot.x * trans.rect.width, newPos.y + trans.pivot.y * trans.rect.height, trans.localPosition.z);

  public static void SetLeftTopPosition(this RectTransform trans, Vector2 newPos) => trans.localPosition = new Vector3(newPos.x + trans.pivot.x * trans.rect.width, newPos.y - (1f - trans.pivot.y) * trans.rect.height, trans.localPosition.z);

  public static void SetRightBottomPosition(this RectTransform trans, Vector2 newPos) => trans.localPosition = new Vector3(newPos.x - (1f - trans.pivot.x) * trans.rect.width, newPos.y + trans.pivot.y * trans.rect.height, trans.localPosition.z);

  public static void SetRightTopPosition(this RectTransform trans, Vector2 newPos) => trans.localPosition = new Vector3(newPos.x - (1f - trans.pivot.x) * trans.rect.width, newPos.y - (1f - trans.pivot.y) * trans.rect.height, trans.localPosition.z);

  public static void SetSize(this RectTransform trans, Vector2 newSize)
  {
    Vector2 size = trans.rect.size;
    Vector2 vector2 = newSize - size;
    trans.offsetMin -= new Vector2(vector2.x * trans.pivot.x, vector2.y * trans.pivot.y);
    trans.offsetMax += new Vector2(vector2.x * (1f - trans.pivot.x), vector2.y * (1f - trans.pivot.y));
  }

  public static void SetWidth(this RectTransform trans, float newSize) => trans.SetSize(new Vector2(newSize, trans.rect.size.y));

  public static void SetHeight(this RectTransform trans, float newSize) => trans.SetSize(new Vector2(trans.rect.size.x, newSize));
}
