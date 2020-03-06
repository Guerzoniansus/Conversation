using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation
{
    public class Answer
    {
        public string answer1, answer2, answer3;
        public string key1, key2, key3;
        public bool hasInput;
        public Answer(string answer1, string answer2, string answer3)
        {
            this.answer1 = answer1;
            this.answer2 = answer2;
            this.answer3 = answer3;
            hasInput = false;
            
            if (answer1 == "default")
            {
                this.key1 = "D1";
                this.answer1 = "Klinkt goed!";
            }

            else
            {
                this.key1 = createRandomKey();
            }

            if (answer1 == "input") hasInput = true;

            if (answer2 != null)
            {
                if (answer2 == "default")
                {
                    this.key1 = "D1";
                    this.answer2 = "Klinkt goed!";
                }

                else if (answer2 == "input")
                {
                    key2 = null;
                    hasInput = true;
                }

                else
                {
                    string randomkey = createRandomKey();

                    while (randomkey == key1)
                    {
                        randomkey = createRandomKey();
                    }

                    this.key2 = randomkey;
                }
            }

            if (answer3 != null)
            {
                if (answer3 == "default")
                {
                    this.key1 = "D1";
                    this.answer3 = "Klinkt goed!";
                }

                else if (answer3 == "input")
                {
                    key3 = null;
                    hasInput = true;
                }

                else
                {
                    string randomkey = createRandomKey();

                    while (randomkey == key1 || randomkey == key2)
                    {
                        randomkey = createRandomKey();
                    }

                    this.key3 = randomkey;
                }
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Returns answer, or "null" if key does not match any</returns>
        public string getAnswerFromKey(string key)
        {
            string answer = "null";

            if (key == key1) answer = answer1;
            if (key == key2) answer = answer2;
            if (key == key3) answer = answer3;

            return answer;
        }

        public string createRandomKey()
        {
            var random = new Random();
            int index = random.Next(Game.randomKeys.Count);
            return Game.randomKeys[index];
            

        }
    }
}
