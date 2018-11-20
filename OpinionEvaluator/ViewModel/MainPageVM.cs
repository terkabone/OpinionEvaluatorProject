using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using OpinionEvaluator.Model;
using OpinionEvaluator.ViewModel;

namespace OpinionEvaluator.ViewModel
{
    class MainPageVM : PropertyChangedVM
    {
        private readonly PageNavigate _frameNavigate;
        public MainModel TheModel;
        public PageNavigate TheNavigator;
        public RelayCommandVM AddNewOpinionCommand { get; set; }
        public RelayCommandVM GoToEvaluatePageCommand { get; set; }

        private int _sliderValue;
        private string _sliderMessage;
        private string _newOpinion;

        public int SliderValue
        {
            get => _sliderValue;
            set { _sliderValue = value; OnPropertyChanged("SliderValue"); }
        }

        public string SliderMessage
        {
            get => _sliderMessage;
            set
            {
                if (_sliderValue >= 40)
                { _sliderMessage = "That's not that bad :)"; }
                else if (_sliderValue >= 80)
                { _sliderMessage = "OK that's kinda bad..."; }
                else
                { _sliderMessage = "Shit, you're fucked up!";  }
                OnPropertyChanged("SliderValue");
            }
        }

        public string NewOpinion
        {
            get => _newOpinion;
            set { _newOpinion = value; OnPropertyChanged("NewOpinion"); }
        }

        public ObservableCollection<string> OpinionList { get; set; }

        public void AddNewOpinion()
        {
            OpinionList.Add(NewOpinion);
            // OpinionList.Add(_newOpinion);
        }

        public void GoToEvaluatePage()
        {
            Type type = typeof(EvaluatePage);
            _frameNavigate.ActivateFrameNavigation(type);
        }


        // constructor
            public MainPageVM()
        {
            TheModel = new MainModel();
            TheNavigator = new PageNavigate();
            AddNewOpinionCommand = new RelayCommandVM(AddNewOpinion);
            GoToEvaluatePageCommand = new RelayCommandVM(GoToEvaluatePage);
            _frameNavigate = new PageNavigate();

            OpinionList = new ObservableCollection<string>
            {
                "I like it.",
                "That was ok.",
                "I don't like it."
            };

        }
    }
}
