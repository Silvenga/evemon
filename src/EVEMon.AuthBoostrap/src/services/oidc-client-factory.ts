import { OidcClient } from 'oidc-client';

const AllScopes = "corporationContactsRead publicData characterStatsRead characterFittingsRead characterFittingsWrite characterContactsRead characterContactsWrite characterLocationRead characterNavigationWrite characterWalletRead characterAssetsRead characterCalendarRead characterFactionalWarfareRead characterIndustryJobsRead characterKillsRead characterMailRead characterMarketOrdersRead characterMedalsRead characterNotificationsRead characterResearchRead characterSkillsRead characterAccountRead characterContractsRead characterBookmarksRead characterChatChannelsRead characterClonesRead characterOpportunitiesRead characterLoyaltyPointsRead corporationWalletRead corporationAssetsRead corporationMedalsRead corporationFactionalWarfareRead corporationIndustryJobsRead corporationKillsRead corporationMembersRead corporationMarketOrdersRead corporationStructuresRead corporationShareholdersRead corporationContractsRead corporationBookmarksRead fleetRead fleetWrite structureVulnUpdate remoteClientUI esi-calendar.respond_calendar_events.v1 esi-calendar.read_calendar_events.v1 esi-location.read_location.v1 esi-location.read_ship_type.v1 esi-mail.organize_mail.v1 esi-mail.read_mail.v1 esi-mail.send_mail.v1 esi-skills.read_skills.v1 esi-skills.read_skillqueue.v1 esi-wallet.read_character_wallet.v1 esi-wallet.read_corporation_wallet.v1 esi-search.search_structures.v1 esi-clones.read_clones.v1 esi-characters.read_contacts.v1 esi-universe.read_structures.v1 esi-bookmarks.read_character_bookmarks.v1 esi-killmails.read_killmails.v1 esi-corporations.read_corporation_membership.v1 esi-assets.read_assets.v1 esi-planets.manage_planets.v1 esi-fleets.read_fleet.v1 esi-fleets.write_fleet.v1 esi-ui.open_window.v1 esi-ui.write_waypoint.v1 esi-characters.write_contacts.v1 esi-fittings.read_fittings.v1 esi-fittings.write_fittings.v1 esi-markets.structure_markets.v1 esi-corporations.read_structures.v1 esi-corporations.write_structures.v1 esi-characters.read_loyalty.v1 esi-characters.read_opportunities.v1 esi-characters.read_chat_channels.v1 esi-characters.read_medals.v1 esi-characters.read_standings.v1 esi-characters.read_agents_research.v1 esi-industry.read_character_jobs.v1 esi-markets.read_character_orders.v1 esi-characters.read_blueprints.v1 esi-characters.read_corporation_roles.v1 esi-location.read_online.v1 esi-contracts.read_character_contracts.v1 esi-clones.read_implants.v1 esi-characters.read_fatigue.v1 esi-killmails.read_corporation_killmails.v1 esi-corporations.track_members.v1 esi-wallet.read_corporation_wallets.v1 esi-characters.read_notifications.v1 esi-corporations.read_divisions.v1 esi-corporations.read_contacts.v1 esi-assets.read_corporation_assets.v1 esi-corporations.read_titles.v1 esi-corporations.read_blueprints.v1 esi-bookmarks.read_corporation_bookmarks.v1 esi-contracts.read_corporation_contracts.v1 esi-corporations.read_standings.v1 esi-corporations.read_starbases.v1 esi-industry.read_corporation_jobs.v1 esi-markets.read_corporation_orders.v1 esi-corporations.read_container_logs.v1 esi-industry.read_character_mining.v1 esi-industry.read_corporation_mining.v1 esi-planets.read_customs_offices.v1 esi-corporations.read_facilities.v1 esi-corporations.read_medals.v1 esi-characters.read_titles.v1 esi-alliances.read_contacts.v1 esi-characters.read_fw_stats.v1 esi-corporations.read_fw_stats.v1 esi-corporations.read_outposts.v1 esi-characterstats.read.v1";

export class OidcClientFactory {

    public create(clientId: string) {
        return new OidcClient({
            authority: "nothing",
            client_id: clientId,
            scope: AllScopes,
            response_type: "code",
            redirect_uri: window.location.href,
            metadata: {
                issuer: "",
                userinfo_endpoint: "",
                end_session_endpoint: "",
                jwks_uri: "",
                authorization_endpoint: "https://login.eveonline.com/oauth/authorize"
            }
        });
    }
}