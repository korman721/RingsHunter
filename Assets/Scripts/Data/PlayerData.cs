using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class PlayerData
{
    private SkinsArrow _selectedArrowSkin;
    private SkinsBackground _selectedBackground;
    private SkinsRing _selectedRing;

    private List<SkinsArrow> _openArrowSkins;
    private List<SkinsBackground> _openBackgroundSkins;
    private List<SkinsRing> _openRingSkins;

    private int _money;
    private int _bestScore;

    public PlayerData()
    {
        _money = 0;
        _bestScore = 0;

        _selectedArrowSkin = SkinsArrow.Defualt;
        _selectedBackground = SkinsBackground.Defualt;
        _selectedRing = SkinsRing.Defualt;

        _openArrowSkins = new List<SkinsArrow>() { _selectedArrowSkin };
        _openBackgroundSkins = new List<SkinsBackground>() { _selectedBackground };
        _openRingSkins = new List<SkinsRing>() { _selectedRing };
    }

    [JsonConstructor]
    public PlayerData(int money, int bestscore, SkinsArrow selectedArrowSkin, SkinsBackground selectedBackgroundSkin, SkinsRing selectedRingSkin, List<SkinsArrow> openArrowSkins,
        List<SkinsBackground> openBackgroundSkins, List<SkinsRing> openRingSkins)
    {
        Money = money;
        BestScore = bestscore;

        _selectedArrowSkin = selectedArrowSkin;
        _selectedBackground = selectedBackgroundSkin;
        _selectedRing = selectedRingSkin;

        _openArrowSkins = new List<SkinsArrow>(openArrowSkins);
        _openBackgroundSkins = new List<SkinsBackground>(openBackgroundSkins);
        _openRingSkins = new List<SkinsRing>(openRingSkins);
    }

    public int Money
    {
        get => _money;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _money = value;
        }
    }
    public int BestScore
    {
        get => _bestScore;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _bestScore = value;
        }
    }

    public SkinsArrow SelectedArrowSkin
    {
        get => _selectedArrowSkin;
        set
        {
            if (_openArrowSkins.Contains(value) == false)
                throw new ArgumentException(nameof(value));

            _selectedArrowSkin = value;
        }
    }

    public SkinsBackground SelectedBackground
    {
        get => _selectedBackground;
        set
        {
            if (_openBackgroundSkins.Contains(value) == false)
                throw new ArgumentException(nameof(value));

            _selectedBackground = value;
        }
    }
    public SkinsRing SelectedRing
    {
        get => _selectedRing;
        set
        {
            if (_openRingSkins.Contains(value) == false)
                throw new ArgumentException(nameof(value));

            _selectedRing = value;
        }
    }

    public IEnumerable<SkinsArrow> OpenArrowSkins => _openArrowSkins;
    public IEnumerable<SkinsBackground> OpenBackgroundSkins => _openBackgroundSkins;
    public IEnumerable<SkinsRing> OpenRingSkins => _openRingSkins;

    public void OpenArrowSkin(SkinsArrow skin)
    {
        if (_openArrowSkins.Contains(skin))
            throw new ArgumentException(nameof(skin));

        _openArrowSkins.Add(skin);
    }
    public void OpenBackgroundSkin(SkinsBackground skin)
    {
        if (_openBackgroundSkins.Contains(skin))
            throw new ArgumentException(nameof(skin));

        _openBackgroundSkins.Add(skin);
    }
    public void OpenRingSkin(SkinsRing skin)
    {
        if (_openRingSkins.Contains(skin))
            throw new ArgumentException(nameof(skin));

        _openRingSkins.Add(skin);
    }
}
