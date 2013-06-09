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
    public class XmlImporterTests
    {
        [Test]
        public void Import()
        {
            XmlImporter importer = new XmlImporter();
            importer.Import(@"D:\home\vmdrot\DEV\Evolvex.RadioVolya.MediaContentScheduler\Testing\Data\all_edited.xml");
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
