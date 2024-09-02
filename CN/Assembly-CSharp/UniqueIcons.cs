// Decompiled with JetBrains decompiler
// Type: UniqueIcons
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class UniqueIcons : IconPrefabBase
{
  [SerializeField]
  private GameObject item;
  [SerializeField]
  private GameObject backGround;
  [SerializeField]
  private GameObject labelBase;
  [SerializeField]
  private Sprite[] numbers;
  [SerializeField]
  private Sprite equals;
  [SerializeField]
  private GameObject[] numbersObj;
  public Sprite[] backSprite;
  public string spriteName = "Item_Icon_Kiseki";
  private string kiseki = "Item_Icon_Kiseki";
  private string zeny = "Item_Icon_Zeny";
  private string medal = "Item_Icon_Medal";
  private string point = "Item_Icon_Point";
  private string key = "Item_Icon_Key";
  private string ticket = "Item_Icon_GachaTicket";
  private string season_ticket = "thum";
  [SerializeField]
  public UILabel label;
  public string itemName = string.Empty;
  private int width = 24;
  private int height = 28;
  private float wScale = 0.8f;
  private float hScale = 0.8f;
  private static Sprite[] numberSpriteCache;

  public static void ClearCache() => UniqueIcons.numberSpriteCache = (Sprite[]) null;

  public bool BackGroundActivated
  {
    get => this.backGround.activeSelf;
    set => this.backGround.SetActive(value);
  }

  public bool LabelActivated
  {
    get => this.labelBase.activeSelf;
    set => this.labelBase.SetActive(value);
  }

  [DebuggerHidden]
  private IEnumerator InitNumber()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIcons.\u003CInitNumber\u003Ec__IteratorAB0()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetRamdom()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIcons.\u003CSetRamdom\u003Ec__IteratorAB1()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Set(int num = 0)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIcons.\u003CSet\u003Ec__IteratorAB2()
    {
      num = num,
      \u003C\u0024\u003Enum = num,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetKiseki(int count = 0)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIcons.\u003CSetKiseki\u003Ec__IteratorAB3()
    {
      count = count,
      \u003C\u0024\u003Ecount = count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetMedal(int count = 0)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIcons.\u003CSetMedal\u003Ec__IteratorAB4()
    {
      count = count,
      \u003C\u0024\u003Ecount = count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetZeny(int count = 0)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIcons.\u003CSetZeny\u003Ec__IteratorAB5()
    {
      count = count,
      \u003C\u0024\u003Ecount = count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetKey(int id, int count = 0)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIcons.\u003CSetKey\u003Ec__IteratorAB6()
    {
      id = id,
      count = count,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003Ecount = count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetPoint(int count = 0)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIcons.\u003CSetPoint\u003Ec__IteratorAB7()
    {
      count = count,
      \u003C\u0024\u003Ecount = count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetBattleMedal(int count = 0)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIcons.\u003CSetBattleMedal\u003Ec__IteratorAB8()
    {
      count = count,
      \u003C\u0024\u003Ecount = count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetGachaTicket(int count = 0, int id = 0)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIcons.\u003CSetGachaTicket\u003Ec__IteratorAB9()
    {
      id = id,
      count = count,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003Ecount = count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetSeasonTicket(int count = 0, int id = 1)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIcons.\u003CSetSeasonTicket\u003Ec__IteratorABA()
    {
      id = id,
      count = count,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003Ecount = count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetPlayerExp(int count)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIcons.\u003CSetPlayerExp\u003Ec__IteratorABB()
    {
      count = count,
      \u003C\u0024\u003Ecount = count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetUnitExp(int count)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIcons.\u003CSetUnitExp\u003Ec__IteratorABC()
    {
      count = count,
      \u003C\u0024\u003Ecount = count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetApRecover(int count)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIcons.\u003CSetApRecover\u003Ec__IteratorABD()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetMaxUnit(int count)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIcons.\u003CSetMaxUnit\u003Ec__IteratorABE()
    {
      count = count,
      \u003C\u0024\u003Ecount = count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetMaxItem(int count)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIcons.\u003CSetMaxItem\u003Ec__IteratorABF()
    {
      count = count,
      \u003C\u0024\u003Ecount = count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetCpRecover(int count)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIcons.\u003CSetCpRecover\u003Ec__IteratorAC0()
    {
      count = count,
      \u003C\u0024\u003Ecount = count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetMpRecover(int count)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIcons.\u003CSetMpRecover\u003Ec__IteratorAC1()
    {
      count = count,
      \u003C\u0024\u003Ecount = count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetEmblem()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIcons.\u003CSetEmblem\u003Ec__IteratorAC2()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetCommonGachaTicket(int count = 0)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIcons.\u003CSetCommonGachaTicket\u003Ec__IteratorAC3()
    {
      count = count,
      \u003C\u0024\u003Ecount = count,
      \u003C\u003Ef__this = this
    };
  }

  private void SetTexture(Sprite sprite, string _itemName, string _spriteName)
  {
    this.spriteName = _spriteName;
    this.itemName = _itemName;
    this.label.SetText(this.itemName);
    this.item.GetComponent<UI2DSprite>().sprite2D = sprite;
  }

  private void SetNumber(int count, bool equal = true)
  {
    bool flag = count.ToString().Length > 3;
    int num1 = count;
    int num2 = 0;
    if (((this.numbersObj.Length < num1.ToString().Length ? 1 : 0) | (this.numbersObj.Length >= num1.ToString().Length + 1 ? 0 : (equal ? 1 : 0))) != 0)
    {
      Debug.LogWarning((object) "桁数オーバーの為、個数を表示できませんでした。");
    }
    else
    {
      if (num1 != 0)
      {
        int index = 0;
        while (num1 > 0)
        {
          int num3 = num1 % 10;
          UI2DSprite component = this.numbersObj[index].GetComponent<UI2DSprite>();
          component.sprite2D = this.numbers[num3];
          component.SetDirty();
          this.ChoiceNumberSize(component, num3);
          num1 /= 10;
          num2 = index;
          ++index;
        }
        if (equal)
        {
          UI2DSprite component = this.numbersObj[num2 + 1].GetComponent<UI2DSprite>();
          component.sprite2D = this.equals;
          component.height = ((Texture) this.equals.texture).height;
          component.width = ((Texture) this.equals.texture).width;
        }
      }
      if (!flag)
        return;
      this.SetNumberScale();
    }
  }

  public void SetNumberScale()
  {
    ((IEnumerable<GameObject>) this.numbersObj).Select<GameObject, UI2DSprite>((Func<GameObject, UI2DSprite>) (x => x.GetComponent<UI2DSprite>())).ForEach<UI2DSprite>((Action<UI2DSprite>) (sprite =>
    {
      sprite.width = (int) ((double) sprite.width * (double) this.wScale);
      sprite.height = (int) ((double) sprite.height * (double) this.hScale);
    }));
    float num = (float) this.width * this.wScale;
    for (int index = 1; index < this.numbersObj.Length; ++index)
    {
      Vector3 localPosition = this.numbersObj[index].transform.localPosition;
      localPosition.x = this.numbersObj[index - 1].transform.localPosition.x - num;
      this.numbersObj[index].transform.localPosition = localPosition;
    }
  }

  public void ChoiceNumberSize(UI2DSprite target, int num)
  {
    int num1 = this.width;
    int height = this.height;
    switch (num)
    {
      case 0:
        num1 = 24;
        break;
      case 1:
        num1 = 16;
        break;
      case 2:
        num1 = 22;
        break;
      case 3:
        num1 = 22;
        break;
      case 4:
        num1 = 24;
        break;
      case 5:
        num1 = 22;
        break;
      case 6:
        num1 = 22;
        break;
      case 7:
        num1 = 22;
        break;
      case 8:
        num1 = 24;
        break;
      case 9:
        num1 = 22;
        break;
    }
    target.width = num1;
    target.height = height;
  }
}
