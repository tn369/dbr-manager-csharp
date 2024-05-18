﻿using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Rival(PlayerId playerId, PlayerId rivalId)
    {
        public PlayerId PlayerId { get; private set; } = playerId;
        public PlayerId RivalId { get; private set; } = rivalId;
    }

}
