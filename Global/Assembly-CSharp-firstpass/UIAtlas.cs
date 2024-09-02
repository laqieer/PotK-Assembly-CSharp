// Decompiled with JetBrains decompiler
// Type: UIAtlas
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/UI/Atlas")]
public class UIAtlas : MonoBehaviour
{
  [HideInInspector]
  [SerializeField]
  private Material material;
  [HideInInspector]
  [SerializeField]
  private List<UISpriteData> mSprites = new List<UISpriteData>();
  [HideInInspector]
  [SerializeField]
  private float mPixelSize = 1f;
  [SerializeField]
  [HideInInspector]
  private UIAtlas mReplacement;
  [HideInInspector]
  [SerializeField]
  private UIAtlas.Coordinates mCoordinates;
  [HideInInspector]
  [SerializeField]
  private List<UIAtlas.Sprite> sprites = new List<UIAtlas.Sprite>();
  private int mPMA = -1;

  public Material spriteMaterial
  {
    get
    {
      return Object.op_Inequality((Object) this.mReplacement, (Object) null) ? this.mReplacement.spriteMaterial : this.material;
    }
    set
    {
      if (Object.op_Inequality((Object) this.mReplacement, (Object) null))
        this.mReplacement.spriteMaterial = value;
      else if (Object.op_Equality((Object) this.material, (Object) null))
      {
        this.mPMA = 0;
        this.material = value;
      }
      else
      {
        this.MarkAsChanged();
        this.mPMA = -1;
        this.material = value;
        this.MarkAsChanged();
      }
    }
  }

  public bool premultipliedAlpha
  {
    get
    {
      if (Object.op_Inequality((Object) this.mReplacement, (Object) null))
        return this.mReplacement.premultipliedAlpha;
      if (this.mPMA == -1)
      {
        Material spriteMaterial = this.spriteMaterial;
        this.mPMA = !Object.op_Inequality((Object) spriteMaterial, (Object) null) || !Object.op_Inequality((Object) spriteMaterial.shader, (Object) null) || !((Object) spriteMaterial.shader).name.Contains("Premultiplied") ? 0 : 1;
      }
      return this.mPMA == 1;
    }
  }

  public List<UISpriteData> spriteList
  {
    get
    {
      if (Object.op_Inequality((Object) this.mReplacement, (Object) null))
        return this.mReplacement.spriteList;
      if (this.mSprites.Count == 0)
        this.Upgrade();
      return this.mSprites;
    }
    set
    {
      if (Object.op_Inequality((Object) this.mReplacement, (Object) null))
        this.mReplacement.spriteList = value;
      else
        this.mSprites = value;
    }
  }

  public Texture texture
  {
    get
    {
      if (Object.op_Inequality((Object) this.mReplacement, (Object) null))
        return this.mReplacement.texture;
      return Object.op_Inequality((Object) this.material, (Object) null) ? this.material.mainTexture : (Texture) null;
    }
  }

  public float pixelSize
  {
    get
    {
      return Object.op_Inequality((Object) this.mReplacement, (Object) null) ? this.mReplacement.pixelSize : this.mPixelSize;
    }
    set
    {
      if (Object.op_Inequality((Object) this.mReplacement, (Object) null))
      {
        this.mReplacement.pixelSize = value;
      }
      else
      {
        float num = Mathf.Clamp(value, 0.25f, 4f);
        if ((double) this.mPixelSize == (double) num)
          return;
        this.mPixelSize = num;
        this.MarkAsChanged();
      }
    }
  }

  public UIAtlas replacement
  {
    get => this.mReplacement;
    set
    {
      UIAtlas uiAtlas = value;
      if (Object.op_Equality((Object) uiAtlas, (Object) this))
        uiAtlas = (UIAtlas) null;
      if (!Object.op_Inequality((Object) this.mReplacement, (Object) uiAtlas))
        return;
      if (Object.op_Inequality((Object) uiAtlas, (Object) null) && Object.op_Equality((Object) uiAtlas.replacement, (Object) this))
        uiAtlas.replacement = (UIAtlas) null;
      if (Object.op_Inequality((Object) this.mReplacement, (Object) null))
        this.MarkAsChanged();
      this.mReplacement = uiAtlas;
      this.MarkAsChanged();
    }
  }

  public UISpriteData GetSprite(string name)
  {
    if (Object.op_Inequality((Object) this.mReplacement, (Object) null))
      return this.mReplacement.GetSprite(name);
    if (!string.IsNullOrEmpty(name))
    {
      if (this.mSprites.Count == 0)
        this.Upgrade();
      int index = 0;
      for (int count = this.mSprites.Count; index < count; ++index)
      {
        UISpriteData mSprite = this.mSprites[index];
        if (!string.IsNullOrEmpty(mSprite.name) && name == mSprite.name)
          return mSprite;
      }
    }
    return (UISpriteData) null;
  }

  public void SortAlphabetically()
  {
    this.mSprites.Sort((Comparison<UISpriteData>) ((s1, s2) => s1.name.CompareTo(s2.name)));
  }

  public BetterList<string> GetListOfSprites()
  {
    if (Object.op_Inequality((Object) this.mReplacement, (Object) null))
      return this.mReplacement.GetListOfSprites();
    if (this.mSprites.Count == 0)
      this.Upgrade();
    BetterList<string> listOfSprites = new BetterList<string>();
    int index = 0;
    for (int count = this.mSprites.Count; index < count; ++index)
    {
      UISpriteData mSprite = this.mSprites[index];
      if (mSprite != null && !string.IsNullOrEmpty(mSprite.name))
        listOfSprites.Add(mSprite.name);
    }
    return listOfSprites;
  }

  public BetterList<string> GetListOfSprites(string match)
  {
    if (Object.op_Implicit((Object) this.mReplacement))
      return this.mReplacement.GetListOfSprites(match);
    if (string.IsNullOrEmpty(match))
      return this.GetListOfSprites();
    if (this.mSprites.Count == 0)
      this.Upgrade();
    BetterList<string> listOfSprites = new BetterList<string>();
    int index1 = 0;
    for (int count = this.mSprites.Count; index1 < count; ++index1)
    {
      UISpriteData mSprite = this.mSprites[index1];
      if (mSprite != null && !string.IsNullOrEmpty(mSprite.name) && string.Equals(match, mSprite.name, StringComparison.OrdinalIgnoreCase))
      {
        listOfSprites.Add(mSprite.name);
        return listOfSprites;
      }
    }
    string[] strArray = match.Split(new char[1]{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
    for (int index2 = 0; index2 < strArray.Length; ++index2)
      strArray[index2] = strArray[index2].ToLower();
    int index3 = 0;
    for (int count = this.mSprites.Count; index3 < count; ++index3)
    {
      UISpriteData mSprite = this.mSprites[index3];
      if (mSprite != null && !string.IsNullOrEmpty(mSprite.name))
      {
        string lower = mSprite.name.ToLower();
        int num = 0;
        for (int index4 = 0; index4 < strArray.Length; ++index4)
        {
          if (lower.Contains(strArray[index4]))
            ++num;
        }
        if (num == strArray.Length)
          listOfSprites.Add(mSprite.name);
      }
    }
    return listOfSprites;
  }

  private bool References(UIAtlas atlas)
  {
    if (Object.op_Equality((Object) atlas, (Object) null))
      return false;
    if (Object.op_Equality((Object) atlas, (Object) this))
      return true;
    return Object.op_Inequality((Object) this.mReplacement, (Object) null) && this.mReplacement.References(atlas);
  }

  public static bool CheckIfRelated(UIAtlas a, UIAtlas b)
  {
    if (Object.op_Equality((Object) a, (Object) null) || Object.op_Equality((Object) b, (Object) null))
      return false;
    return Object.op_Equality((Object) a, (Object) b) || a.References(b) || b.References(a);
  }

  public void MarkAsChanged()
  {
    if (Object.op_Inequality((Object) this.mReplacement, (Object) null))
      this.mReplacement.MarkAsChanged();
    UISprite[] active1 = NGUITools.FindActive<UISprite>();
    int index1 = 0;
    for (int length = active1.Length; index1 < length; ++index1)
    {
      UISprite uiSprite = active1[index1];
      if (UIAtlas.CheckIfRelated(this, uiSprite.atlas))
      {
        UIAtlas atlas = uiSprite.atlas;
        uiSprite.atlas = (UIAtlas) null;
        uiSprite.atlas = atlas;
      }
    }
    UIFont[] objectsOfTypeAll = Resources.FindObjectsOfTypeAll(typeof (UIFont)) as UIFont[];
    int index2 = 0;
    for (int length = objectsOfTypeAll.Length; index2 < length; ++index2)
    {
      UIFont uiFont = objectsOfTypeAll[index2];
      if (UIAtlas.CheckIfRelated(this, uiFont.atlas))
      {
        UIAtlas atlas = uiFont.atlas;
        uiFont.atlas = (UIAtlas) null;
        uiFont.atlas = atlas;
      }
    }
    UILabel[] active2 = NGUITools.FindActive<UILabel>();
    int index3 = 0;
    for (int length = active2.Length; index3 < length; ++index3)
    {
      UILabel uiLabel = active2[index3];
      if (Object.op_Inequality((Object) uiLabel.bitmapFont, (Object) null) && UIAtlas.CheckIfRelated(this, uiLabel.bitmapFont.atlas))
      {
        UIFont bitmapFont = uiLabel.bitmapFont;
        uiLabel.bitmapFont = (UIFont) null;
        uiLabel.bitmapFont = bitmapFont;
      }
    }
  }

  private bool Upgrade()
  {
    if (Object.op_Implicit((Object) this.mReplacement))
      return this.mReplacement.Upgrade();
    if (this.mSprites.Count != 0 || this.sprites.Count <= 0 || !Object.op_Implicit((Object) this.material))
      return false;
    Texture mainTexture = this.material.mainTexture;
    int width = !Object.op_Inequality((Object) mainTexture, (Object) null) ? 512 : mainTexture.width;
    int height = !Object.op_Inequality((Object) mainTexture, (Object) null) ? 512 : mainTexture.height;
    for (int index = 0; index < this.sprites.Count; ++index)
    {
      UIAtlas.Sprite sprite = this.sprites[index];
      Rect outer = sprite.outer;
      Rect inner = sprite.inner;
      if (this.mCoordinates == UIAtlas.Coordinates.TexCoords)
      {
        NGUIMath.ConvertToPixels(outer, width, height, true);
        NGUIMath.ConvertToPixels(inner, width, height, true);
      }
      this.mSprites.Add(new UISpriteData()
      {
        name = sprite.name,
        x = Mathf.RoundToInt(((Rect) ref outer).xMin),
        y = Mathf.RoundToInt(((Rect) ref outer).yMin),
        width = Mathf.RoundToInt(((Rect) ref outer).width),
        height = Mathf.RoundToInt(((Rect) ref outer).height),
        paddingLeft = Mathf.RoundToInt(sprite.paddingLeft * ((Rect) ref outer).width),
        paddingRight = Mathf.RoundToInt(sprite.paddingRight * ((Rect) ref outer).width),
        paddingBottom = Mathf.RoundToInt(sprite.paddingBottom * ((Rect) ref outer).height),
        paddingTop = Mathf.RoundToInt(sprite.paddingTop * ((Rect) ref outer).height),
        borderLeft = Mathf.RoundToInt(((Rect) ref inner).xMin - ((Rect) ref outer).xMin),
        borderRight = Mathf.RoundToInt(((Rect) ref outer).xMax - ((Rect) ref inner).xMax),
        borderBottom = Mathf.RoundToInt(((Rect) ref outer).yMax - ((Rect) ref inner).yMax),
        borderTop = Mathf.RoundToInt(((Rect) ref inner).yMin - ((Rect) ref outer).yMin)
      });
    }
    this.sprites.Clear();
    return true;
  }

  [Serializable]
  private class Sprite
  {
    public string name = "Unity Bug";
    public Rect outer = new Rect(0.0f, 0.0f, 1f, 1f);
    public Rect inner = new Rect(0.0f, 0.0f, 1f, 1f);
    public bool rotated;
    public float paddingLeft;
    public float paddingRight;
    public float paddingTop;
    public float paddingBottom;

    public bool hasPadding
    {
      get
      {
        return (double) this.paddingLeft != 0.0 || (double) this.paddingRight != 0.0 || (double) this.paddingTop != 0.0 || (double) this.paddingBottom != 0.0;
      }
    }
  }

  private enum Coordinates
  {
    Pixels,
    TexCoords,
  }
}
