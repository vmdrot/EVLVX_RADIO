using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.RadioVolya.Core.DIServiceContracts;
using Evolvex.RadioVolya.GenericDAL.Interfaces;

namespace Evolvex.RadioVolya.YouthChannelSimpleScheduler.Impls.Basic
{
    public class BasicChannelGenerator: IPlaylistGenerator
    {
        #region const(s)
        private const int MinSameArtistAbstand = 20;
        private const int MinSameForeignLangAbstand = 4; //except English
        private static readonly Dictionary<string, int> _minTagAbstands;
        private const int MinJingleAbstand = 3;
        private const int MaxJingleAbstand = 7;
        private const int MinSameJingleAbstand = 20;
        #endregion

        static BasicChannelGenerator()
        {
            _minTagAbstands = new Dictionary<string, int>();
            #region
            //todo - populate
            #endregion
        }

        #region IPlaylistGenerator Members

        public List<ITrackInfo> Generate()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
