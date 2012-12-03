using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.RadioVolya.GenericDAL.Interfaces
{
    public interface ITrackScheduleRetriever
    {
        DateTime GetTrackPlayedBeforeTime(int trackId, DateTime beingScheduledAt);
        int GetTrackAbstandTracks(int trackId, DateTime beingScheduledAt);

        DateTime GetArtistPlayedBeforeTime(int artistId, DateTime beingScheduledAt);
        int GetArtistAbstandTracks(int artistId, DateTime beingScheduledAt);

        DateTime GetLangPlayedBeforeTime(int lcid, DateTime beingScheduledAt);
        int GetLangAbstandTracks(int lcid, DateTime beingScheduledAt);
    }
}
