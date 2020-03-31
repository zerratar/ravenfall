﻿using System.Collections.Generic;
using Shinobytes.Ravenfall.RavenNet.Core;
using Shinobytes.Ravenfall.RavenNet.Packets;

namespace Shinobytes.Ravenfall.RavenNet.Server
{
    public class ServerConnectionProvider : IRavenConnectionProvider
    {
        private readonly ILogger logger;
        private readonly IServerRegistry serverRegistry;
        private readonly INetworkPacketController packetHandlers;

        public ServerConnectionProvider(ILogger logger, IServerRegistry serverRegistry, INetworkPacketController packetHandlers)
        {
            this.logger = logger;
            this.serverRegistry = serverRegistry;
            this.packetHandlers = packetHandlers;
        }

        public RavenNetworkConnection Get(MessageReader handshakeData, Connection connection)
        {
            return new ServerClientConnection(logger, connection, serverRegistry, packetHandlers);
        }

        public IReadOnlyList<RavenNetworkConnection> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IReadOnlyList<RavenNetworkConnection> GetConnected()
        {
            throw new System.NotImplementedException();
        }
    }
}