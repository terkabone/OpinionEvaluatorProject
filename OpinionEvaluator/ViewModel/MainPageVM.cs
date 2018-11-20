using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using OpinionEvaluator.Model;
using OpinionEvaluator.ViewModel;
using OpinionEvaluator.View;

namespace OpinionEvaluator.ViewModel
{
    public class MainPageVM : PropertyChangedVM
    {
        private readonly PageNavigate _frameNavigate;
        public MainModel TheModel;
        public PageNavigate TheNavigator;
        public RelayCommandVM AddNewOpinionCommand { get; set; }
        public RelayCommandVM GoToEvaluatePageCommand { get; set; }

        public int SliderValue
        {
            get => TheModel.SliderValue;
            set
            {
                TheModel.SliderValue = value;
                OnPropertyChanged("SliderValue");
            }
        }

        public string SliderMessage
        {
            get => TheModel.SliderMessage;
            set
            {
                TheModel.SliderMessage = DoSliderMessage();
                OnPropertyChanged("SliderValue");
            }
        }

        public string DoSliderMessage()
        {
            if (TheModel.SliderValue >= 40)
            {
                TheModel.SliderMessage = "That's not that bad :)";
            }
            else if (TheModel.SliderValue >= 80)
            {
                TheModel.SliderMessage = "OK that's kinda bad...";
            }
            else
            {
                TheModel.SliderMessage = "Shit, you're fucked up!";
            }

            return TheModel.SliderMessage;
        }

        public string NewOpinion
        {
            get => TheModel.NewOpinion;
            set
            {
                TheModel.NewOpinion = value;
                OnPropertyChanged("NewOpinion");
            }
        }

        public ObservableCollection<string> OpinionList { get; set; }

        public void AddNewOpinion()
        {
            OpinionList.Add(NewOpinion);
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
            SliderValue = 50;
            NewOpinion = "Sample opinion";
            SliderMessage = DoSliderMessage();

            OpinionList = new ObservableCollection<string>
            {
                "I like it.",
                "That was ok.",
                "I don't like it."
            };
        }
    }
}
