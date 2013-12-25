﻿using System;

namespace Contracts
{
    public class ApplicationState
    {
        public ApplicationState()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }
        public Guid? CurrentRace { get; set; }
        public Guid? CurrentUser { get; set; }
    }
}