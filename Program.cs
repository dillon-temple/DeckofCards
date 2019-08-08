using System;
using System.Collections.Generic;

namespace DeckCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Player bobby = new Player("Bobby");
            deck.CreateDeck();
            deck.Deal();
            deck.Reset();
            deck.Shuffle(5);
            bobby.Draw(deck);
            bobby.Draw(deck);
            bobby.Draw(deck);
            bobby.Discard(3);
            bobby.Discard(3);
            Console.WriteLine("test");
        }
    }

    class Card
    {
        private string stringVal;
        private string suit;
        private int val;
        public string StringVal
        {
            get { return stringVal; }
        }
        public string Suit
        {
            get { return suit; }
        }

        public int Val
        {
            get { return val; }
        }

        public Card(string cardNum, string cardSuit, int cardVal){
            stringVal = cardNum;
            suit = cardSuit;
            val = cardVal;
        }

    }

    class Deck{
        private List<Card> deck = new List<Card>();
        public string[] cardList = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
        public string[] suitList = {"Clubs", "Spades", "Hearts", "Diamonds"};

        public void CreateDeck(){

            int cardNumber = 0;

            while(cardNumber < 52){
                if(cardNumber < 13){
                    Card temp = new Card(cardList[cardNumber], suitList[0], cardNumber + 1);
                    deck.Add(temp);
                }
                if(cardNumber >= 13 && cardNumber < 26){
                    Card temp = new Card(cardList[cardNumber - 13], suitList[1], cardNumber - 12);
                    deck.Add(temp);
                }
                if(cardNumber >= 26 && cardNumber < 39){
                    Card temp = new Card(cardList[cardNumber - 26], suitList[2], cardNumber -25);
                    deck.Add(temp);
                }
                if(cardNumber >= 39){
                    Card temp = new Card(cardList[cardNumber - 39], suitList[3], cardNumber - 38);
                    deck.Add(temp);
                }
                cardNumber++;
            }
            return;
        }

        public Card Deal(){
            Card draw = deck[0];
            deck.Remove(draw);
            return draw;
        }

        public void Reset(){
            deck.Clear();
            CreateDeck();
            return;
        }

        public void Shuffle(int shuffleAmount)
        {

            Random random = new Random();
            int shuffle = 0;
            while(shuffle < shuffleAmount){
                for (int i = 0; i < deck.Count; i++)
                {
                    Card store = deck[i];
                    int roll = random.Next(0, 52);
                    deck[i] = deck[roll];
                    deck[roll] = store;
                }
                shuffle++;
            }
            return;
        }


    }

    class Player{
        private string name;
        private List<Card> hand = new List<Card>();

        public string Name{
            get { return name;}
        }

        public List<Card> Hand{
            get { return hand;}
        }

        public Player(string Name){
            name = Name;
        }

        public Card Draw(Deck deck){
           Card draw = deck.Deal();
           hand.Add(draw);
           Console.WriteLine($"You drew the {draw.StringVal} of {draw.Suit}");
           return draw;
        }
        public Card Discard(int index){
            if(index > hand.Count){
                Console.WriteLine("There is no card there");
                return null;
            }else{
                Card discard = hand[index - 1];
                hand.Remove(discard);
                Console.WriteLine($"You discarded the {discard.StringVal} of {discard.Suit}");
                return discard;
            }
        }
    }
}
