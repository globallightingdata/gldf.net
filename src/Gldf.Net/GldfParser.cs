using Gldf.Net.Abstract;
using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
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
            // todo IGldfXmlSerializer aus Konstruktor reinreichen in den ersten Block
            // todo In Klassen auslagern

            var transformXml = new TransformBlock<string, ContainerDto>(gldfXml => XmlTransform.Instance.Map(gldfXml, loadOnlineFileContent));
            var broadcastXml = new BroadcastBlock<ContainerDto>(dto => dto);

            var transformFiles = new TransformBlock<ContainerDto, ParserDto<GldfFileTyped>>(FilesTransform.Instance.Map);
            var broadcastFiles = new BroadcastBlock<ParserDto<GldfFileTyped>>(filesDto => filesDto);

            var transformControlGears = new TransformBlock<ContainerDto, ParserDto<ControlGearTyped>>(ControlGearsTransform.Instance.Map);
            var transformSimpleGeo = new TransformBlock<ContainerDto, ParserDto<SimpleGeometryTyped>>(SimpleGeometryTransform.Instance.Map);
            var transformSensors = new TransformBlock<ParserDto<GldfFileTyped>, ParserDto<SensorTyped>>(SensorTransform.Instance.Map);
            var transformPhotometry = new TransformBlock<ParserDto<GldfFileTyped>, ParserDto<PhotometryTyped>>(PhotometryTransform.Instance.Map);
            var transformSpectrums = new TransformBlock<ParserDto<GldfFileTyped>, ParserDto<SpectrumTyped>>(SpectrumTransform.Instance.Map);
            var transformModelGeo = new TransformBlock<ParserDto<GldfFileTyped>, ParserDto<ModelGeometryTyped>>(ModelGeometryTransform.Instance.Map);

            var joinLightSourcesDeps = new JoinBlock<ParserDto<GldfFileTyped>, ParserDto<PhotometryTyped>, ParserDto<SpectrumTyped>>();
            var broadcastLightSources =
                new BroadcastBlock<Tuple<ParserDto<GldfFileTyped>, ParserDto<PhotometryTyped>, ParserDto<SpectrumTyped>>>(dto => dto);
            var transformChangeableLightSources = new TransformBlock<
                Tuple<ParserDto<GldfFileTyped>, ParserDto<PhotometryTyped>, ParserDto<SpectrumTyped>>,
                ParserDto<ChangeableLightSourceTyped>>(ChangeableLightSourceTransform.Instance.Map);
            var transformFixedLightSources = new TransformBlock<
                Tuple<ParserDto<GldfFileTyped>, ParserDto<PhotometryTyped>, ParserDto<SpectrumTyped>>,
                ParserDto<FixedLightSourceTyped>>(FixedLightSourceTransform.Instance.Map);

            var transformFinal = new JoinBlock<ParserDto<ChangeableLightSourceTyped>, ParserDto<FixedLightSourceTyped>>();

            // var batchBlock = new BatchBlock<ParserDto>(2, new GroupingDataflowBlockOptions { Greedy = false });

            // Ebene 1: XML Parsen
            transformXml.LinkTo(broadcastXml);

            // Ebene 2: Files + Header + ControlGears
            broadcastXml.LinkTo(transformFiles);
            broadcastXml.LinkTo(transformControlGears);
            broadcastXml.LinkTo(transformSimpleGeo);
            transformFiles.LinkTo(broadcastFiles);
            broadcastFiles.LinkTo(transformSensors);
            broadcastFiles.LinkTo(transformPhotometry);
            broadcastFiles.LinkTo(transformSpectrums);
            broadcastFiles.LinkTo(transformModelGeo);

            // Ebene 3: LightSources
            broadcastFiles.LinkTo(joinLightSourcesDeps.Target1);
            transformPhotometry.LinkTo(joinLightSourcesDeps.Target2);
            transformSpectrums.LinkTo(joinLightSourcesDeps.Target3);
            joinLightSourcesDeps.LinkTo(broadcastLightSources);
            broadcastLightSources.LinkTo(transformChangeableLightSources);
            broadcastLightSources.LinkTo(transformFixedLightSources);

            // Ebene 4: Final
            transformChangeableLightSources.LinkTo(transformFinal.Target1);
            transformFixedLightSources.LinkTo(transformFinal.Target2);

            // transformSensors.LinkTo(batchBlock);
            // transformPhotometry.LinkTo(batchBlock);

            var resetEvent = new AutoResetEvent(false);
            // var actionBlock = new ActionBlock<Tuple<SensorDto, PhotometryDto>>(tuple =>
            // {
            //     Console.WriteLine($"Tuple received in Lambda: {tuple.Item1 != null}, {tuple.Item2 != null}");
            //     resetEvent.Set();
            // });

            var actionBlock = new ActionBlock<Tuple<ParserDto<ChangeableLightSourceTyped>, ParserDto<FixedLightSourceTyped>>>(tuple =>
            {
                Console.WriteLine("Tuple received in Lambda:\n" +
                                  $"{tuple.Item1.Items.Count} / {tuple.Item2.Items.Count}");
                resetEvent.Set();
            });

            transformFinal.LinkTo(actionBlock);
            // batchBlock.LinkTo(actionBlock);
            // batchBlock.LinkTo(transformBlock);

            transformXml.Post(xml);

            // var receive = transformFinal.Receive();
            // Console.WriteLine($"Received: {receive.Item1 != null} && {receive.Item2 != null}");
            
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