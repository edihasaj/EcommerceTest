using Ecommerce.Models;
using Ecommerce.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    class PaymentCardTest
    {
        private PaymentCard paymentCard;
        private List<PaymentCard> paymentCardList;

        [SetUp]
        public void SetupCart()
        {
            paymentCardList = new List<PaymentCard>();

            paymentCard = new PaymentCard
            {
                CardNumber = "5566446644665588",
                CardName = "Tringa Berisha",
                CVV = "441",
                ExpirationDate = new DateTime(2022, 04, 24)
            };
        }

        [Test]
        public void GetInitialPaymentCardsTest()
        {
            paymentCardList = PaymentCardRepository.GetPaymentCards();

            if (paymentCardList.Count() <= 0)
                Assert.IsEmpty(paymentCardList);
            else
                Assert.IsNotEmpty(paymentCardList);
        }

        [Test]
        public void GetPaymentCardByIdTest()
        {
            PaymentCardRepository.Insert(paymentCard);

            var cardFromList = PaymentCardRepository.GetPaymentCardById(paymentCard.Id);

            Assert.IsNotNull(cardFromList);
        }

        [Test]
        public void InsertPymentCardTest()
        {
            PaymentCardRepository.Insert(paymentCard);
            var cardFromList = PaymentCardRepository.GetPaymentCardById(paymentCard.Id);

            Assert.AreEqual(paymentCard, cardFromList);
        }

        [Test]
        public void UpdatePaymentCardTest()
        {
            PaymentCardRepository.Insert(paymentCard);
            var cardFromList = PaymentCardRepository.GetPaymentCardById(paymentCard.Id);

            cardFromList.CardName = "Teuta Gashi";

            PaymentCardRepository.Update(cardFromList);

            Assert.Contains(cardFromList, PaymentCardRepository.GetPaymentCards());
        }

        [Test]
        public void RemovePaymentCardTest()
        {
            PaymentCardRepository.Insert(paymentCard);
            var cardItemFromList = PaymentCardRepository.GetPaymentCardById(paymentCard.Id);

            PaymentCardRepository.Remove(cardItemFromList);
            var checkRemovedPaymentCard = PaymentCardRepository.GetPaymentCardById(cardItemFromList.Id);

            Assert.IsNull(checkRemovedPaymentCard);
        }
    }
}
