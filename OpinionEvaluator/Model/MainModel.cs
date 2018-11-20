using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpinionEvaluator.Model
{
    public class MainModel
    {
        private int _sliderValue;
        private string _sliderMessage;
        private string _newOpinion;

        public int SliderValue { get => _sliderValue; set => _sliderValue = value; }
        public string SliderMessage { get => _sliderMessage; set => _sliderMessage = value; }
        public string NewOpinion { get => _newOpinion; set => _newOpinion = value; }

        public MainModel()
        { }

    }
}
