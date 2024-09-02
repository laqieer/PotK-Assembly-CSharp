// Decompiled with JetBrains decompiler
// Type: DetailUnitParameter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DetailUnitParameter : MonoBehaviour
{
  [SerializeField]
  private List<DetailUnitParameter.UnitObjectData> unitObjects;
  [SerializeField]
  private List<DetailUnitParameter.SkillObject> skillObjects;
  [SerializeField]
  private UISprite bgColorSprite;
  [SerializeField]
  private UILabel unitName;
  [SerializeField]
  private UIWidget unitTypeIconRoot;
  private UnitTypeIcon unitTypeIcon;
  [SerializeField]
  private UI2DSprite raritySprite;
  private Color bgColor = Color.white;
  private GameObject battleSkillIconPrefab;
  private readonly Dictionary<CommonElement, Color32> JobBgColors = new Dictionary<CommonElement, Color32>()
  {
    {
      CommonElement.none,
      new Color32((byte) 0, (byte) 0, (byte) 0, byte.MaxValue)
    },
    {
      CommonElement.fire,
      new Color32((byte) 186, (byte) 10, (byte) 10, byte.MaxValue)
    },
    {
      CommonElement.wind,
      new Color32((byte) 11, (byte) 152, (byte) 31, byte.MaxValue)
    },
    {
      CommonElement.ice,
      new Color32((byte) 0, (byte) 117, (byte) 178, byte.MaxValue)
    },
    {
      CommonElement.thunder,
      new Color32((byte) 247, (byte) 163, (byte) 0, byte.MaxValue)
    },
    {
      CommonElement.light,
      new Color32((byte) 190, (byte) 186, (byte) 153, byte.MaxValue)
    },
    {
      CommonElement.dark,
      new Color32((byte) 141, (byte) 2, (byte) 238, byte.MaxValue)
    }
  };
  private readonly Dictionary<CommonElement, Color32> CharactorSkillBgColors = new Dictionary<CommonElement, Color32>()
  {
    {
      CommonElement.none,
      new Color32((byte) 0, (byte) 0, (byte) 0, byte.MaxValue)
    },
    {
      CommonElement.fire,
      new Color32((byte) 157, (byte) 9, (byte) 9, byte.MaxValue)
    },
    {
      CommonElement.wind,
      new Color32((byte) 10, (byte) 141, (byte) 29, byte.MaxValue)
    },
    {
      CommonElement.ice,
      new Color32((byte) 0, (byte) 100, (byte) 152, byte.MaxValue)
    },
    {
      CommonElement.thunder,
      new Color32((byte) 203, (byte) 134, (byte) 0, byte.MaxValue)
    },
    {
      CommonElement.light,
      new Color32((byte) 144, (byte) 141, (byte) 112, byte.MaxValue)
    },
    {
      CommonElement.dark,
      new Color32((byte) 121, (byte) 0, (byte) 206, byte.MaxValue)
    }
  };
  private readonly Dictionary<CommonElement, Color32> BgColors = new Dictionary<CommonElement, Color32>()
  {
    {
      CommonElement.none,
      new Color32((byte) 0, (byte) 0, (byte) 0, byte.MaxValue)
    },
    {
      CommonElement.fire,
      new Color32((byte) 231, (byte) 66, (byte) 66, byte.MaxValue)
    },
    {
      CommonElement.wind,
      new Color32((byte) 73, (byte) 172, (byte) 87, byte.MaxValue)
    },
    {
      CommonElement.ice,
      new Color32((byte) 62, (byte) 140, (byte) 180, byte.MaxValue)
    },
    {
      CommonElement.thunder,
      new Color32((byte) 244, (byte) 194, (byte) 96, byte.MaxValue)
    },
    {
      CommonElement.light,
      new Color32((byte) 216, (byte) 212, (byte) 175, byte.MaxValue)
    },
    {
      CommonElement.dark,
      new Color32((byte) 182, (byte) 88, byte.MaxValue, byte.MaxValue)
    }
  };

  [DebuggerHidden]
  public IEnumerator Init(int unitID, int position, Battle0171111Event descriptionPopup)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailUnitParameter.\u003CInit\u003Ec__Iterator970()
    {
      unitID = unitID,
      position = position,
      descriptionPopup = descriptionPopup,
      \u003C\u0024\u003EunitID = unitID,
      \u003C\u0024\u003Eposition = position,
      \u003C\u0024\u003EdescriptionPopup = descriptionPopup,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator InitUnitObject(
    UnitUnit unit,
    DetailUnitParameter.UnitObjectData data,
    Battle0171111Event descriptionPopup)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailUnitParameter.\u003CInitUnitObject\u003Ec__Iterator971()
    {
      data = data,
      unit = unit,
      descriptionPopup = descriptionPopup,
      \u003C\u0024\u003Edata = data,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u0024\u003EdescriptionPopup = descriptionPopup,
      \u003C\u003Ef__this = this
    };
  }

  private void SetClickEvent(
    UIButton btn,
    Battle0171111Event descriptionPopup,
    BattleskillSkill skill)
  {
    EventDelegate.Add(btn.onClick, (EventDelegate.Callback) (() =>
    {
      descriptionPopup.setData(skill);
      descriptionPopup.Show();
    }));
  }

  [DebuggerHidden]
  private IEnumerator InitSkillObject(
    DetailUnitParameter.SkillObject skillObject,
    UnitLeaderSkill leaderSkill,
    List<UnitSkillCharacterQuest> charactorSkills,
    CommonElement element)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailUnitParameter.\u003CInitSkillObject\u003Ec__Iterator972()
    {
      skillObject = skillObject,
      leaderSkill = leaderSkill,
      charactorSkills = charactorSkills,
      element = element,
      \u003C\u0024\u003EskillObject = skillObject,
      \u003C\u0024\u003EleaderSkill = leaderSkill,
      \u003C\u0024\u003EcharactorSkills = charactorSkills,
      \u003C\u0024\u003Eelement = element,
      \u003C\u003Ef__this = this
    };
  }

  [Serializable]
  private struct UnitObjectData
  {
    public GameObject rootObject;
    public NGxMaskSpriteWithScale charaSprite;
    public NGxMaskSpriteWithScale charaShadowSprite;
    public UISprite jobBaseSprite;
    public UISprite jobFramePatternSprite;
    public UILabel jobName;
    public List<UIWidget> linkSkillIcons;
  }

  [Serializable]
  private struct CharactorSkillObject
  {
    public UISprite skillBGColor;
    public UILabel skillName;
    public UILabel skillDiscription;
    public UILabel skillEntryPoint;
    public UIWidget skillIconRoot;
  }

  [Serializable]
  private struct LeaderSkillObject
  {
    public UILabel leaderSkillDiscription;
  }

  [Serializable]
  private struct SkillObject
  {
    public GameObject rootObject;
    public DetailUnitParameter.LeaderSkillObject leaderSkillObject;
    public List<DetailUnitParameter.CharactorSkillObject> charactorSkillObjects;
  }
}
