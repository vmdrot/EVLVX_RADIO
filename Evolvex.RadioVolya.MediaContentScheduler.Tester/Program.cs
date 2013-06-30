using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.RadioVolya.DAL.Import;
using Evolvex.RadioVolya.GenericDAL.Interfaces;
using System.Xml;
using System.IO;
using Evolvex.RadioVolya.MediaContentScheduler.Tester.Data;
using Newtonsoft.Json;

namespace Evolvex.RadioVolya.MediaContentScheduler.Tester
{
    class Program
    {

        public delegate void CmdHandler(string[] args);
        private static readonly Dictionary<string, CmdHandler> _cmdHandlers;


        static Program()
        {
            _cmdHandlers = new Dictionary<string, CmdHandler>();
            _cmdHandlers.Add("testxmlimporter", TestXmlImporter);
            _cmdHandlers.Add("testxmlimporterex", TestXmlImporterEx);
            _cmdHandlers.Add("testxmlimporterexcut", TestXmlImporterExCut);
            _cmdHandlers.Add("testxmlimporterex2", TestXmlImporterEx2);
            _cmdHandlers.Add("validatexml", ValidateXml);
            _cmdHandlers.Add("validatexml2", ValidateXml2);
            _cmdHandlers.Add("export", Export);
        }

        static void Main(string[] args)
        {
            //Console.Read();
            string cmdHandlerKey = string.Empty;
            if(args.Length > 0)
                cmdHandlerKey = args[0].ToLower();
            try
            {
                if (string.IsNullOrEmpty(cmdHandlerKey) || !_cmdHandlers.ContainsKey(cmdHandlerKey))
                    TestXmlImporter(args);
                else
                    _cmdHandlers[cmdHandlerKey](args);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
       }

        private static void TestXmlImporter(string[] args)
        {
            XmlImporter importer = new XmlImporter();
            importer.Import(@"D:\home\vmdrot\DEV\Evolvex.RadioVolya.MediaContentScheduler\Testing\Data\all_edited.xml");
            PrintRslts(importer.Tracks);
        }


        private static void TestXmlImporterEx(string[] args)
        {
            XmlImporterEx importer = new XmlImporterEx();
            //importer.Import(@"D:\home\vmdrot\DEV\Evolvex.RadioVolya.MediaContentScheduler\Testing\Data\all_edited.xml");
            importer.Import(@"D:\home\vmdrot\DEV\Evolvex.RadioVolya.MediaContentScheduler\Testing\Data\all.xml");
            PrintRslts(importer.Tracks);
        }

        private static void TestXmlImporterExCut(string[] args)
        {
            XmlImporterEx importer = new XmlImporterEx();
            importer.Import(@"D:\home\vmdrot\DEV\Evolvex.RadioVolya.MediaContentScheduler\Testing\Data\test_cut.xml");
            PrintRslts(importer.Tracks);
        }

        private static void TestXmlImporterEx2(string[] args)
        {
            string filePath = args[1];
            XmlImporterEx importer = new XmlImporterEx();
            importer.Import(filePath);
            PrintRslts(importer.Tracks);
        }

        private static void ValidateXml(string[] args)
        {
            string filePath = args[1];
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            Console.WriteLine(doc.ChildNodes.Count);
        }

        private static void ValidateXml2(string[] args)
        {
            string filePath = args[1];

            int reads = 0;
            using (XmlReader r = XmlReader.Create(filePath))
            {
                while(r.Read())
                    reads++;
            }
            Console.WriteLine(reads);
        }


        private static void Export(string[] args)
        {
            string srcFolder = args[1];
            string outputPath = args[2];
            string encodingName = args[3];
            Encoding enc = Encoding.GetEncoding(encodingName);
            string[] mp3s = Directory.GetFiles(srcFolder, "*.mp3", SearchOption.AllDirectories);
            List<MP3info> infos = new List<MP3info>();
            foreach (string file in mp3s)
            {
                MP3info mp3i = MP3info.GetMP3Info(file);
                if (mp3i != null)
                    infos.Add(mp3i);
            }

            Console.WriteLine("infos.Count = {0}", infos.Count);
            //using (StreamWriter sw = new StreamWriter(@"D:\home\vmdrot\HaErez\RadioVolya\Sounds\all.csv",false, Encoding.Unicode))
            //{
            //    //Console.WriteLine("Title,Album,Year,Genre,PhysicalPath,Comment,AudioBitrate,AudioChannels,AudioSampleRate,BitsPerSample,Description,Duration");
            //    sw.WriteLine("Title,Album,Year,Genre,PhysicalPath,Comment,AudioBitrate,AudioChannels,AudioSampleRate,BitsPerSample,Description,Duration");
            //    foreach (MP3info info in infos)
            //        sw.WriteLine(info.ToString());
            //        //Console.WriteLine(info.ToString());
            //}

            using (StreamWriter sw = new StreamWriter(outputPath, false, enc))
            {

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Encoding = Encoding.Unicode;
                //settings.Encoding = target.;
                settings.Indent = true;
                settings.OmitXmlDeclaration = false;
                const string PARENT_ELEM_NM = "Tracks";

                using (XmlWriter w = XmlWriter.Create(sw.BaseStream, settings))
                {
                    w.WriteStartElement(PARENT_ELEM_NM);
                    foreach (MP3info info in infos)
                        info.ToXml(w);
                    w.WriteEndElement();
                }
            }
        }

        private static void PrintRslts(List<ITrackInfo> list)
        {
            foreach (ITrackInfo ti in list)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ti));
            }
        }
    }
}

