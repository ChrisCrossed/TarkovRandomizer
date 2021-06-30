using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Disables warning errors for SerializeField variables
#pragma warning disable 649

enum AssaultRifles
{
    ADAR2_15,
    AK_10X,
    AK_74X,
    AKMX,
    ASH_12,
    AS_VAL,
    DT_MDR,
    HK_416,
    Kel_Tec,
    M4A1,
    MCX,
    SA_58,
    TX_15,
    Vepr
}

enum AssaultCarbines
{
    SKS,
    VeprHunter
}

enum SMGs
{
    MP5,
    MP5k,
    MP7,
    MP9,
    MPX,
    P90,
    PP_19,
    PP_9,
    PPSH,
    Saiga_9,
    STM_9,
    UMP_45,
    Vector_45mm,
    Vector_9mm
}

enum Shotguns
{
    _590A1,
    M870,
    MP_133,
    MP_153,
    Saiga_12,
    TOZ_106,
    KS_23M
}

enum Marksmans
{
    M1A,
    MK_18,
    RSASS,
    SR_25,
    SVDS,
    VSS
}

enum SniperRifles
{
    DVL_10,
    M700,
    Mosin,
    SV_98,
    T5000,
    VPO_215
}

enum GrenadeLaunchers
{
    FN_GL40
}

enum Pistols
{
    APx,
    FN5_7,
    Glock17,
    Glock18,
    M1911,
    M45,
    M9A3,
    MP_443,
    P226,
    PB,
    PL_15,
    PM,
    SR_1,
    TT,
    TT_Gold
}

enum AmmoLimit
{
    Level_1,
    Level_2,
    Level_3,
    Level_4
}

enum Armor
{
    _3M,
    PACA,
    _6B2,
    Untar,
    Press,
    _6B23_1,
    BNTI_Kirasa,
    USEC,
    _6B13,
    _6B23_2,
    BNTI_Korund,
    Fort,
    _6B13_Assault,
    IOTV_HighMobi,
    BNTI,
    FORT_Defender,
    IOTV,
    IOTV_Full,
    FORT_Redut_T5,
    Hex,
    LBT,
    Zhuk,
    _6B43
}

enum Backpacks
{
    _6SH118,
    LBT_2670,
    Blackjack,
    F4Terminator,
    SSOAttack2,
    Pilgrim,
    _3VG,
    Gunslinger,
    Mechanism,
    Camelback,
    AnaTactical,
    Switchblade,
    Takedown,
    Berkut,
    DayPack,
    ScavBackpack,
    MBSS,
    Sanitar,
    Duffle,
    Tourist,
    Transformer,
    VKBO,
    TacticalSling
}

enum ArmoredTactical
{
    _6B5_16,
    _6B3TM,
    _6B5_15,
    ANA_M2,
    ANA_M1,
    CryePrecision,
    ArsArmaA18,
    Wartech,
    TactecPlateCarrier,
    ArsArmaCPC
}

enum TacticalRigs
{
    Scav,
    Security,
    IDEA,
    BankRobber,
    MRig,
    WTRig,
    CSA,
    _6SH112,
    Tarzan,
    D3CRX,
    Triton,
    Commando,
    Thunderbolt,
    BSS_MK1,
    Umka,
    LBT_1961A,
    BlackRock,
    MK3,
    Alpha,
    Azimut,
    MPPV,
    Belt
}

enum Helmet
{
    ShatteredMask,
    TKFastMT,
    TankHelmet,
    Kolpak,
    SHPM,
    Djeta,
    Pumpkin,
    Untar,
    _6B47,
    LZSh,
    SSh_68,
    Kiver_M,
    Ronin,
    SFERA,
    TC_2001,
    TC_2002,
    TC_800,
    ACHHC,
    ZSh_1_2M,
    ULACH,
    Bastion,
    FastMT,
    Airframe,
    Exfil,
    Caiman,
    LSHZ_2DTM,
    Maska,
    Altyn,
    Rsy_T,
    Vulkan_5,
    CowboyHat,
    Ushanka,
    DoorKicker
}

enum Sights
{
    IronSights,
    DR1_4x,
    HAMR,
    Prism,
    Bravo4,
    TA11D,
    TA01NSN,
    Monster2_32,
    EKP_8,
    _553,
    HHS_1,
    XPS3,
    OKP,
    P1X42,
    UH_1,
    MRS,
    Ring,
    SRS_02,
    PK_06,
    FF3,
    DP,
    RMR,
    Romeo_4,
    PU35,
    Nightforce7_35,
    Optical3_24,
    PSO1,
    EOTech1_6,
    TAC30,
    USP_1,
    KMZ1P,
    Pilad4_32,
    ADOP4,
    Vulcan_Night,
    REAP_IR_Thermal,
    NSPU_M_Night,
    RS_32_Thermal
}

enum Quests
{
    Eat3FoundSnacks,
    Kill5Scavs,
    Kill1PMC,
    Kill3PMC,
    Collect5Knives,
    Kill3WithGrenades,
    Collect3Dogtags,
    Kill1WithStationaryGun,
    BefriendAPlayer,
    FindTankBattery,
    NoSecureContainer,
    NoSilencer,
    FightMapBossIfAvailable,
    FencesLootGoblin,
    ShooterBornInHeaven,
    NoInsurance
}

enum CursedQuests
{
    NoAimDownSightsAllowed,
    ThreeSightsAttached,
    NoExtractUntil5MinutesLeft,
    EquipmentSwap,
    NoHealthRegenAllowed,
    MayoOnly
}

enum Snacks
{
    Crackers,
    CondMilk,
    Slickers,
    Sugar,
    Saury,
    Croutons,
    Salmon,
    Peas,
    Tushonka,
    TushonkaSm,
    OakFlakes,
    Herring,
    Squash,
    Alyonka,
    Lunchbox,
    MRE,
    EmerWaterRation,
    WaterBottle,
    Aquamari,
    Pineapple,
    GreenTea,
    AppleJuice,
    PomJuice,
    VitaJuice,
    TarCola,
    Milk,
    Kvass,
    HotRod,
    Mayo,
    Sprats,
    Superwater,
    Moonshine,
    Vodka,
    Whiskey
}

enum SnacksQuantity
{
    One,
    Three,
    Five,
    Ten
}

enum Maps
{
    Factory,
    Woods,
    Customs,
    Interchange,
    Reserve,
    Shoreline,
    Labs
}

public class c_RandomizerLogic : MonoBehaviour
{
    [Header("Weapons")]
    [SerializeField] bool NoWeaponPossibility;

    [SerializeField] bool AssaultRiflesAllowed;

    [SerializeField] bool AssaultCarbinesAllowed;

    [SerializeField] bool MarksmanRiflesAllowed;

    [SerializeField] bool SniperRiflesAllowed;

    [SerializeField] bool ShotgunsAllowed;

    [SerializeField] bool SMGsAllowed;

    [SerializeField] bool PistolsAllowed;

    [SerializeField] bool GrenadeLaunchersAllowed;
    public Toggle[] ButtonWeapons = new Toggle[9];

    // ---
    [Header("Armor")]
    [SerializeField] bool NoArmorPossibility;

    [SerializeField] bool NoTacticalPossibility;

    [SerializeField] bool TacticalAllowed;

    [SerializeField] bool ArmoredTacticalAllowed;

    [SerializeField] bool ArmorAllowed;
    public Toggle[] ButtonArmor = new Toggle[5];

    // ---
    [Header("Misc")]
    [SerializeField] bool MapsEnabled;

    [SerializeField] bool SnacksEnabled;

    // ---
    [Header("Quests")]
    [SerializeField] bool QuestsEnabled;

    [SerializeField] bool CursedQuestsEnabled;

    [Range(5, 50)] [SerializeField] int CursedQuestProbability = 20;

    // ---
    [Header("Based God")]
    Toggle t_BasedGod;
    Slider s_BasedGod;
    Text text_BasedGodProbability;

    // ---

    bool PlayerHasWeapon = true;

    // On Screen Text
    Text text_Weapon;
    Text text_Helmet;
    Text text_Armor;
    Text text_Map;
    Text text_Snacks;
    Text text_Quest;

    string output_weapon;
    string output_ammo;
    string output_sight;
    string output_helmet;
    string output_armor;
    string output_map;
    string output_snacks;
    string output_quest;

    public Toggle[] LockedOptions = new Toggle[0];

    // Start is called before the first frame update
    void Start()
    {
        text_Weapon = GameObject.Find("Text_Weapon").gameObject.GetComponent<Text>();
        text_Helmet = GameObject.Find("Text_Helmet").gameObject.GetComponent<Text>();
        text_Armor = GameObject.Find("Text_Armor").gameObject.GetComponent<Text>();
        text_Map = GameObject.Find("Text_Map").gameObject.GetComponent<Text>();
        text_Snacks = GameObject.Find("Text_Snacks").gameObject.GetComponent<Text>();
        text_Quest = GameObject.Find("Text_Quest").gameObject.GetComponent<Text>();

        t_BasedGod = GameObject.Find("Toggle_BasedGod").gameObject.GetComponent<Toggle>();
        t_BasedGod.onValueChanged.AddListener(delegate { ToggleBasedGod(t_BasedGod); });
        s_BasedGod = GameObject.Find("Slider_BasedGod").gameObject.GetComponent<Slider>();
        s_BasedGod.onValueChanged.AddListener(delegate { SliderBasedGod(s_BasedGod); });
        text_BasedGodProbability = GameObject.Find("Text_BasedGodProbability").gameObject.GetComponent<Text>();
        text_BasedGodProbability.text = "6 in 10 chance";
    }

    public void RollLoadout()
    {
        AssignBools();
        
        GetRandomMap();

        GetRandomWeapon();
        GetRandomAmmo();
        GetRandomSight();
        GetRandomHelmet();
        GetRandomTactical();

        GetRandomSnack();
        GetRandomQuest();

        // Assign text
        text_Weapon.text = output_weapon;
        if(PlayerHasWeapon && LockedOptions[0].isOn) text_Weapon.text += " with " + output_ammo + "\nand " + output_sight;

        text_Helmet.text = output_helmet;

        text_Armor.text = output_armor;

        text_Map.text = output_map;

        text_Snacks.text = output_snacks;

        text_Quest.text = output_quest;

        // Weapon reset
        PlayerHasWeapon = true;
    }

    void AssignBools()
    {
        // Weapons
        NoWeaponPossibility = ButtonWeapons[0].isOn;
        AssaultRiflesAllowed = ButtonWeapons[1].isOn;
        AssaultCarbinesAllowed = ButtonWeapons[2].isOn;
        MarksmanRiflesAllowed = ButtonWeapons[3].isOn;
        SniperRiflesAllowed = ButtonWeapons[4].isOn;
        ShotgunsAllowed = ButtonWeapons[5].isOn;
        SMGsAllowed = ButtonWeapons[6].isOn;
        PistolsAllowed = ButtonWeapons[7].isOn;
        GrenadeLaunchersAllowed = ButtonWeapons[8].isOn;

        // Armor
        NoArmorPossibility = ButtonArmor[0].isOn;
        NoTacticalPossibility = ButtonArmor[1].isOn;
        TacticalAllowed = ButtonArmor[2].isOn;
        ArmoredTacticalAllowed = ButtonArmor[3].isOn;
        ArmorAllowed = ButtonArmor[4].isOn;

        // Strings
        output_weapon = "<Weapon / Ammo / Sight: User Choice>";
        output_ammo = "";
        output_sight = "";
        output_helmet = "<Helmet: User Choice>";
        output_armor = "<Armor: User Choice>";
        output_map = "<Map: User Choice>";
        output_snacks = "<Snacks: User Choice>";
        output_quest = "<Quest: None>";
    }

    void GetRandomMap()
    {
        if (!LockedOptions[3].isOn) return;

        if (!MapsEnabled) return;

        var randomMap = (Maps)Random.Range(0, System.Enum.GetValues(typeof(Maps)).Length);
        output_map = randomMap.ToString() + " Map";
    }

    void GetRandomWeapon()
    {
        if (!LockedOptions[0].isOn) return;

        int currLimit = 0;

        if (NoWeaponPossibility) currLimit += 1;

        if (AssaultRiflesAllowed) currLimit += System.Enum.GetValues(typeof(AssaultRifles)).Length;

        if (AssaultCarbinesAllowed) currLimit += System.Enum.GetValues(typeof(AssaultCarbines)).Length;

        if (MarksmanRiflesAllowed) currLimit += System.Enum.GetValues(typeof(Marksmans)).Length;

        if (SniperRiflesAllowed) currLimit += System.Enum.GetValues(typeof(SniperRifles)).Length;

        if (ShotgunsAllowed) currLimit += System.Enum.GetValues(typeof(Shotguns)).Length;

        if (SMGsAllowed) currLimit += System.Enum.GetValues(typeof(SMGs)).Length;

        if (PistolsAllowed) currLimit += System.Enum.GetValues(typeof(Pistols)).Length;

        if (GrenadeLaunchersAllowed) currLimit += System.Enum.GetValues(typeof(GrenadeLaunchers)).Length;

        int randNum = Random.Range(0, currLimit);

        if(NoWeaponPossibility)
        {
            if (randNum != 0) randNum--;
            else
            {
                output_weapon = "No Weapon!";
                PlayerHasWeapon = false;
                return;
            }
        }

        if (AssaultRiflesAllowed)
        {
            int numRifles = System.Enum.GetValues(typeof(AssaultRifles)).Length;
            
            if (randNum >= numRifles) randNum -= numRifles;
            else
            {
                // Weapon found was an Assault Rifle
                var ARs = (AssaultRifles)randNum;
                output_weapon = ARs.ToString() + " Rifle";
                return;
            }
        }

        if(AssaultCarbinesAllowed)
        {
            int numCarbines = System.Enum.GetValues(typeof(AssaultCarbines)).Length;

            if (randNum >= numCarbines) randNum -= numCarbines;
            else
            {
                var carbines = (AssaultCarbines)randNum;
                output_weapon = carbines.ToString() + " Carbine";
                return;
            }
        }

        if (MarksmanRiflesAllowed)
        {
            int numMarksmans = System.Enum.GetValues(typeof(Marksmans)).Length;

            if (randNum >= numMarksmans) randNum -= numMarksmans;
            else
            {
                var marksmans = (Marksmans)randNum;
                output_weapon = marksmans.ToString() + " Marksman";
                return;
            }
        }

        if (SniperRiflesAllowed)
        {
            int numSnipers = System.Enum.GetValues(typeof(SniperRifles)).Length;

            if (randNum >= numSnipers) randNum -= numSnipers;
            else
            {
                var sniperRifle = (SniperRifles)randNum;
                output_weapon = sniperRifle.ToString() + " Sniper Rifle";
                return;
            }
        }

        if (ShotgunsAllowed)
        {
            int numShotguns = System.Enum.GetValues(typeof(Shotguns)).Length;

            if (randNum >= numShotguns) randNum -= numShotguns;
            else
            {
                var Shotgun = (Shotguns)randNum;
                output_weapon = Shotgun.ToString() + " Shotgun";
                return;
            }
        }

        if (SMGsAllowed)
        {
            int numSMGs = System.Enum.GetValues(typeof(SMGs)).Length;

            if (randNum >= numSMGs) randNum -= numSMGs;
            else
            {
                var SMGs = (SMGs)randNum;
                output_weapon = SMGs.ToString() + " SMG";
                return;
            }
        }

        if (PistolsAllowed)
        {
            int numPistols = System.Enum.GetValues(typeof(Pistols)).Length;

            if (randNum >= numPistols) randNum -= numPistols;
            else
            {
                var pistols = (Pistols)randNum;
                output_weapon = pistols.ToString() + " Pistol";
                return;
            }
        }

        if (GrenadeLaunchersAllowed)
        {
            int numGrenLaunchers = System.Enum.GetValues(typeof(GrenadeLaunchers)).Length;

            if (randNum >= numGrenLaunchers) randNum -= numGrenLaunchers;
            else
            {
                var grenLauncher = (GrenadeLaunchers)randNum;
                output_weapon = grenLauncher.ToString() + " Grenade Launcher";
                return;
            }
        }
    }

    void GetRandomAmmo()
    {
        if (!LockedOptions[0].isOn) return;

        if (!PlayerHasWeapon) return;

        if(AssaultRiflesAllowed || AssaultCarbinesAllowed || MarksmanRiflesAllowed || SniperRiflesAllowed || ShotgunsAllowed || SMGsAllowed || PistolsAllowed || GrenadeLaunchersAllowed )
        {
            var ammoMaxClass = (AmmoLimit)Random.Range(0, System.Enum.GetValues(typeof(AmmoLimit)).Length);
            output_ammo = ammoMaxClass.ToString() + " ammo limit";
        }
    }

    void GetRandomSight()
    {
        if (!LockedOptions[0].isOn) return;

        if (!PlayerHasWeapon) return;

        var randomSight = (Sights)Random.Range(0, System.Enum.GetValues(typeof(Sights)).Length);
        output_sight = randomSight.ToString() + " sight (Or equivalent)";
    }

    void GetRandomHelmet()
    {
        if (!LockedOptions[1].isOn) return;

        var randomHelmet = (Helmet)Random.Range(0, System.Enum.GetValues(typeof(Helmet)).Length);
        output_helmet = randomHelmet + " Helmet";
    }

    void GetRandomTactical()
    {
        if (!LockedOptions[2].isOn) return;

        int currLimit = 0;

        if (NoTacticalPossibility) currLimit++;

        if (ArmoredTacticalAllowed) currLimit += System.Enum.GetValues(typeof(ArmoredTactical)).Length;

        if (TacticalAllowed) currLimit += System.Enum.GetValues(typeof(TacticalRigs)).Length;

        int randNum = Random.Range(0, currLimit);

        int numTactical;

        if (randNum != 0) randNum--;
        else
        {
            if (ArmorAllowed && !ArmoredTacticalAllowed)
            {
                GetRandomArmor();
                return;
            }
            else output_armor = "No Armor or Tactical Allowed!";
        }

        if (ArmoredTacticalAllowed)
        {
            numTactical = System.Enum.GetValues(typeof(ArmoredTactical)).Length;

            if (randNum >= numTactical) randNum -= numTactical;
            else
            {
                var output = (ArmoredTactical)randNum;
                output_armor = output.ToString() + " Armored Rig";
                return;
            }
        }

        if (TacticalAllowed)
        {
            numTactical = System.Enum.GetValues(typeof(TacticalRigs)).Length;

            if (randNum >= numTactical) randNum -= numTactical;
            else
            {
                var output = (TacticalRigs)randNum;
                string outputText = output.ToString();

                if(ArmorAllowed)
                {
                    int numArmor = System.Enum.GetValues(typeof(Armor)).Length;

                    if (NoArmorPossibility) numArmor++;

                    int newArmor = Random.Range(0, numArmor);

                    if (NoArmorPossibility && newArmor == 0) outputText += " with NO armor";
                    else
                    {
                        if(NoArmorPossibility) newArmor--;

                        var newOutput = (Armor)newArmor;
                        outputText += " TacRig with " + newOutput.ToString() + " armor";
                    }
                }

                output_armor = outputText;
                return;
            }
        }
    }

    void GetRandomArmor()
    {
        string outputText = "";

        int numArmor = System.Enum.GetValues(typeof(Armor)).Length;

        if (NoArmorPossibility) numArmor++;

        int randArmor = Random.Range(0, numArmor);

        if (NoArmorPossibility && randArmor == 0) outputText += "NO Armor";
        else
        {
            if (NoArmorPossibility) randArmor--;

            var newOutput = (Armor)randArmor;

            outputText += newOutput;

        }

        outputText += " with no Tactical";

        output_armor = outputText.ToString();
        return;
    }

    void GetRandomSnack()
    {
        if (!LockedOptions[4].isOn) return;

        if (!SnacksEnabled) return;

        string output = "";
        int randomSnackAmount = Random.Range(0, 10);
        
        switch (randomSnackAmount)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                output += SnacksQuantity.One;
                break;

            case 4:
            case 5:
            case 6:
                output += SnacksQuantity.Three;
                break;

            case 7:
            case 8:
                output += SnacksQuantity.Five;
                break;

            default:
                output += SnacksQuantity.Ten;
                break;
        }

        output += " " + (Snacks)Random.Range(0, System.Enum.GetValues(typeof(Snacks)).Length) + " consumed";
        output_snacks = output;
    }

    void GetRandomQuest()
    {
        if (!LockedOptions[5].isOn) return;

        if (!QuestsEnabled) return;

        string output = "";

        // Roll for Cursed Quest
        int cursedChance = Random.Range(0, CursedQuestProbability);
        if( cursedChance != 0)
        {
            int numQuests = System.Enum.GetValues(typeof(Quests)).Length;

            int randomQuest = Random.Range(0, numQuests);

            output += (Quests)randomQuest;
        }
        else
        {
            int numCursedQuests = System.Enum.GetValues(typeof(CursedQuests)).Length;

            int randomCursedQuest = Random.Range(0, numCursedQuests);

            output += "CURSED!!! " + (CursedQuests)randomCursedQuest;
        }

        output_quest = "Quest: " + output.ToString();
    }

    void ToggleBasedGod( Toggle _change )
    {
        s_BasedGod.interactable = _change.isOn;

        Color _color = text_BasedGodProbability.color;

        if (_change.isOn)
        {
            _color.a = 1.0f;
            
            text_BasedGodProbability.text = "" + s_BasedGod.value + " in 10 chance";
        }
        else
        {
            _color.a = 0.5f;

            text_BasedGodProbability.text = "Based God is Disabled\nStandard Probabilities";
        }

        text_BasedGodProbability.color = _color;
    }

    void SliderBasedGod( Slider _change )
    {
        text_BasedGodProbability.text = "" + _change.value +  " in 10 chance";
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    float quitTimer;
    // Update is called once per frame
    void Update()
    {
        QuitTimer();
    }

    void QuitTimer()
    {
        if (quitTimer > 0f)
        {
            if( Input.GetKeyDown(KeyCode.Escape) ) Application.Quit();

            quitTimer -= Time.deltaTime;
            
            if (quitTimer < 0f) quitTimer = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) quitTimer = 1.0f;
    }
}

#pragma warning restore 0649
