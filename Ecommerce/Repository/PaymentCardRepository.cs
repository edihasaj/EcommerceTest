using Ecommerce.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Repository
{
    public static class PaymentCardRepository
    {
        private static List<PaymentCard> _paymentCard = new List<PaymentCard>();

        public static void Insert(PaymentCard paymentCard)
        {
            if (_paymentCard.Any())
            {
                int lastId = _paymentCard.Last().Id;
                paymentCard.Id = ++lastId;
                _paymentCard.Add(paymentCard);
            }
            else
            {
                paymentCard.Id = 1;
                _paymentCard.Add(paymentCard);
            }
        }

        public static void Update(PaymentCard paymentCard)
        {
            //var paymentCardItem = _paymentCard.FirstOrDefault(s => s.Id == paymentCard.Id);

            //paymentCardItem.CardNumber = paymentCard.CardNumber;
            //paymentCardItem.CardName = paymentCard.CardName;
            //paymentCardItem.CVV = paymentCard.CVV;
            //paymentCardItem.ExpirationDate = paymentCard.ExpirationDate;

            _paymentCard.Remove(_paymentCard.Single(x=>x.Id == paymentCard.Id));
            _paymentCard.Add(paymentCard);
        }

        public static void Remove(PaymentCard paymentCard)
        {
            _paymentCard.Remove(paymentCard);
        }

        public static List<PaymentCard> GetPaymentCards()
        {
            return _paymentCard;
        }


        public static PaymentCard GetPaymentCardById(int id)
        {
            return _paymentCard.FirstOrDefault(x => x.Id == id);
        }
    }
}
