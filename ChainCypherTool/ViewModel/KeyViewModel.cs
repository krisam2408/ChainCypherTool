using ChainCypherLib.Factory;
using ChainCypherTool.Model.Abstracts;
using ChainCypherTool.Model.DataTransfer;
using System.Collections.ObjectModel;

namespace ChainCypherTool.ViewModel
{
    public class KeyViewModel:BaseViewModel, INavegable
    {
        private KeyFactory Factory { get; set; }

        private ObservableCollection<SpectrumItem> spectrum;
        public ObservableCollection<SpectrumItem> Spectrum { get { return spectrum; } set { SetValue(ref spectrum, value); } }

        public KeyViewModel()
        {
            Factory = new();
            Spectrum = SetSpectrum();
        }

        private ObservableCollection<SpectrumItem> SetSpectrum()
        {
            ObservableCollection<SpectrumItem> output = new();
            foreach (string k in KeyFactory.GetSpectrum())
            {
                SpectrumItem s = new()
                {
                    Character = k
                };

                output.Add(s);
            }

            return output;
        }
    }
}
