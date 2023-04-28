using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AreYouPopeye_Swipe
{
    public partial class MainPage : ContentPage
    {
        IList<string> questionList = new List<string>();
        IList<string> imageList = new List<string>();
        IList<bool> answerList = new List<bool>();
        private int _index;
        private bool _isPopeye;

        public MainPage()
        {
            InitializeComponent();
            questionList.Add("You love spinach!");
            questionList.Add("You love Bluto!");
            questionList.Add("You don't have any tattoos.");
            questionList.Add("You smoke a pipe.");
            questionList.Add("You were once portrayed by Robin Williams.");
            answerList.Add(true);
            answerList.Add(false);
            answerList.Add(false);
            answerList.Add(true);
            answerList.Add(true);
            imageList.Add("spinach.png");
            imageList.Add("bluto.png");
            imageList.Add("tattoo.png");
            imageList.Add("pipe.png");
            imageList.Add("robin.png");
            _index = 0;
            _isPopeye = true;
            QuestionImage.Source = imageList[_index];
            QuestionText.Text = questionList[_index];
        }

        void OnSwiped(object sender, SwipedEventArgs e)
        {
            if (e.Direction == SwipeDirection.Right)
            {
                HandleSwipe(true);
            }
            else if (e.Direction == SwipeDirection.Left)
            {
                HandleSwipe(false);
            }
        }

        void HandleSwipe(bool _response)
        {
            if (_isPopeye && !CheckAnswer(_response))
            {
                _isPopeye = false;
            }
            IncrementOrEnd();
        }

        bool CheckAnswer(bool _response)
        {
            if (_response == answerList[_index])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void IncrementOrEnd()
        {
            if (_index < 4)
            {
                _index++;
                QuestionImage.Source = imageList[_index];
                QuestionText.Text = questionList[_index];
            }
            else
            {
                HelperText.Text = "";
                QuestionImage.IsVisible = false;

                if (_isPopeye)
                {
                    Olive.Source = "olive2.png";
                    QuestionText.Text = "You Are Popeye!";
                }
                else
                {
                    Olive.Source = "olive3.png";
                    QuestionText.Text = "You Are Not Popeye!";
                }
            }
        }
    }
}
