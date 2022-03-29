using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiskMonWithWPFUI.Model;
using DiskMonWithWPFUI.Helpers;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace DiskMonWithWPFUI.ViewModel
{
    internal class MainViewModel:ViewModelBase, IDisposable
    {
        private ObservableCollection<DiskIoModel> _diskIos;
        private TraceEventSession _traceEventSession;
        private object _lock = new object();

        public ObservableCollection<DiskIoModel> DiskIos
        {
            get => _diskIos;
            set
            {
                _diskIos = value;
                NotifyPropertyChanged(nameof(DiskIos));
            }
        }
        private void SetItemToListOfDiskIos(DiskIOTraceData diskIOTraceData)
        {

            Dispatcher.CurrentDispatcher.Invoke(() =>
            {
                _diskIos.Add(DiskIoHelper.GetDiskIoModel(diskIOTraceData));
                DiskIos = _diskIos;
            });

        }
        private void SetUpTracer()
        {
            _traceEventSession = new TraceEventSession(KernelTraceEventParser.KernelSessionName);
            _traceEventSession.EnableKernelProvider(KernelTraceEventParser.Keywords.DiskIO);
            _traceEventSession.Source.Kernel.DiskIORead += SetItemToListOfDiskIos;
            _traceEventSession.Source.Kernel.DiskIOWrite += SetItemToListOfDiskIos;
            _traceEventSession.Source.Process();

        }

        public void Dispose()
        {
            _traceEventSession.Dispose();
        }

        public MainViewModel()
        {
            _diskIos = new ObservableCollection<DiskIoModel>();
            BindingOperations.EnableCollectionSynchronization(_diskIos, _lock);
            Task.Run(() => SetUpTracer());
            

        }
    }
}
