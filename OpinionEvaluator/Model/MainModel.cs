﻿using System;
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

        public int SliderValue { get; set; }
        public string SliderMessage { get; set; }
        public string NewOpinion { get; set; }

        public MainModel()
        { }

    }
}
