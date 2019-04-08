#region Using directives

using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LootTableEnum
    {
        [XmlEnum("None")] None,

        //
        [XmlEnum("NuggetSmall")] Small,
        [XmlEnum("NuggetMedium")] Medium,
        [XmlEnum("NuggetLarge")] Large,
        [XmlEnum("Nugget_Legendary")] Legendary,

        //
        [XmlEnum("Tables\\Nugget_MapleTree")] MapleTree,
        [XmlEnum("Tables\\Nugget_Learicorn")] Learicorn,
        [XmlEnum("Tables\\Nugget_SH_MapleTree")] ShMapleTree,
        [XmlEnum("Tables\\Nugget_SH_Statue")] ShStatue,
        [XmlEnum("Tables\\Nugget_SH_CraftStore")] ShCraftStore,
        [XmlEnum("Tables\\Nugget_SH_Honey")] ShHoney,
        [XmlEnum("Tables\\Nugget_SH_IsisTemple")] ShIsisTemple,
        [XmlEnum("Tables\\Nugget_SH_TikiTemple")] ShTikiTemple,

        //
        [XmlEnum("general")] General,
        [XmlEnum("general_legendary")] GeneralLegendary,
        [XmlEnum("general_campaign")] GeneralCampaign,
        [XmlEnum("tables\\_coreloot_vanityticket")] VanityTicket,
        [XmlEnum("tables\\_coreloot_celtwarrior_reward")] CeltWarrior,
        [XmlEnum("tables\\_coreloot_celtdruid_reward")] CeltDruid,
        [XmlEnum("tables\\_coreloot_celthigh_reward")] CeltHigh,

        //
        [XmlEnum("tables\\_coreloot_weekly")] Weekly,
        [XmlEnum("tables\\_coreloot_booster1")] Booster1,

        //
        [XmlEnum("general_skirmish")] GeneralSkirmish,

        //
        [XmlEnum("General_GoldenTicketRare")] GeneralGoldenTicketRare,
        [XmlEnum("General_GoldenTicketUncommon")] GeneralGoldenTicketUncommon,

        //
        [XmlEnum("general_gambling")] GeneralGambling,
        [XmlEnum("tables\\_coreloot_ticket")] LottoTicket,

        //
        [XmlEnum("celeste_legendary")] CelesteLegendary,
        [XmlEnum("celeste_newathens_uprissing")] CelesteNewAthensUprissing,

        //
        [XmlEnum("celeste_leg_gear_classic_ep")] LegendaryGearClassicEpChest,
        [XmlEnum("celeste_leg_gear_celeste_ep")] LegendaryGearCelesteEpChest,
        [XmlEnum("celeste_epic_advisor_ep")] EpicAdvisorCelesteEpChest,
        [XmlEnum("celeste_epic_gear_ep")] EpicGearCelesteEpChest,

        //
        [XmlEnum("celeste_chest_fp")] FactionChest,
        [XmlEnum("celeste_leg_chest_fp")] FactionChestLegendary,

        //
        [XmlEnum("celeste_leg_only_event")] LegendaryOnlyAll,
        [XmlEnum("celeste_epic_leg_only_event")] EpicLegendaryOnlyAll,
        [XmlEnum("celeste_epic_only_event")] EpicOnlyAll,

        [XmlEnum("Nugget_Legendary_Event")] LegendaryEvent,

        //
        [XmlEnum("celeste_winter_supply")] WinterSupplyChest
    }
}