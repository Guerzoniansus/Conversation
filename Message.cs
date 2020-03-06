using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation
{
    public class Message
    {

        public string message;
        public int sender;
        public float mseconds;
        public Answer answer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">p1 p2 p3 p4</param>
        /// <param name="message">msg</param>
        public Message(int sender, string message)
        {
            this.sender = sender;
            this.message = message;
            mseconds = 1000;
            answer = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">p1 p2 p3 p4</param>
        /// <param name="message">msg</param>
        /// <param name="mseconds">time to display after finish typing (default = 1000)</param>
        public Message(int sender, string message, float mseconds)
        {
            this.sender = sender;
            this.message = message;
            this.mseconds = mseconds;
            answer = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">p1 p2 p3 p4</param>
        /// <param name="message"msg></param>
        /// <param name="mseconds">time to display after finish typing (default = 1000)</param>
        /// <param name="answer">answer</param>
        public Message(int sender, string message, float mseconds, Answer answer)
        {
            this.sender = sender;
            this.message = message;
            this.mseconds = mseconds;
            this.answer = answer;
        }

    }
}
