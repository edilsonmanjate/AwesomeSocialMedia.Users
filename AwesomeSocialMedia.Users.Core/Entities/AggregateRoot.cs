﻿using AwesomeSocialMedia.Users.Core.Events;

namespace AwesomeSocialMedia.Users.Core.Entities;

public abstract class AggregateRoot : BaseEntity   
{
    protected AggregateRoot() : base()
    {
        Events = new List<IEvent>();
    }

    public List<IEvent> Events { get; private set; }
}
 