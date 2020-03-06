using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Conversation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Game : Window


    {
        //vars
        public Timer timer;
        public float timeElapsed;
        public float lastTime;
        int seconds;
        float mili;
        float ticks;
        float counter;
        float counterP;
        Message currMessage;
        int messageIndex;
        bool isAnswering;
        bool isSendingPMessage;
        string pMessage;

        List<TextBlock> answerBoxes;
        List<TextBox> answerInputs;
        TextBox activeInput;

        bool hasAnswered = false;
        bool gameOver = false;

        System.Media.SoundPlayer pling = new System.Media.SoundPlayer("pling.wav");
        System.Media.SoundPlayer alarm = new System.Media.SoundPlayer("alarm.wav");


        public static List<string> randomKeys = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U",
        "V", "X", "Y", "Z", "PageUp", "PageUp", "PageUp", "PageDown", "PageDown", "Delete", "Delete", "Insert", "Insert", "Insert",
            "End", "End", "Home", "Home", "LeftCtrl", "RightCtrl", "RightShift", "PageUp", "PageDown", "PageDown", "Delete", "Delete", "Insert", "Insert", "Insert",
            "End", "End", "Home", "Home", "LeftCtrl", "RightCtrl", "RightShift", "RightCtrl", "RightShift"};

        public Game()
        {
            InitializeComponent();

            answerBoxes = new List<TextBlock>() { a1, a2, a3 };
            answerInputs = new List<TextBox>() { a1i, a2i };

            //set timer to run every 10 milliseconds; however, the event doesn't get processed often
            //enough hence resulting in inconsistant timer updates
            timer = new Timer(15);
            timer.Elapsed += new ElapsedEventHandler(TimerEventProcessor);
            timer.Enabled = true;
            timeElapsed = 0;
            lastTime = 0;

            seconds = 0;
            mili = 0;

            ticks = 0;
            counter = 0;
            counterP = 0;

            isAnswering = false;
            isSendingPMessage = false;
            activeInput = a1i;
            pMessage = "";

            messageIndex = 0;
            currMessage = Script.messages[0];

        }

        public void MyKeyPressEvent(object sender, KeyEventArgs e)
        {
            //Console.WriteLine(e.Key.ToString());

            if (isAnswering == false) return;

            if (currMessage.answer == null) return;

            Key key = e.Key;

            if (key == Key.Return && currMessage.answer.hasInput)
            {
                string input = activeInput.Text;
                sendPlayerMessage(input);
            }

            else
            {
                string keyString = key.ToString();
                
                if (currMessage.answer.hasInput == false || currMessage.answer.answer1 == "Klinkt goed!")
                {
                    string answerString = currMessage.answer.getAnswerFromKey(keyString);

                    if (answerString != "null")
                    {
                        sendPlayerMessage(answerString);
                    }
                }
            }

        }

        private void TimerEventProcessor(Object myObject, ElapsedEventArgs myEventArgs)
        {
            lastTime = timeElapsed;
            timeElapsed += myEventArgs.SignalTime.Millisecond;

            gameloop();
        }

        string text2 = "hello there how is it going bro's my name is pewdiepie";
        string text = "";
        string textP = "";
        char[] chars;
        char[] charsP;
        int charIndex = 0;
        int charIndexP = 0;
        bool skip = false;
        bool skipP = false;
        bool isTyping = false;
        //bool isTypingP = false;
        float playerTicks = 1500 / 15;

        public void gameloop()
        {

            //counter++;

            if (messageIndex == 0 && isTyping == false && ticks == 0)
            {
                isTyping = true;
                ticks = currMessage.mseconds / 15;
            }

            else
            {
                

                if (isTyping == false)
                {
                    counter++;

                    if (counter >= ticks)
                    {
                        
                        counter = 0;
                        isAnswering = false;
                        hasAnswered = false;

                        this.Dispatcher.Invoke(() =>
                        {
                            getTextBlock().Text = "";
                            getBorder().Visibility = Visibility.Hidden;
                        });

                        if (currMessage.message == "Wat vind jij?" && gameOver == false)
                        {
                            sendPlayerMessage("Klinkt goed!");
                        }

                        hideAnswers();

                        messageIndex++;
                        charIndex = 0;
                        text = "";
                        currMessage = Script.messages[messageIndex];
                        ticks = currMessage.mseconds / 15;
                        isTyping = true;
                        

                    }

                    else
                    {
                        if (isTyping == false && hasAnswered == false && currMessage.answer != null && isAnswering == false)
                        {
                            isAnswering = true;
                            showAnswers();
                        }

                    }
                }

                if (isSendingPMessage == false && gameOver == false)

                {
                    // && hasAnswered == true
                    counterP++;

                    if (counterP >= playerTicks)
                    {

                        counterP = 0;

                        this.Dispatcher.Invoke(() =>
                        {
                            p4.Text = "";
                            p4b.Visibility = Visibility.Hidden;
                        });

                        if  (hasAnswered == true) hideAnswers();

                        charIndexP = 0;
                        textP = "";


                    }

                }
            }


            if (isTyping)
            {
                typeMessage();
            }

            if (isSendingPMessage)
            {
                typePlayerMessage();
            }


        }

        private void sendPlayerMessage(string message)
        {
            isAnswering = false;
            isSendingPMessage = true;
            pMessage = message;
            hasAnswered = true;
            if (currMessage.message == "Wat vind jij?") gameOver = true;
            hideAnswers();
        }

        public void typePlayerMessage()
        {

            if (skipP == false)
            {
                skipP = true;
                return;
            }

            else skipP = false;

            charsP = pMessage.ToCharArray();

            if (charIndexP < charsP.Length)
            {
                textP = textP + charsP[charIndexP];
                charIndexP++;
            }

            else
            {
                isSendingPMessage = false;
                return;
            }



            this.Dispatcher.Invoke(() =>
            {
                p4.Text = textP;
                p4b.Visibility = Visibility.Visible;
            });

        }


        public void showAnswers()
        {
            if (currMessage.answer != null)
            {
                Answer answer = currMessage.answer;
                showAnswer(1, answer);

                if (answer.answer2 != null) showAnswer(2, answer);
                if (answer.answer3 != null) showAnswer(3, answer);
                Console.WriteLine("ANSWER");
                pling.Play();

                if (currMessage.message == "Wat vind jij?")
                {
                    alarm.Play();
                }
            }
        }

        private void showAnswer(int index, Answer answer)
        {
            string text = "";
            string key = "";
            TextBlock textblock = null;
            TextBox input = null;

            switch (index) {
                case 1: text = answer.answer1; key = answer.key1; textblock = a1; input = a1i; break;
                case 2: text = answer.answer2; key = answer.key2; textblock = a2; input = a2i; break;
                case 3: text = answer.answer3; key = answer.key3; textblock = a3; break;
            }

            if (key == "D1") key = "1";

            if (text == "input")
            {
                activeInput = input;

                this.Dispatcher.Invoke(() =>
                {
                    input.Visibility = Visibility.Visible;
                    //FocusManager.SetFocusedElement(this, input);
                    input.Focus();
                });
   
            }

            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    textblock.Text = text + "           [ " + key + " ]";
                    textblock.Visibility = Visibility.Visible;   
                });

                
            }
        }

        public void typeMessage()
        {

           if (currMessage.mseconds >= 300)
            {
                if (skip == false)
                {
                    skip = true;
                    return;
                }

                else skip = false;
            }

            int sender = currMessage.sender;

            chars = currMessage.message.ToCharArray();

            if (charIndex < chars.Length)
            {
                text = text + chars[charIndex];
                charIndex++;
            }

            else
            {
                isTyping = false;
                return;
            }

            

            this.Dispatcher.Invoke(() =>
            {
                getTextBlock().Text = text;
                getBorder().Visibility = Visibility.Visible;
            });

        }

        private void hideAnswers()
        {
            foreach (TextBlock box in answerBoxes)
            {
                this.Dispatcher.Invoke(() =>
                {
                    box.Visibility = Visibility.Hidden;
                });
               
            }

            foreach (TextBox input in answerInputs)
            {
                this.Dispatcher.Invoke(() =>
                {
                    input.Visibility = Visibility.Hidden;
                    input.Text = "";
                });

            }
        }

        private TextBlock getTextBlock()
        {
            TextBlock textblock = null;

            switch (currMessage.sender)
            {
                case 1: textblock = p1; break;
                case 2: textblock = p2; break;
                case 3: textblock = p3; break;
                case 4: textblock = p4; break;
            }

            return textblock;
        }

        private Border getBorder()
        {
            Border b = null;

            switch (currMessage.sender)
            {
                case 1: b = p1b; break;
                case 2: b = p2b; break;
                case 3: b = p3b; break;
                case 4: b = p4b; break;
            }

            return b;
        }

    }
}
