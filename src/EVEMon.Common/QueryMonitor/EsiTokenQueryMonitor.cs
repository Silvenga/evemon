using System;

using EVEMon.Common.Enumerations;
using EVEMon.Common.Net;

using IdentityModel;
using IdentityModel.Client;

namespace EVEMon.Common.QueryMonitor
{
    public class EsiTokenQueryMonitor : INetworkChangeSubscriber
    {
        private readonly string _initialRefreshToken;
        private readonly Action<EsiTokenQueryUpdate> _onEsiTokenUpdate;
        private readonly TokenClient _client;
        private EsiTokenQueryUpdate lastResult;

        public bool SetNetworkStatus { get; set; }

        public bool IsUpdating { get; set; }

        public QueryStatus Status { get; set; }

        public DateTimeOffset NextUpdate
        {
            get => (lastResult?.ExpiresAfter ?? DateTimeOffset.Now).AddMinutes(-5);
        }

        public DateTimeOffset LastUpdate { get; set; }

        private EsiTokenQueryMonitor()
        {
            NetworkMonitor.Register(this);
            EveMonClient.TimerTick += EveMonClientOnTimerTick;
        }

        public EsiTokenQueryMonitor(string initialRefreshToken, string clientId, string clientSecret, Action<EsiTokenQueryUpdate> onEsiTokenUpdate) : this()
        {
            _initialRefreshToken = initialRefreshToken;
            _onEsiTokenUpdate = onEsiTokenUpdate;
            // TODO Don't hard code this url.
            _client = new TokenClient("https://login.eveonline.com/oauth/token", clientId, clientSecret);
        }

        private void EveMonClientOnTimerTick(object sender, EventArgs e)
        {
            if (IsUpdating)
            {
                return;
            }

            // Do we have a network ?
            if (!NetworkMonitor.IsNetworkAvailable)
            {
                Status = QueryStatus.NoNetwork;
                return;
            }

            // Is it an auto-update test ?
            // If not due time yet, quits
            if (NextUpdate > DateTimeOffset.Now)
            {
                Status = QueryStatus.Pending;
                return;
            }

            // Starts the update
            IsUpdating = true;
            Status = QueryStatus.Updating;
            Query();
        }

        private void Query()
        {
            _client.RequestRefreshTokenAsync(_initialRefreshToken)
                   .ContinueWith(task => QueryCompleted(task.Result));
        }

        private void QueryCompleted(TokenResponse response)
        {
            var update = new EsiTokenQueryUpdate
            {
                RefreshToken = response.RefreshToken,
                AccessToken = response.AccessToken,
                ExpiresAfter = response.ExpiresIn.ToDateTimeOffsetFromEpoch()
            };
            lastResult = update;
            LastUpdate = DateTimeOffset.Now;

            _onEsiTokenUpdate(update);
        }
    }

    public class EsiTokenQueryUpdate
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public DateTimeOffset ExpiresAfter { get; set; }
    }
}