﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.RadioVolya.GenericDAL.Interfaces
{
    public interface ITrackScheduleRetriever
    {
        DateTime GetPlayedBeforeTime(int trackId, DateTime beingScheduledAt);
    }
}