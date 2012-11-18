using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Evolvex.RadioVolya.Tests.TagLibSharpTests
{
    [TestFixture]
    public class Basic
    {
        [Test]
        public void DoIt()
        { 
            ReadTagsWorker(@"D:\home\vmdrot\Testing\TagLibSharp\01.mp3");
        }

        [Test]
        public void DoIt2() { ReadTagsWorker(@"D:\home\vmdrot\Testing\TagLibSharp\02.mp3"); }
        [Test]
        public void DoIt3() { ReadTagsWorker(@"D:\home\vmdrot\Testing\TagLibSharp\03.mp3"); }
        [Test]
        public void DoIt4() { ReadTagsWorker(@"D:\home\vmdrot\Testing\TagLibSharp\04.mp3"); }
        [Test]
        public void DoIt5() { ReadTagsWorker(@"D:\home\vmdrot\Testing\TagLibSharp\05.mp3"); }

        private void ReadTagsWorker(String path)
        {
            TagLib.File mp3file = TagLib.File.Create(path);
            TagLib.Tag tag1 = mp3file.GetTag(TagLib.TagTypes.Id3v1);
            TagLib.Tag tag2 = mp3file.GetTag(TagLib.TagTypes.Id3v2);
            
            Console.WriteLine(TagToString(tag1));
            Console.WriteLine(TagToString(tag2));
        }

        private string TagToString(TagLib.Tag tag)
        {
            return String.Format("Artist: '{0}', Album: '{1}', Title: '{2}', Year: {3}, Genres[0]:'{4}', Comment: '{5}'", tag.Artists[0], tag.Album, tag.Title, tag.Year, tag.Genres[0], tag.Comment);
        }

    }
}
