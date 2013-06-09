using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.RadioVolya.GenericDAL.Interfaces;
using System.Globalization;
using System.Reflection;

namespace Evolvex.RadioVolya.DAL.Models
{
    public partial class tbl_track: ITrackInfo
    {

        #region ITrackInfo Members

        public int ID
        {
            get
            {
                return this.track_id;
            }
            set
            {
                this.track_id = value;
            }
        }

        public string Title
        {
            get
            {
                return this.track_nm;
            }
            set
            {
                this.track_nm = value;
            }
        }

        public GenericDAL.Enums.TrackKind Kind
        {
            get
            {
                return (Evolvex.RadioVolya.GenericDAL.Enums.TrackKind)this.track_kind_id;
            }
            set
            {
                this.track_kind_id = (int)value;
            }
        }

        public IList<IArtistInfo> Artists {get;set;}

        public IList<IGenre> Genres {get;set;}

        public IList<IMood> Moods {get;set;}
        public IList<ITag> Tags {get;set;}

        public IList<IRadioChannel> Channels {get;set;}

        public int LCID { get { return this.LCIDs[0];} }

        public string LanguageCode
        {
            get { return CultureInfo.GetCultureInfo(LCID).IetfLanguageTag; }
        }

        public int BPM {get;set;}
        public TimeSpan Duration {get;set;}

        public string PhysicalPath { get; set; }

        #endregion

        #region ITrackInfo Members


        public IList<int> LCIDs {get;set;}

        private IList<string> _languageCodes;
        public IList<string> LanguageCodes
        {
            get 
            {
                if (_languageCodes == null)
                {
                    if (LCIDs == null)
                        return null;
                    _languageCodes = new List<string>();
                    foreach (int lcid in LCIDs)
                        _languageCodes.Add(CultureInfo.GetCultureInfo(lcid).IetfLanguageTag);
                }
                return _languageCodes;
            }
        }

        #endregion

        #region ITrackInfo Members


        public string Album {get;set;}

        public int Year {get;set;}

        public int Bitrate {get;set;}
        
        public int AudioChannels {get;set;}

        public int AudioSampleRate {get;set;}

        public string AudioDescription {get;set;}

        public string RenameTo { get; set; }

        #endregion

        public override string ToString()
        {
            PropertyInfo[] pis = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance);
            StringBuilder rslt = new StringBuilder();

            for (int i = 0; i < pis.Length; i++)
            {
                if (i > 0)
                    rslt.Append(", ");
                PropertyInfo pi = pis[i];
                rslt.AppendFormat("{0}: ", pi.Name);
                //if (pi.PropertyType == typeof(int) || pi.PropertyType == typeof(long) || pi.PropertyType == typeof(double) || pi.PropertyType == typeof(decimal) || pi.PropertyType == typeof(float) || pi.PropertyType == typeof(bool))
                object val = pi.GetValue(this, null);
                if (val == null)
                {
                    rslt.Append("null");
                    continue;
                }
                if (pi.PropertyType == typeof(String) || pi.PropertyType == typeof(string))
                {
                    rslt.Append(String.Format("\"{0}\"", val as string));
                    continue;
                }
                else if (pi.PropertyType == typeof(char))
                {
                    rslt.Append(String.Format("'{0}'", (char)val));
                    continue;
                }
                else
                {
                    rslt.Append(String.Format("{0}", val));
                    continue;
                }
            }
            return rslt.ToString();
        }
    }
}
