using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.RadioVolya.Core.DIServiceContracts;
using Evolvex.RadioVolya.GenericDAL.Interfaces;

namespace Evolvex.RadioVolya.YouthChannelSimpleScheduler.Impls.YouthChannel
{
    public class YouthChannelGenerator: IPlaylistGenerator
    {

        private String[] _dimensions = new string[] { "LCID", "GenreId", "Artist", "Track" };
        /*
         * Quotas
         * {
         *  (LCID == uk): >= 60%
         *  (Genre in (retro, non-hit, folk, classics): <= 10%
         *  abstand btw the same artist  - >= 20 tracks
         *  abstand btw the same language (except uk) = in proportion to the population :)
         *  (LCID == en): <=25%
         *  abstand btw the same country (except UA) = in proportion to the population :)
         * }
         * 
         * Jingles
         * {
         *   insert btw each 3-5 songs
         *   abstand btw the same jingle  >= 20 jingles
         *   abstand btw the same artist >= 5
         * }
         */


        #region IPlaylistGenerator Members

        public List<ITrackInfo> Generate()
        {
            throw new NotImplementedException();
        }

        private List<ITrackInfo> GenerateWorker()
        {
            List<ITrackInfo> rslt = new List<ITrackInfo>();
            IRandomTrackDispenser ukrDispenser;
            IRandomTrackDispenser inshoMovn;
            //todo

            ITrackInfo ti;
            
            return rslt;
        }
        #endregion
    }
}
