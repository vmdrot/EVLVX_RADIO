using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Evolvex.RadioVolya.DAL.Models.Mapping;

namespace Evolvex.RadioVolya.DAL.Models
{
    public class RadioMusicLibContext : DbContext
    {
        static RadioMusicLibContext()
        {
            Database.SetInitializer<RadioMusicLibContext>(null);
        }

		public RadioMusicLibContext()
			: base("Name=RadioMusicLibContext")
		{
		}

        public DbSet<tbl_artist> tbl_artist { get; set; }
        public DbSet<tbl_radio_stream> tbl_radio_stream { get; set; }
        public DbSet<tbl_ref_country> tbl_ref_country { get; set; }
        public DbSet<tbl_ref_lang> tbl_ref_lang { get; set; }
        public DbSet<tbl_ref_music_genre> tbl_ref_music_genre { get; set; }
        public DbSet<tbl_ref_music_mood> tbl_ref_music_mood { get; set; }
        public DbSet<tbl_ref_music_tempo> tbl_ref_music_tempo { get; set; }
        public DbSet<tbl_schedule_block> tbl_schedule_block { get; set; }
        public DbSet<tbl_schedule_rule> tbl_schedule_rule { get; set; }
        public DbSet<tbl_tag> tbl_tag { get; set; }
        public DbSet<tbl_tag_mm_date> tbl_tag_mm_date { get; set; }
        public DbSet<tbl_track> tbl_track { get; set; }
        public DbSet<tbl_track_mm_artist> tbl_track_mm_artist { get; set; }
        public DbSet<tbl_track_mm_genre> tbl_track_mm_genre { get; set; }
        public DbSet<tbl_track_mm_lang> tbl_track_mm_lang { get; set; }
        public DbSet<tbl_track_mm_mood> tbl_track_mm_mood { get; set; }
        public DbSet<tbl_track_mm_tag> tbl_track_mm_tag { get; set; }
        public DbSet<tbl_track_play_history> tbl_track_play_history { get; set; }
        public DbSet<tbl_track_schedule> tbl_track_schedule { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new tbl_artistMap());
            modelBuilder.Configurations.Add(new tbl_radio_streamMap());
            modelBuilder.Configurations.Add(new tbl_ref_countryMap());
            modelBuilder.Configurations.Add(new tbl_ref_langMap());
            modelBuilder.Configurations.Add(new tbl_ref_music_genreMap());
            modelBuilder.Configurations.Add(new tbl_ref_music_moodMap());
            modelBuilder.Configurations.Add(new tbl_ref_music_tempoMap());
            modelBuilder.Configurations.Add(new tbl_schedule_blockMap());
            modelBuilder.Configurations.Add(new tbl_schedule_ruleMap());
            modelBuilder.Configurations.Add(new tbl_tagMap());
            modelBuilder.Configurations.Add(new tbl_tag_mm_dateMap());
            modelBuilder.Configurations.Add(new tbl_trackMap());
            modelBuilder.Configurations.Add(new tbl_track_mm_artistMap());
            modelBuilder.Configurations.Add(new tbl_track_mm_genreMap());
            modelBuilder.Configurations.Add(new tbl_track_mm_langMap());
            modelBuilder.Configurations.Add(new tbl_track_mm_moodMap());
            modelBuilder.Configurations.Add(new tbl_track_mm_tagMap());
            modelBuilder.Configurations.Add(new tbl_track_play_historyMap());
            modelBuilder.Configurations.Add(new tbl_track_scheduleMap());
        }
    }
}
