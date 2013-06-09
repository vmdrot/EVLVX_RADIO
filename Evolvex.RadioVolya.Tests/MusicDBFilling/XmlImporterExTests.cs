using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Evolvex.RadioVolya.DAL.Import;
using Evolvex.RadioVolya.GenericDAL.Interfaces;

namespace Evolvex.RadioVolya.Tests.MusicDBFilling
{
    [TestFixture]
    public class XmlImporterExTests
    {
        [Test]
        public void Import()
        {
            XmlImporterEx importer = new XmlImporterEx();
            //importer.Import(@"D:\home\vmdrot\DEV\Evolvex.RadioVolya.MediaContentScheduler\Testing\Data\all_edited.xml");
            importer.Import(@"D:\home\vmdrot\DEV\Evolvex.RadioVolya.MediaContentScheduler\Testing\Data\all.xml");
            PrintRslts(importer.Tracks);
        }

        [Test]
        public void ImportCut()
        {
            XmlImporterEx importer = new XmlImporterEx();
            importer.Import(@"D:\home\vmdrot\DEV\Evolvex.RadioVolya.MediaContentScheduler\Testing\Data\test_cut.xml");
            PrintRslts(importer.Tracks);
        }
        
        private void PrintRslts(List<ITrackInfo> list)
        {
            foreach (ITrackInfo ti in list)
            {
                Console.WriteLine(ti);
            }
        }
    }
}
