using Code_Practice.Delegate.MaterialsCovarianceAndContravariance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Practice.Delegate
{
    public class CovarianceAndContravariance5
    {
        // WebSiteLink: https://metanit.com/sharp/tutorial/3.28.php
        // Questions for testing: https://metanit.com/sharp/questions/2.18.php
        public CovarianceAndContravariance5()
        {
        }

        public void Execute()
        {
            //this.Example1Covariance();
            //this.Example2Contravariance();
            //this.Example3GenericDelegatesCovariance();
            //this.Example4GenericDelegatesContravariance();
            this.Example5CombiningCovarianceAndContravariance();
        }


        /*
         Ковариантность делегата предполагает, что возвращаемым типом может быть производный тип. 
         */
        delegate Message MessageBuilder(string text); // Have no limits on which of classes* wil be returned. * - classes that inheristance by "Message".
        public void Example1Covariance()
        {
            MessageBuilder messageBuilder = WriteEmailMessage;
            Message message = messageBuilder.Invoke("Hello");
            message.Print();

            EmailMessage WriteEmailMessage(string text) => new EmailMessage(text);
        }

        /*
         
         */

        delegate void EmailReceiver(EmailMessage message); // "EmailMessage message" make limits for input parameters
        public void Example2Contravariance()
        {
            EmailReceiver emailBox = ReceiveMessage;
            emailBox.Invoke(new EmailMessage("Welcome by Email."));
            //emailBox.Invoke(new SmsMessage("Welcome by Sms.")); // <- It isn't work.

            void ReceiveMessage(Message message) => message.Print();
        }


        /*
         Covariance and contravariance in generic delegates
         */
        delegate T MessageBuilder<out T>(string text);
        public void Example3GenericDelegatesCovariance() // Covariance
        {
            MessageBuilder<EmailMessage> EmailMessageWriter = (string text) => new EmailMessage(text); // Contravariance
            //             ^_^  thank to parameter "out" that make possible to inherit the generic. That parameter specifies that a type parameter is covariant.
            MessageBuilder<Message> messageBuilder = EmailMessageWriter; // Covariance

            Message message = messageBuilder("hello Tom");
            message.Print();
            MessageBuilder<SmsMessage> SmsMessageWriter = (string text) => new SmsMessage(text); // Contravariance
            messageBuilder = SmsMessageWriter;
            message = messageBuilder("Hi, Jim!");
            message.Print();

        }


        /*
         То есть, если грубо обобщить, ковариантность - это от более производного к более общему типу (EmailMessage -> Message), 
            а контрвариантность - от более общего к более производному типу (Message -> EmailMessage).
         */
        delegate void MessageReceiver<in T>(T message);
        // Parameter "in" downcasting
        public void Example4GenericDelegatesContravariance()
        {
            MessageReceiver<Message> messageReceiver = (Message message) => message.Print();
            MessageReceiver<EmailMessage> emailMessageReceiver = messageReceiver;

            messageReceiver.Invoke(new Message("Hello World!")); // Show message as Message
            messageReceiver.Invoke(new EmailMessage("Hello World!")); // Show message as Email

            messageReceiver.Invoke(new EmailMessage("Nero ty;!")); // Show message as Email
            emailMessageReceiver.Invoke(new EmailMessage("Kitty;!")); // Show message as Email
            //emailMessageReceiver.Invoke(new Message("Kitty;!")); // not works
        }


        // Можно использовать "in", "out" для разных генериков два в одно и тоже время.
        delegate E MessageConverter<in M, out E>(M message);
        //Здесь делегат MessageConverter представляет условное действие, которое конвертирует объект типа M в тип E.
        public void Example5CombiningCovarianceAndContravariance()
        {
            MessageConverter<Message, EmailMessage> toEmailConverter = (Message message) => new EmailMessage(message.Text);

            MessageConverter<SmsMessage, Message> converter = toEmailConverter;
            Message message = converter(new SmsMessage("Hello work"));

            Message message1 = toEmailConverter(new SmsMessage("hi"));
            message.Print();
            message1.Print();

        }
        /*
         
         Здесь делегат MessageConverter представляет условное действие, которое конвертирует объект типа M в тип E.

В программе определена переменная converter, которая представляет тип MessageConverter<SmsMessage, Message> - то есть конвертер из типа SmsMessage в любой тип Message, грубо говоря преобразует смс в любой другой тип сообщения.

Этой переменной можно передать действие - toEmailConverter, которое из сообщений любого типа создает объект Email-сообщения. Здесь применяется контравариантность: для параметра вместо производного типа SmsMessage применяется базовый тип Message. И также есть ковариантность: вместо возвращаемого типа Message используется производный тип EmailMessage.
         */
    }
}
