using Gldf.Net.Abstract;
using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Xml;
using Gldf.Net.Parser;
using Gldf.Net.Parser.State;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks.Dataflow;

namespace Gldf.Net
{
    public class GldfParser : IGldfParser
    {
        public RootTyped ParseFromXml(string xml, bool loadOnlineFileContent = false)
        {
            var transformXml = new TransformBlock<string, ContainerDto>(gldfXml => XmlTransform.Instance.Map(gldfXml, loadOnlineFileContent));
            var broadcastXml = new BroadcastBlock<ContainerDto>(dto => dto);
            var transformFiles = new TransformBlock<ContainerDto, ParserDto<GldfFileTyped>>(FilesTransform.Instance.Map);
            var transformControlGears = new TransformBlock<ContainerDto, ParserDto<ControlGearTyped>>(ControlGearsTransform.Instance.Map);
            var broadcastFiles = new BroadcastBlock<ParserDto<GldfFileTyped>>(filesDto => filesDto);
            var transformSensors = new TransformBlock<ParserDto<GldfFileTyped>, ParserDto<SensorTyped>>(SensorTransform.Instance.Map);
            var transformPhotometry = new TransformBlock<ParserDto<GldfFileTyped>, ParserDto<PhotometryTyped>>(PhotometryTransform.Instance.Map);
            var transformSpectrums = new TransformBlock<ParserDto<GldfFileTyped>, ParserDto<SpectrumTyped>>(SpectrumTransform.Instance.Map);
            
            var transformFinal = new JoinBlock<ParserDto<SensorTyped>, ParserDto<PhotometryTyped>>();
            
            // var batchBlock = new BatchBlock<ParserDto>(2, new GroupingDataflowBlockOptions { Greedy = false });

            // Ebene 1: XML Parsen
            transformXml.LinkTo(broadcastXml);
            
            // Ebene 2: Files + Header + ControlGears
            broadcastXml.LinkTo(transformFiles);
            broadcastXml.LinkTo(transformControlGears);
            transformFiles.LinkTo(broadcastFiles);
            broadcastFiles.LinkTo(transformSensors);
            broadcastFiles.LinkTo(transformPhotometry);
            broadcastFiles.LinkTo(transformSpectrums);
            
            // Ebene 3: Final
            transformSensors.LinkTo(transformFinal.Target1);
            transformPhotometry.LinkTo(transformFinal.Target2);
            
            // transformSensors.LinkTo(transformFinal.Target1);
            // transformPhotometry.LinkTo(transformFinal.Target2);
            // transformSensors.LinkTo(batchBlock);
            // transformPhotometry.LinkTo(batchBlock);

            var resetEvent = new AutoResetEvent(false);
            // var actionBlock = new ActionBlock<Tuple<SensorDto, PhotometryDto>>(tuple =>
            // {
            //     Console.WriteLine($"Tuple received in Lambda: {tuple.Item1 != null}, {tuple.Item2 != null}");
            //     resetEvent.Set();
            // });
            
            var actionBlock = new ActionBlock<Tuple<ParserDto<SensorTyped>, ParserDto<PhotometryTyped>>>(tuple =>
            {
                // Console.WriteLine($"Tuple received in Lambda: {tuple.Item1 != null}, {tuple.Item2 != null}");
                Console.WriteLine("Tuple received in Lambda:\n" +
                                  $"{tuple.Item1.Items.Count}. {tuple.Item1.Items.First().GetType()},\n" +
                                  $"{tuple.Item2.Items.Count}. {tuple.Item2.Items.First().GetType()},\n");
                resetEvent.Set();
            });
            
            transformFinal.LinkTo(actionBlock);
            // batchBlock.LinkTo(actionBlock);
            // batchBlock.LinkTo(transformBlock);

            transformXml.Post(xml);
            resetEvent.WaitOne();
            return new RootTyped();
        }

        public RootTyped ParseFromXmlFile(string xmlFilePath, bool loadOnlineFileContent = false)
        {
            throw new NotImplementedException();
        }

        public RootTyped ParseFromRoot(Root root, bool loadOnlineFileContent = false)
        {
            throw new NotImplementedException();
        }

        public RootTyped ParseFromContainerFile(string containerfilePath, bool loadFileContent = false)
        {
            throw new NotImplementedException();
        }
    }
}